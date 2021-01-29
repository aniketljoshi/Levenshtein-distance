using System.Threading.Tasks;
using Levenshtein.Distance.Core;
using Microsoft.AspNetCore.Mvc;

namespace Levenshtein.Distance.Web.Controllers
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authenticationService.SignIn(request);

            return Ok(response);
        }
    }
}