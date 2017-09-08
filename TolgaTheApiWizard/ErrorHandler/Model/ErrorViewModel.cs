using TolgaTheWizard.ErrorHandler;

namespace TolgaTheApiWizard.ErrorHandler.Model
{
    public class ErrorViewModel
    {
        public ErrorViewModel(Error error)
        {
            Code = error.Code;
            DeveloperMessage = error.DeveloperMessage;
            UserFriendlyMessage = error.UserFriendlyMessage;
        }
        public string Code { get; set; }
        public string UserFriendlyMessage { get; set; }
        public string DeveloperMessage { get; set; }
    }
}
