using Newtonsoft.Json;

namespace TolgaTheApiWizard.Models
{

    public partial class FacebookError
    {
        [JsonProperty("error")]
        public FacebookErrorInformation Error { get; set; }
    }

    public partial class FacebookErrorInformation
    {
        [JsonProperty("error_subcode")]
        public long ErrorSubcode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("fbtrace_id")]
        public string FbtraceId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
