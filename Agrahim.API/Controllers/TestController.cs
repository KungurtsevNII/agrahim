using Microsoft.AspNetCore.Mvc;

namespace Agrahim.API.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public string Test([FromBody] bool isInitial)
        {
            return "Diman lox";
        }
    }
}