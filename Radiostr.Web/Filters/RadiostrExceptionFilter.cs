using System.Web.Http.Filters;
using Scale.Logger;

namespace Radiostr.Web.Filters
{
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