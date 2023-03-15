using IMathLib;
using MathProApi.Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MathProApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BigNumberController : ControllerBase
    {
        private readonly ILogger<BasicController> _logger;
        private readonly IMyMathLib _mathLib;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mathLib"></param>
        public BigNumberController(ILogger<BasicController> logger, IMyMathLib mathLib)
        {
            _logger = logger;
            _mathLib = mathLib;
        }

        /// <summary>
        /// Add two large numbers.
        /// </summary>
        /// <param name="request">The request including both operand and customer reference number.</param>
        /// <returns>The sum of two large numbers</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Add
        ///     {
        ///        "customerReferenceNumber": "abc-123",
        ///        "num1": "123456654654657894651684104564635416",
        ///        "num2": "1111"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the sum along with trace ID</response>
        /// <response code="400">Invalid input</response>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] BigNumberCalculationRequest request)
        {
            string traceID = Guid.NewGuid().ToString();
            _logger.LogTrace($"{traceID} - START Add");

            _logger.LogTrace($"{traceID} - Customer reference number: {request.CustomerReferenceNumber}");

            var sum = await Task.FromResult(_mathLib.Add(request.Num1, request.Num2));
            BigNumberCalculatorResponse resp = new BigNumberCalculatorResponse
            {
                TraceID = traceID,
                CustomerReferenceNumber = request.CustomerReferenceNumber,
                CalculationResult = sum
            };

            _logger.LogTrace($"{traceID} - END Add");
            return Ok(resp);
        }
    }
}
