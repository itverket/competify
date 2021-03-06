using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("[action]")]
        public IActionResult Authenticate([FromBody] AuthenticationRequest request)
        {
            if (request.Secret == Constants.Passphrase) {
                var response = new AuthenticationResponse { AuthenticationToken = Constants.AuthenticationToken };
                return new ObjectResult(response);
            }
            return new UnauthorizedResult();
        }

        public struct AuthenticationRequest 
        {
            public string Secret { get; set; }
        }

        public struct AuthenticationResponse
        {
            public string AuthenticationToken { get; set; }
        }
    }
}
