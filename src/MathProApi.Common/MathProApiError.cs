using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathProApi.Common
{
    /// <summary>
    /// API error.
    /// </summary>
    public class MathProApiError
    {
        /// <summary>
        /// Customer provided reference number.
        /// </summary>
        public string CustomerReferenceNumber { get; set; }

        /// <summary>
        /// AQMD trace ID.
        /// </summary>
        public string TraceID { get; set; }

        /// <summary>
        /// Error code.
        /// </summary>
        public MathProApiErrorCode Code { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        public string Message { get; set; }
    }
}
