using IMathLib;
using MathProApi.Common;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Numerics;

namespace MathLib
{
    /// <summary>
    /// 
    /// </summary>
    public class MyMathLib : IMyMathLib
    {        
        public static readonly double Pi = 3.1415927;

        private readonly ILogger<MyMathLib> _logger;

        public MyMathLib(ILogger<MyMathLib> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Calculate area of circle.
        /// </summary>
        /// <param name="radius">The radius of the circle</param>
        /// <param name="angle">Full circle if 360, or slice otherwise.</param>
        /// <returns></returns>
        public double CalculateCircleArea(double radius, double angle)
        {
            return MyMathLib.Pi * radius * radius * (angle == 360 ? 1.0 : ((angle % 360) / 360));
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public decimal Add(decimal a, decimal b)
        {
            _logger.LogTrace("Start Add");
            _logger.LogDebug($"{a},{b}");

            var result = a + b;

            _logger.LogDebug($"Result: {result}");
            _logger.LogTrace("End Add");
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public decimal Subtract(decimal a, decimal b)
        {
            return a - b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public decimal Multiply(decimal a, decimal b)
        {
            return a * b;
        }

        /// <summary>
        /// Provide division operation.
        /// </summary>
        /// <param name="a">Dividend</param>
        /// <param name="b">Divisor</param>
        /// <returns>The result of a/b.</returns>
        public decimal Divide(decimal a, decimal b)
        {
            try
            {
                return a / b;
            }
            catch(DivideByZeroException ex)
            {
                _logger.LogError($"Exception in Divide: {ex.Message}-{ex.InnerException?.Message}");
                throw new MathProException(MathProApiErrorCode.InvalidOperand, "divisor can't be zero");
            }
        }

        public string Add(string a, string b)
        {
            if(!BigInteger.TryParse(a, NumberStyles.Number, CultureInfo.InvariantCulture, out BigInteger num1))
            {
                throw new MathProException(MathProApiErrorCode.InvalidOperand, a);
            }

            if (!BigInteger.TryParse(b, NumberStyles.Number, CultureInfo.InvariantCulture, out BigInteger num2))
            {
                throw new MathProException(MathProApiErrorCode.InvalidOperand, b);
            }

            var sum = num1 + num2;
            return sum.ToString();
        }

        public string Subtract(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string Multiply(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string Divide(string a, string b)
        {
            throw new NotImplementedException();
        }
    }
}