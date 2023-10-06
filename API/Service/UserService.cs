
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API.Dtos.User;
using API.Helpers;
using API.Models;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _config;
        public UserService
        (
            IUnitOfWork unitOfWork, 
            IPasswordHasher<User> passwordHasher, 
            IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _config = config;
        }

        public async Task<RegisterDto> UserRegister(UserDto user)
        {
            RegisterDto response = new();

            if(VerifyUserExist(user.Username))
            {
                User registro = new()
                {
                    Username = user.Username,
                    Email = user.Email
                };

                registro.Password = _passwordHasher.HashPassword(registro, user.Password);  
                var rol = _unitOfWork.Rols.Find(x => x.Name == Rols.defaultRol.ToString()).FirstOrDefault();
                registro.Rols.Add(rol);

                try
                {
                    _unitOfWork.Users.Add(registro);
                    await _unitOfWork.SaveAsync();

                    response.Username = registro.Username;
                    response.Email = registro.Email;
                    response.Message = "User sussesfully registered";
                    return response;
                }
                catch (Exception error)
                {
                    response.Username = user.Username;
                    response.Email = user.Email;
                    response.Message = $"Error {error}";
                    return response;
                }
            }
            else
            {
                response.Username = user.Username;
                response.Email = user.Email;
                response.Message = "User already exist";
                return response;
            }
        }

        public async Task<ResponseLoginDto> Login(LoginDto data)
        {
            ResponseLoginDto response = new();

            if(!VerifyUserExist(data.Username))
            {
                var user = await _unitOfWork.Users.GetUserByUsername(data.Username);
                var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.Password, data.Password);

                if(passwordVerification == PasswordVerificationResult.Success)
                {
                    var refreshToken = CreateRefreshToken(user.Id);
                    _unitOfWork.RefreshToken.Add(refreshToken);
                    await _unitOfWork.SaveAsync();

                    response.Username = user.Username;
                    response.Token = CreateToken(user);
                    response.RefreshToken = refreshToken.Token;
                    response.Message = $"Token created successfully";
                    return response;
                }
                else 
                {
                    response.Username = data.Username;
                    response.Token = null;
                    response.RefreshToken = null;
                    response.Message = $"Incorrect credentials";
                    return response;
                }
            }
            else 
            {
                response.Username = data.Username;
                response.Token = null;
                response.RefreshToken = null;
                response.Message = $"User {data.Username} is not registered";
                return response;
            }
        }

        public async Task<string> AddRole(AddRolDto data)
        {
            if(!VerifyUserExist(data.Username))
            {
                var user = _unitOfWork.Users.Find(x => x.Username.ToLower() == data.Username.ToLower()).FirstOrDefault();
                var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.Password, data.Password);

                if(passwordVerification == PasswordVerificationResult.Success)
                {
                    var rolExist = _unitOfWork.Rols.Find(x => x.Id == data.RolId).FirstOrDefault();

                    if(rolExist != null)
                    {
                        user.Rols.Add(rolExist);
                        _unitOfWork.Users.Update(user);
                        await _unitOfWork.SaveAsync();
                        return $"Role successfully added";
                    }
                    else
                    {
                        return $"The rol dosen't exist";
                    }
                }
                else
                {
                    return $"Invalid credentials";
                }
            }
            else 
            {
                return $"User {data.Username} is not registered";
            }

        }

        private string CreateToken(User UserData)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var byteKey = Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value);
            
            var rols = UserData.Rols;
            var roleClaims = new List<Claim>();
             
            foreach (var role in rols)
            {
                roleClaims.Add(new Claim("Rols", role.Name));
            }

            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new("Id", UserData.Id.ToString()),
                    new("Username", UserData.Username),
                    new("Email", UserData.Email),
                    
                }.Union(roleClaims)),
                Issuer = _config.GetSection("Jwt:Issuer").Value,
                Audience = _config.GetSection("Jwt:Audience").Value,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey), SecurityAlgorithms.HmacSha256Signature)          
            };
            var token = tokenHandler.CreateToken(tokenDes);
            return tokenHandler.WriteToken(token);
        }
        
        private RefreshToken CreateRefreshToken(int UserId)
        {
            RefreshToken refreshToken = new()
            {
                IdUser = UserId,
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpirationDate = DateTime.Now.AddDays(7),
                IsRevoked = false,
                IsActive = true

            };
            return refreshToken;
        }

        public async Task<ResponseLoginDto> ValidateRefreshToken(ValidateRefreshTokenDto tokens)
        {
            var refreshToken = _unitOfWork.RefreshToken.Find(x => x.Token == tokens.RefreshToken).FirstOrDefault();
            ResponseLoginDto response = new();

            if(refreshToken == null)
            {
                response.Message = "Invalid Credentials";
                return response;
            }

            var user = _unitOfWork.Users.Find(x => x.Id == refreshToken.IdUser).FirstOrDefault();
            var userRols = await _unitOfWork.Users.GetUserByUsername(user.Username);
            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokens.Token);

            string idUser = token.Claims.FirstOrDefault(claim => claim.Type == "Id")?.Value;
            string username = token.Claims.FirstOrDefault(claim => claim.Type == "Username")?.Value;
            string email = token.Claims.FirstOrDefault(claim => claim.Type == "Email")?.Value;

            if(user.Id.ToString() != idUser)
            {
                response.Message = "Invalid token";
                return response;
            }

            if(user.Username != username)
            {
                response.Message = "Invalid token";
                return response;
            }

            if(user.Email != email)
            {
                response.Message = "Invalid token";
                return response;
            }

            if(refreshToken.ExpirationDate < DateTime.Now)
            {
                response.Message = "Invalid Expired";
                return response;
            }

            if(refreshToken.IsRevoked == true)
            {
                response.Message = "Invalid token";
                return response;
            }

            if(refreshToken.IsActive == false)
            {
                response.Message = "Invalid token";
                return response;
            }

            refreshToken.IsRevoked = true;
            refreshToken.IsActive = false;

            _unitOfWork.RefreshToken.Update(refreshToken);
            await _unitOfWork.SaveAsync();

            var newRefreshToken = CreateRefreshToken(user.Id);
            _unitOfWork.RefreshToken.Add(newRefreshToken);
            await _unitOfWork.SaveAsync();

            response.Username = user.Username;
            response.Token = CreateToken(userRols);
            response.RefreshToken = newRefreshToken.Token;
            response.Message = $"Token created successfully";
            return response;    
        }

        private bool VerifyUserExist(string username)
        {
            var registro = _unitOfWork.Users.Find(x => x.Username.ToLower() == username).FirstOrDefault();
            return registro == null;
        }
    }
}