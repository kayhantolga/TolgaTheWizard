using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using TolgaTheApiWizard.Models;
using TolgaTheWizard.ErrorHandler;

namespace TolgaTheApiWizard
{
    public class FacebookLogin
    {
        private string AccessToken { get; set; }
        private string AppId { get; set; }
        private string AppToken { get; set; }
        private string Fields { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="appId">default: AppSettings["FacebookLoginAppId"]</param>
        /// <param name="appToken">default: AppSettings["FacebookLoginAppToken"]
        /// get your apptoken https://developers.facebook.com/tools/accesstoken/ </param>

        public FacebookLogin(string accessToken, string appId = null, string appToken = null)
        {
            if (string.IsNullOrEmpty(appId))
            {
                appId = ConfigurationManager.AppSettings["FacebookLoginAppId"];
            }
            if (string.IsNullOrEmpty(appToken))
            {
                appToken = ConfigurationManager.AppSettings["FacebookLoginAppToken"];
            }
            AppId = appId;
            AppToken = appToken;
            AccessToken = accessToken;
        }

        /// <summary>
        /// Include basic Informations
        /// fields: id,name,first_name,last_name,gender
        /// </summary>
        /// <returns></returns>
        public FacebookLogin IncludeBasicInformation()
        {
            CheckComma();
            Fields += "id,name,first_name,last_name,gender";
            return this;
        }

        /// <summary>
        /// Include birthday
        /// fields: birthday
        /// </summary>
        /// <returns></returns>
        public FacebookLogin IncludeBirthday()
        {
            CheckComma();
            Fields += "birthday";
            return this;
        }
        /// <summary>
        /// Include email address
        /// fields: email
        /// </summary>
        /// <returns></returns>
        public FacebookLogin IncludeEmail()
        {
            CheckComma();
            Fields += "email";
            return this;
        }

        /// <summary>
        /// Include friend list (It will only bring friends who use your application.)
        /// fields: friends.limit({limit})
        /// </summary>
        /// <returns></returns>
        public FacebookLogin IncludeFriendList(int limit = 100)
        {
            CheckComma();
            Fields += $"friends.limit({limit})";
            return this;
        }
       
        /// <summary>
        /// Include profile picture
        /// fields: picture.width({width}).height({height})
        /// </summary>
        /// <returns></returns>
        public FacebookLogin IncludeProfilePicture(int width, int height)
        {
            CheckComma();
            Fields += $"picture.width({width}).height({height})";
            return this;
        }

        /// <summary>
        /// Add your custom field if it  necessary
        /// </summary>
        /// <param name="field">like: first_name,last_name</param>
        /// <returns></returns>
        public FacebookLogin IncludeCustomField(string field)
        {
            CheckComma();
            Fields += "field";
            return this;
        }
        
        private void CheckComma()
        {
            if (!string.IsNullOrEmpty(Fields))
            {
                Fields += ",";
            }
        }

        /// <summary>
        /// GetInfromation about token
        /// </summary>
        /// <returns></returns>
        public async Task<FacebookTokenInformation> GetTokenInformationAsync()
        {
            var path = $"https://graph.facebook.com/debug_token?" +
                       $"input_token={AccessToken}" +
                       $"&access_token={AppToken}";
            var client = new HttpClient();
            var uri = new Uri(path);
            var response = await client.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookToken>(content).Data;
            }

            var facebookError = Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookError>(content).Error;
            throw new Error()
            {
                Code = "facebook" + " X" + facebookError.Code,
                UserFriendlyMessage = facebookError.Message,
                DeveloperMessage = content
            };
        }

        /// <summary>
        /// Is token valid
        /// Is token belong to my application 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CheckTokenAsync()
        {
            try
            {
                var facebookTokenInformation = await GetTokenInformationAsync();
                return string.Equals(AppId, facebookTokenInformation.AppId, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Get informations about user.
        /// You need use least one include method before the call this method.
        /// </summary>
        /// <returns></returns>
        public async Task<FacebookUserInformation> GetUserInformationsAsync()
        {
            return await GetUserInformationsAsync<FacebookUserInformation>();
        }

        /// <summary>
        /// Get informations about user(if you need to use custom model).
        /// You need use least one include method before the call this method.
        /// </summary>
        /// <returns></returns>
        public async Task<T> GetUserInformationsAsync<T>()
        {
            var path =
                "https://graph.facebook.com/v2.10/me?" +
                $"fields={Fields}" +
                $"&access_token={AccessToken}";
            var client = new HttpClient();
            var uri = new Uri(path);
            var response = await client.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
            }
            var facebookError = Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookError>(content).Error;
            throw new Error()
            {
                Code = "facebook" + "X" + facebookError.Code,
                UserFriendlyMessage = facebookError.Message,
                DeveloperMessage = content
            };
        }

    }
}
