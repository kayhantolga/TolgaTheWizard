namespace TolgaTheWizard.ErrorHandler
{

    public static partial class ErrorCodes
    {
        public static Error AlreadyExist = new Error() { Code = "0X0001", DeveloperMessage = "Already Exist", UserFriendlyMessage = "The source is already exist" };
        public static readonly Error UnknownFileExtension = new Error() { Code = "0X0002", DeveloperMessage = "Only Allowed File Types", UserFriendlyMessage = "" };

        public static readonly Error AccessDenied = new Error() { Code = "0X0403", DeveloperMessage = "AccessDenied", UserFriendlyMessage = "Access Denied" };
        public static readonly Error NotFound = new Error() { Code = "0X0404", DeveloperMessage = "Source Not Found", UserFriendlyMessage = "" };
        public static readonly Error UserNotFound = new Error() { Code = "0X0008", DeveloperMessage = "User Not Found", UserFriendlyMessage = "User Not Found" };
        public static readonly Error FileNotFound = new Error() { Code = "0X0009", DeveloperMessage = "File Not Found", UserFriendlyMessage = "File Not Found" };
        public static readonly Error UnknownError = new Error() { Code = "0X0010", DeveloperMessage = "Unknown Server error", UserFriendlyMessage = "Unknown Server error" };

        public static readonly Error nulli = new Error() { Code = "1X002", DeveloperMessage = "", UserFriendlyMessage = "" };
    }
}
