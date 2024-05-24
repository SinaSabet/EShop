using EShop.Api.Meters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EShop.Api.Filters
{
    public class SuccessfulApiRequestTrackingFilter : IActionFilter
    {
        private readonly SuccessfulApiMeter _successMeter;

        public SuccessfulApiRequestTrackingFilter()
        {
            _successMeter = new SuccessfulApiMeter();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                _successMeter.TrackSuccessfulApiRequest(context.HttpContext, context.HttpContext.Request.Path);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
