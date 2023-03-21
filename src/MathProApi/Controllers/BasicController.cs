using IMathLib;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mathLib"></param>
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
            string traceID = Guid.NewGuid().ToString();

            _logger.LogTrace($"{traceID} - START Add.");
            _logger.LogDebug($"{traceID} - {a},{b}.");

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
            string traceID = Guid.NewGuid().ToString();

            _logger.LogTrace($"{traceID} - START Subtract.");
            _logger.LogDebug($"{traceID} - {a},{b}.");

            return _mathLib.Subtract(a, b);
        }

        /// <summary>
        /// Multiplication.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpGet("multiply")]
        public decimal Multiply(decimal a, decimal b)
        {
            string traceID = Guid.NewGuid().ToString();

            _logger.LogTrace($"{traceID} - START Multiply.");
            _logger.LogDebug($"{traceID} - {a},{b}.");

            return _mathLib.Multiply(a, b);
        }

        /// <summary>
        /// Division.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpGet("divide")]
        public decimal Divide(decimal a, decimal b)
        {
            string traceID = Guid.NewGuid().ToString();

            _logger.LogTrace($"{traceID} - START Divide.");
            _logger.LogDebug($"{traceID} - {a},{b}.");

            return _mathLib.Divide(a, b);
        }
    }
}