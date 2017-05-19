using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookMonkey.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginApiController : Controller
    {
        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] UserLogin userLogin)
        {
            if (userLogin == null)
                return BadRequest();

            if (userLogin.Username == userLogin.Password)
            {
                var newPrincipal = new ClaimsPrincipal(new ClaimsIdentity("Cookies"));
                await HttpContext.Authentication.SignInAsync("Cookies", newPrincipal);
                return Ok();
            }

            return Unauthorized();
        }

        [Route("signout")]
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");

            return Ok();
        }
    }
}