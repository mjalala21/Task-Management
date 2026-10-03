using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Services;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtService _jwtService;

        public AuthController(AuthService authService, JwtService jwtService)
        {
            _authService = authService; ;
            _jwtService = jwtService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterModel model)
        {
            var user = _authService.Register(model);

            return Created("", user);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
           var user =  _authService.Login(model);

            if(user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _jwtService.GenerateToken(user);

            return Ok(
                new
                {
                    token = token
                }
                );
        }
    }
}
