using Car.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Car.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(string userName,string password)
        {
            if (userName == null || password == null)
            {
                return BadRequest("Username or Password cannot be null");
            }

            var result = _userService.Login(userName, password);

            if (result == null)
            {
                return BadRequest("User is not found");
            }

            return Ok(result);
        }
    }
}
