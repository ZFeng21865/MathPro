using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathProApi.Common
{
    /// <summary>
    /// Error enumeration.
    /// </summary>
    public enum MathProApiErrorCode
    {
        /// <summary>
        /// Model state validation error.
        /// </summary>
        [Description("Input is not in valid format")] InvalidInput = 40000,

        /// <summary>
        /// Operand is invalid.
        /// </summary>
        [Description("Invalid operand")] InvalidOperand = 40001,

        /// <summary>
        /// Authentication error.
        /// </summary>
        [Description("Invalid username or password")] AuthenticationError = 40101,

        /// <summary>
        /// Authentication error.
        /// </summary>
        [Description("Authenticated user is not authorized for the API")] AuthorizationError = 40301,

        /// <summary>
        /// Something unexception happened.
        /// </summary>
        [Description("Service side error")] ServerError = 50001

    }
}
