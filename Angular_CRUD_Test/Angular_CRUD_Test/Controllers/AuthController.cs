using Angular_CRUD_Test.DTOs;
using Angular_CRUD_Test.Services;
using Microsoft.AspNetCore.Mvc;

namespace Angular_CRUD_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userRepository.Authenticate(request.Username, request.Password);

            if (user == null)
                return Unauthorized();

            var token = _tokenService.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}
