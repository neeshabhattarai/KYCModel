using System.Net;

namespace FirstApplicationClass.Middlerware
{
    public class ExceptionHandlerGlobally
    {
        private readonly ILogger<ExceptionHandlerGlobally> logger;
        private readonly RequestDelegate request;

        public ExceptionHandlerGlobally(ILogger<ExceptionHandlerGlobally> logger,RequestDelegate request)
        {
            this.logger = logger;
            this.request = request;
        }
       public async Task InvokeAsync(HttpContext context)
        {
            try
            {
              await  request(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                var message =$"{Guid.NewGuid().ToString()}:{ex.Message}";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
              await  context.Response.WriteAsJsonAsync(message);
            }
        }
    }
}
