using Project.Core.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Workabroad.Presentation.Admin.Extensions.Services;

namespace Project.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] SetUserDto user)
        {
            if (user.UserName == "admin" && user.Password == "admin")
            {
                var response = JwtAuthenticationExtensions.GenerateJwtToken(_configuration, string.Empty, user.UserName, null, null);
                return Ok(response);
            }

            return BadRequest(new { message = "მომხმარებლის სახელი ან პაროლი არასწორია!" });
        }
    }
}
