using PlaneSpotterBL;
using System.Security.Claims;
using System.Text;

namespace PlaneSpotterApi.Middlewares
{
    /// <summary>
    /// Middleware to implement the functionality of API KEY based authentication to API end points
    /// </summary>
    public class ApiKeyAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        // Dependency Injection
        public ApiKeyAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Prevents accesing of the api methods if the configured api key is not available in headers of the request.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(Constants.ApiAuthKey);

            if (!context.Request.Headers.TryGetValue(Constants.ApiAuthKey, out var apiKeyVal) || !apiKey.Equals(apiKeyVal))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized User");
            }

            await _next(context);
        }
    }
}
