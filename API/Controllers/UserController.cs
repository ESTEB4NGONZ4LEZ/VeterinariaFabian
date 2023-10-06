
using API.Dtos.User;
using API.Models;
using API.Service;
using AutoMapper;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService) : base(unitOfWork, mapper)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterDto>> Register(UserDto data)
        {
            var registro = await _userService.UserRegister(data);
            return Ok(registro);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseLoginDto>> LoginAsync(LoginDto data)
        {
            var login = await _userService.Login(data);
            return login;
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult<ResponseLoginDto>> RefreshToken(ValidateRefreshTokenDto tokens)
        {
            var jwtTokens = await _userService.ValidateRefreshToken(tokens);
            return jwtTokens;
        }

        [HttpPost("addRole")]
        public async Task<ActionResult<string>> AddRole(AddRolDto data)
        {
            var updateRole = await _userService.AddRole(data);
            return updateRole;
        }
    }
}