using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsenkronWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrnekController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetContentAsync()
        {
            var myText = new HttpClient().GetStringAsync("https://www.google.com"); // Google Datasını Al.
            var data = await myText;
            return Ok(data);
        }
    }
}
