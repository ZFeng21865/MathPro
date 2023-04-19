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
    [Produces("application/json")]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BigNumberCalculatorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MathProApiError))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(MathProApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MathProApiError))]
        public async Task<IActionResult> Add([FromBody] BigNumberCalculationRequest request)
        {
            string traceID = Guid.NewGuid().ToString();
            _logger.LogTrace($"{traceID} - START Add");

            _logger.LogTrace($"{traceID} - Customer reference number: {request.CustomerReferenceNumber}");

            try
            {
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
            catch (MathProException ex)
            {
                _logger.LogError($"{traceID} - BigNumber Add POST error: {ex.Code}-{ex.GetExceptionDetail()}");
                return HttpHelper.GetStatusCodeFromException(ex, this, traceID, request.CustomerReferenceNumber);
            }
            catch(ApplicationException ex)
            {
                _logger.LogError($"{traceID} - Application exception: {ex.ToString()}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MathProApiError
                    {
                        TraceID = traceID,
                        CustomerReferenceNumber = request.CustomerReferenceNumber,
                        Code = MathProApiErrorCode.ServerError,
                        Message = "Unknown error"
                    });
            }
        }

        /// <summary>
        /// Subtraction of two big numbers.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Subtract")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BigNumberCalculatorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MathProApiError))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(MathProApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MathProApiError))]
        public async Task<IActionResult> Subtract([FromBody] BigNumberCalculationRequest request)
        {
            string traceID = Guid.NewGuid().ToString();
            _logger.LogTrace($"{traceID} - START Subtract");

            _logger.LogTrace($"{traceID} - Customer reference number: {request.CustomerReferenceNumber}");

            try
            {
                var sum = await Task.FromResult(_mathLib.Subtract(request.Num1, request.Num2));
                BigNumberCalculatorResponse resp = new BigNumberCalculatorResponse
                {
                    TraceID = traceID,
                    CustomerReferenceNumber = request.CustomerReferenceNumber,
                    CalculationResult = sum
                };

                _logger.LogTrace($"{traceID} - END Add");

                return Ok(resp);
            }
            catch (MathProException ex)
            {
                _logger.LogError($"{traceID} - BigNumber Add POST error: {ex.Code}-{ex.GetExceptionDetail()}");
                return HttpHelper.GetStatusCodeFromException(ex, this, traceID, request.CustomerReferenceNumber);
            }
            catch (ApplicationException ex)
            {
                _logger.LogError($"{traceID} - Application exception: {ex.ToString()}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MathProApiError
                    {
                        TraceID = traceID,
                        CustomerReferenceNumber = request.CustomerReferenceNumber,
                        Code = MathProApiErrorCode.ServerError,
                        Message = "Unknown error"
                    });
            }
        }

        [HttpPost("Multiply")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BigNumberCalculatorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MathProApiError))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(MathProApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MathProApiError))]
        public async Task<IActionResult> Multiply([FromBody] BigNumberCalculationRequest request)
        {
            string traceID = Guid.NewGuid().ToString();
            _logger.LogTrace($"{traceID} - START Multiply");

            _logger.LogTrace($"{traceID} - Customer reference number: {request.CustomerReferenceNumber}");

            try
            {
                var sum = await Task.FromResult(_mathLib.Multiply(request.Num1, request.Num2));
                BigNumberCalculatorResponse resp = new BigNumberCalculatorResponse
                {
                    TraceID = traceID,
                    CustomerReferenceNumber = request.CustomerReferenceNumber,
                    CalculationResult = sum
                };

                _logger.LogTrace($"{traceID} - END Multiply");

                return Ok(resp);
            }
            catch (MathProException ex)
            {
                _logger.LogError($"{traceID} - BigNumber Multiply POST error: {ex.Code}-{ex.GetExceptionDetail()}");
                return HttpHelper.GetStatusCodeFromException(ex, this, traceID, request.CustomerReferenceNumber);
            }
            catch (ApplicationException ex)
            {
                _logger.LogError($"{traceID} - Application exception: {ex.ToString()}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MathProApiError
                    {
                        TraceID = traceID,
                        CustomerReferenceNumber = request.CustomerReferenceNumber,
                        Code = MathProApiErrorCode.ServerError,
                        Message = "Unknown error"
                    });
            }
        }
    }
}
