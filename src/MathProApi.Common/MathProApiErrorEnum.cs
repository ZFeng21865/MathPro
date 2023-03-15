using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathProApi.Common
{
    /// <summary>
    /// Error enumeration.
    /// </summary>
    public enum MathProApiErrorEnum
    {
        /// <summary>
        /// Operand is invalid.
        /// </summary>
        InvalidOperand = 40001,

        /// <summary>
        /// Authentication error.
        /// </summary>
        AuthenticationError = 40101,

        /// <summary>
        /// Something unexception happened.
        /// </summary>
        ServerError = 50001

    }
}
