using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathProApi.Common
{
    /// <summary>
    /// The API response.
    /// </summary>
    public class BigNumberCalculatorResponse
    {
        /// <summary>
        /// Customer provided reference number
        /// </summary>
        public string CustomerReferenceNumber { get; set; } = string.Empty;

        /// <summary>
        /// Tracking number for the service call.
        /// </summary>
        public string TraceID { get; set;} = string.Empty;

        /// <summary>
        /// Calculation result.
        /// </summary>
        public string CalculationResult { get; set; }
    }
}
