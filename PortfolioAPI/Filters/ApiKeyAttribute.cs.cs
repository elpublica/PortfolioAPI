using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PortfolioAPI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "X-Api-Key";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = configuration.GetValue<string>("ApiKey");

            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "No se proporcionó una API Key (X-Api-Key header missing)"
                };
                return;
            }

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "Acceso denegado: La API Key es incorrecta"
                };
                return;
            }

            await next();
        }
    }
}