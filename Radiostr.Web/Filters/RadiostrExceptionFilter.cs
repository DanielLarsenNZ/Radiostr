using System.Web.Http.Filters;
using Scale.Logger;

namespace Radiostr.Web.Filters
{
    // http://www.asp.net/web-api/overview/web-api-routing-and-actions/exception-handling
    public class RadiostrExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var log = new LoggerRegistry().Logger("Radiostr.Web");
            log.Error(context.Exception);
            base.OnException(context);
        }
    }
}