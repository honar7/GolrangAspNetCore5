using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;

namespace ActionFilterSamples.Filters
{
    public class MyResultSpeedLoggerAttribute : ResultFilterAttribute
    {
        private Stopwatch timer;
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            
            timer.Stop();
            string result = $"Result Elapsed time:{timer.Elapsed.TotalMilliseconds} ms";
            Console.WriteLine(result);
        }


    }
}
