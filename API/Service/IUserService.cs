
using API.Dtos.User;
using API.Models;

namespace API.Service
{
    public interface IUserService
    {
        Task<RegisterDto> UserRegister(UserDto user);
        Task<ResponseLoginDto> Login(LoginDto data);
        Task<ResponseLoginDto> ValidateRefreshToken(ValidateRefreshTokenDto tokens);
        Task<string> AddRole(AddRolDto data);
    }
}