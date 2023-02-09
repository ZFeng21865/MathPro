using IMathLib;
using Microsoft.AspNetCore.Mvc;

namespace MathProApi.Controllers
{
    /// <summary>
    /// Basic arithmetic operation controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BasicController : ControllerBase
    {
        

        private readonly ILogger<BasicController> _logger;
        private readonly IMyMathLib _mathLib;

        public BasicController(ILogger<BasicController> logger, IMyMathLib mathLib)
        {
            _logger = logger;
            _mathLib = mathLib;
        }

        /// <summary>
        /// Addition.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpGet("add")]
        public decimal Add(decimal a, decimal b)
        {
            return _mathLib.Add(a, b);
        }

        /// <summary>
        /// Subtraction.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpGet("subtract")]
        public decimal Subtract(decimal a, decimal b)
        {
            return _mathLib.Subtract(a, b);
        }
    }
}