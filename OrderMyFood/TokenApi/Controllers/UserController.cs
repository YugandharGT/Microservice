using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderMyFood.TokenApi.Models;
using OrderMyFood.TokenApi.Services;

namespace OrderMyFood.TokenApi.Controllers
{
    /// <summary>
    /// Custom Authorization token Provider
    /// </summary>
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Login loginParam)
        {
            var token = _userService.Authenticate(loginParam.Username, loginParam.Password);

            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(token);
        }
    }
}
