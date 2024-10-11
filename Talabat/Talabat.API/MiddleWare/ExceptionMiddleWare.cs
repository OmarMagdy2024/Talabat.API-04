using System.Net;
using System.Text.Json;
using Talabat.API.Errors;

namespace Talabat.API.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IWebHostEnvironment _environment;

        public ExceptionMiddleWare(RequestDelegate next,ILogger<ExceptionMiddleWare> logger,IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public IWebHostEnvironment Environment { get; }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var error =_environment.IsDevelopment()?
                     new ExceptionError((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                : new ExceptionError((int)HttpStatusCode.InternalServerError);
                var option= new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                var json = JsonSerializer.Serialize(error,option);
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}
