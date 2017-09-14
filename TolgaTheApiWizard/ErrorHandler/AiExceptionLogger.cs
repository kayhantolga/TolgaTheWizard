using System.Web.Http.ExceptionHandling;
using Microsoft.ApplicationInsights;

namespace TolgaTheApiWizard.ErrorHandler
{
    public partial class AiExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            if (context?.Exception != null)
            {
                var ai = new TelemetryClient();
                ai.TrackException(context.Exception);
            }
            base.Log(context);
        }
    }
}
