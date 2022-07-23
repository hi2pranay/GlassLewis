using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GlassLewis.API
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private ILogger<ExceptionFilter> _Logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _Logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _Logger.LogError(new EventId(0), context.Exception, "An unhandled error occurred.");

            context.Exception = null;
            context.Result = new JsonResult("An unhandled error occurred.");
        }
    }
}
