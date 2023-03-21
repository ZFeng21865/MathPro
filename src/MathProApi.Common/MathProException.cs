using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathProApi.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class MathProException : Exception
    {
        public MathProApiErrorCode Code;

        /// <summary>
        /// 
        /// </summary>
        public MathProException()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="err"></param>
        public MathProException(string err)
            :base(err)
        {
            Code = MathProApiErrorCode.ServerError;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public MathProException(MathProApiErrorCode code, string message = "")
            :base(message)
        {
            Code = code;
        }

        /// <summary>
        /// Generate exception detail message.
        /// </summary>
        /// <returns></returns>
        public string GetExceptionDetail()
        {
            var description = typeof(MathProApiErrorCode)
                    .GetMember(Code.ToString())
                    .First()?.GetCustomAttribute<DescriptionAttribute>()?.Description;

            return string.Format(CultureInfo.InvariantCulture, "{0}{1}", description, string.IsNullOrEmpty(Message) ? "" : "-" + Message);
        }
    }
}
