using System.Threading;
using System.Web.Http.Filters;
using TolgaTheWizard.ErrorHandler;

namespace TolgaTheApiWizard.ErrorHandler
{
    public class GlobalErrorHandler : ExceptionFilterAttribute
    {
        public override async void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is Error error)
            {
                var result = new BadRequestErrorResult(error);
                context.Response = await result.ExecuteAsync(new CancellationToken());
            }
        }
    }
}
