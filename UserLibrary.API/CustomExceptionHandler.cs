using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UserLibrary.Application.Common.Exceptions;

namespace UserLibrary.API
{
    /// <summary>
    /// Exception handler for all custom exceptions
    /// </summary>
    public class CustomExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// CustomExceptionHandler implementation
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is EntityNotFoundException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

                await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
                {
                    Status = StatusCodes.Status404NotFound,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                    Title = "The specified resource was not found.",
                    Detail = exception.Message
                });
                return true;
            }

            return false;
        }
    }
}