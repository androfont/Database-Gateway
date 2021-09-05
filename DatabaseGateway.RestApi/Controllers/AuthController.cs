using DatabaseGateway.RestApi.Auth;
using DatabaseGateway.RestApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseGateway.RestApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuth _jwtAuth;

        public AuthController(IJwtAuth jwtAuth)
        {
            _jwtAuth = jwtAuth;
        }

        [Route("authenticate")]
        [HttpPost]
        public IActionResult Authenticate(UserCredential userCredential)
        {
            var token = _jwtAuth.Authenticate(userCredential.Username, userCredential.Password);
            if (token != null)
            {
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
