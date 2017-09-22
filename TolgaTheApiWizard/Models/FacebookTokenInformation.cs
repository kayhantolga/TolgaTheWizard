using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TolgaTheApiWizard.Models
{

    public partial class FacebookToken
    {
        [JsonProperty("data")]
        public FacebookTokenInformation Data { get; set; }
    }

    public partial class FacebookTokenInformation
    {
        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }

        [JsonProperty("application")]
        public string Application { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("expires_at")]
        public long ExpiresAt { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }

}
