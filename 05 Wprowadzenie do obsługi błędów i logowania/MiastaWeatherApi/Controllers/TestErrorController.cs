using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiastaWeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            throw new Exception("Testowy wyjątek");
        }
    }
}