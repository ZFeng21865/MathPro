using Microsoft.AspNetCore.Mvc;

namespace MathProApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasicController : ControllerBase
    {
        

        private readonly ILogger<BasicController> _logger;

        public BasicController(ILogger<BasicController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Add")]
        public decimal Add(decimal n1, decimal n2)
        {
            return n1 + n2;
        }
    }
}