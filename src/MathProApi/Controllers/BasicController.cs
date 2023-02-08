using IMathLib;
using Microsoft.AspNetCore.Mvc;

namespace MathProApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasicController : ControllerBase
    {
        

        private readonly ILogger<BasicController> _logger;
        private readonly IMyMathLib _mathLib;

        public BasicController(ILogger<BasicController> logger, IMyMathLib mathLib)
        {
            _logger = logger;
            _mathLib = mathLib;
        }

        [HttpGet(Name = "Add")]
        public decimal Add(decimal a, decimal b)
        {
            return _mathLib.Add(a, b);
        }
    }
}