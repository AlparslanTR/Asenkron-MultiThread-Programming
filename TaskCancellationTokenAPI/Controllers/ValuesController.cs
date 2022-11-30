using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskCancellationTokenAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly ILogger _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetData(CancellationToken token)
        {
            try
            {

            
            _logger.LogInformation("İstek Başladı");
            //Thread.Sleep(5000); // Token isteği iptal olmaz hala devam eder burada kullanamayız.
            await Task.Delay(5000, token); // Bununla birlikte tokeni çağırıp iptal işlemini gerçekleştirebiliriz.
            var myTask = new HttpClient().GetStringAsync("https://www.google.com");
            var data = await myTask;
            _logger.LogInformation("İstek Bitti");
            return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("İstek İptal Edildi: " + ex.Message);
                return BadRequest();
            }
        }
    }
}
