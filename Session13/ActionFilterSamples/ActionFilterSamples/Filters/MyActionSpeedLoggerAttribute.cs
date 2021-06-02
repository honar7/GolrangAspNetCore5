using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFilterSamples.Filters
{
    public interface IServiceTest
    {

    }
    public class MyActionSpeedLoggerAttribute : ActionFilterAttribute
    {
        public MyActionSpeedLoggerAttribute(IServiceTest serviceTest)
        {

        }
        private Stopwatch timer;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string result = $"Action Elapsed time:{timer.Elapsed.TotalMilliseconds} ms";
            Console.WriteLine(result);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
         
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
           
        }

    }
}
