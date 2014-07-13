using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Radiostr.Web.Filters
{
    // http://www.asp.net/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api
    public class ModelValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                var response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);

                actionContext.Response = response;
            }
        }
    }
}