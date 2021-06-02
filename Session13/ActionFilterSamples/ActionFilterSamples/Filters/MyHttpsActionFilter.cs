using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterSamples.Filters
{
    public class MyHttpsActionFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.IsHttps)
            {
                context.Result = new StatusCodeResult(400);
            }
        }
    }
}
