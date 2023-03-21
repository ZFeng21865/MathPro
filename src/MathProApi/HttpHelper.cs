using MathProApi.Common;
using Microsoft.AspNetCore.Mvc;

namespace MathProApi
{
    /// <summary>
    /// Helper class for HTTP error handling.
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// Translate MathProException to HTTP Error.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="controller"></param>
        /// <param name="traceID"></param>
        /// <param name="custRefID"></param>
        /// <returns></returns>
        public static ObjectResult GetStatusCodeFromException(MathProException ex, ControllerBase controller, string traceID, string custRefID)
        {
            if (ex == null)
            {
                return controller.StatusCode(StatusCodes.Status500InternalServerError,
                    new MathProApiError
                    {
                        Code = MathProApiErrorCode.ServerError,
                        Message = "Server error",
                        TraceID = traceID,
                        CustomerReferenceNumber = custRefID
                    });
            }

            int code = ((int)ex.Code / 100);
            int statusCode = StatusCodes.Status500InternalServerError;

            switch(code)
            {
                case 400:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;

                case 401:
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;

                case 403:
                    statusCode = StatusCodes.Status403Forbidden;
                    break;
            }

            return controller.StatusCode(statusCode,
                new MathProApiError
                {
                    Code = ex.Code,
                    Message = ex.GetExceptionDetail(),
                    TraceID = traceID,
                    CustomerReferenceNumber = custRefID
                });
        }
    }
}
