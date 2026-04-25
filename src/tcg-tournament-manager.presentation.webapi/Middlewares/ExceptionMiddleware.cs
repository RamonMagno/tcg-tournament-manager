using tcg_tournament_manager.domain.Shared.Exceptions;

namespace tcg_tournament_manager.presentation.webapi.Configurations
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var statusCode = (int)System.Net.HttpStatusCode.InternalServerError;

                httpContext.Response.StatusCode = statusCode;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(new ExceptionDetails()
                {
                    StatusCode = statusCode,
                    Message = ex.Message,
                    Trace = ex.StackTrace
                }.ToString());
            }
        }
    }
}
