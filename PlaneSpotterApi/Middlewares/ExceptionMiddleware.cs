using Microsoft.AspNetCore.Http;
using PlaneSpotterApi.Controllers;
using System.Net;
using System.Text.Json;

namespace PlaneSpotterApi.Middlewares
{
    /// <summary>
    /// Handling API Exceptions. Whenever an exception is thrown inside the api code, this will be invoked.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _environment;
        private readonly RequestDelegate _nextRequest;

        /// <summary>
        /// objects for logger, hosting environment and next request in the pipeline is injected
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="environment"></param>
        /// <param name="nextRequest"></param>
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, IHostEnvironment environment, RequestDelegate nextRequest)
        {
            _logger = logger;
            _environment = environment;
            _nextRequest = nextRequest;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _nextRequest(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = int.Parse(HttpStatusCode.InternalServerError.ToString());

                //Return different api error based on the environment
                var httpResponse = _environment.IsDevelopment() ?
                    new ApiErrorResponse(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString()) :
                    new ApiErrorResponse(context.Response.StatusCode, "Internal Server Error, please contact your system administrator");

                _logger.Log(LogLevel.Error, ex.Message, ex.StackTrace);

                await context.Response.WriteAsync(httpResponse.GetJsonResponse(httpResponse));

            }

        }

        /// <summary>
        /// Api response type
        /// </summary>
        public class ApiErrorResponse
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public string StackTrace { get; set; }
            public ApiErrorResponse(int statusCode, string message = "", string stackTrace = "")
            {
                StatusCode = statusCode;
                Message = message;
                StackTrace = stackTrace;
            }

            public string GetJsonResponse(ApiErrorResponse httpResponse)
            {
                return JsonSerializer.Serialize(httpResponse);
            }
        }
    }
}
