using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using TolgaTheApiWizard.ErrorHandler.Model;
using TolgaTheWizard.ErrorHandler;

namespace TolgaTheApiWizard.ErrorHandler
{
    public class BadRequestErrorResult : IHttpActionResult
    {
        private readonly ErrorViewModel _error;

        public BadRequestErrorResult(Error model)
        {
            _error = new ErrorViewModel(model);
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent(typeof(ErrorViewModel), _error, new JsonMediaTypeFormatter())
            };
            return Task.FromResult(response);
        }
    }
}
