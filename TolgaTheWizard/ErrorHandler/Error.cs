using System;
using System.Collections.Generic;
using System.Linq;

namespace TolgaTheWizard.ErrorHandler
{
    [Serializable]
    public partial class Error : Exception
    {
        public string Code { get; set; }
        public string UserFriendlyMessage { get; set; }
        public string DeveloperMessage { get; set; }


        public Error(string errorMessage)
        {
            DeveloperMessage = errorMessage;
        }

        public Error()
        {
        }

        public Error(IEnumerable<string> resultErrors)
        {
            DeveloperMessage = resultErrors.FirstOrDefault();
        }
    }
}
