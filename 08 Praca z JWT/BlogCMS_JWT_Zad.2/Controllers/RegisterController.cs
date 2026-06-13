using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogCMS.Data;
using BlogCMS.Models;

namespace BlogCMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] LoginModel newUser)
        {
            if (newUser == null)
                return BadRequest("Invalid user data");

            newUser.Role = "Admin";
            UserConstants.Users.Add(newUser);

            return Ok(new
            {
                message = "User registered successfully",
                user = newUser
            });
        }
    }
}