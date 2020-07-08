using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsCleanArch.Presentation.Authentication;

namespace ProductsCleanArch.Presentation.Controllers
{

    public class AuthenticationController : BaseController
    {
        private readonly IJwtAuthentication _jwtAuthentication;

        public AuthenticationController(IJwtAuthentication jwtAuthentication)
        {
            _jwtAuthentication = jwtAuthentication;
        }

        [HttpPost]
        [Route("api/v1/authentication/login")]
        [DisplayName("Can Login")]

        public IActionResult Authenticate([FromBody] UserCredentials userCredentials)
        {
            var token = _jwtAuthentication.Authenticate(userCredentials.UserName, userCredentials.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}