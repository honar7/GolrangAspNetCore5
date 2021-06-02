using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterSamples.Filters
{
    public class MyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {            
            base.OnException(context);
        }
    }
}
