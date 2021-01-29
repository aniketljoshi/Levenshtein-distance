using System.Threading.Tasks;
using Levenshtein.Distance.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Levenshtein.Distance.Web.Controllers
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    public class CompareController : ControllerBase
    {
        private readonly IStringComparerService _stringComparerService;

        public CompareController(IStringComparerService stringComparerService)
        {
            _stringComparerService = stringComparerService;
        }

        [HttpPost("distance")]
        public async Task<IActionResult> CompareStrings([FromBody] StringCompareRequest request)
        {
            var result = await _stringComparerService.CompareAsync(request);
            return Ok(result);
        }
    }
}