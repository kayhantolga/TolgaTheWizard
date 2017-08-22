using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FacebookAccountKit.ResponseModels;
using TolgaTheWizard.ErrorHandler;

namespace FacebookAccountKit
{
    /// <summary>
    /// Facebook Acccoun Kit.
    /// Currently it can only be used for sms validation.
    /// !Remember to call the "GetTokenAsync" method after creating the obesity.This part will be designed more smoothly.
    /// </summary>
    public class FacebookAccountKitSdk
    {
        private AccountKitToken Token { get; set; }
        private readonly HttpClient _client = new HttpClient();
        private const string BaseUrl = "https://graph.accountkit.com/v1.2/";
        private string _appAccessToken;
        private readonly string _facebookAppId;
        private readonly string _accountKitSecret;

        /// <summary>
        /// Initialize with keys
        /// </summary>
        /// <param name="facebookAppId">Facebook App Id</param>
        /// <param name="accountKitSecret">Facebook Accoun kit secret !!!NOT FACEBOOK APP SECRET!!!</param>
        public FacebookAccountKitSdk(string facebookAppId, string accountKitSecret)
        {
            _facebookAppId = facebookAppId;
            _accountKitSecret = accountKitSecret;
            Init();
        }
        /// <summary>
        /// Initialize without keys 
        /// The keys will be retrieved from appconfig or webconfig.Don't forget to set appsetting => "AccountKitFacebookAppId" "AccountKitAppSecret"
        /// </summary>
        public FacebookAccountKitSdk()
        {
            _facebookAppId = ConfigurationManager.AppSettings["AccountKitFacebookAppId"];
            _accountKitSecret = ConfigurationManager.AppSettings["AccountKitAppSecret"];
            Init();
        }

        private void Init()
        {
            if (string.IsNullOrEmpty(_facebookAppId) || string.IsNullOrEmpty(_accountKitSecret))
            {
                throw new NullReferenceException("FacebookAppId and AccountKitSecret can not be null");
            }
            _appAccessToken = $"AA|{_facebookAppId}|{_accountKitSecret}";

            _client.BaseAddress = new Uri(BaseUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Get Token from AuthorizationCode
        /// </summary>
        /// <param name="authorizationCode"></param>
        /// <returns></returns>
        public async Task<string> GetTokenAsync(string authorizationCode)
        {
            const string path = "access_token";
            var uri = new UriBuilder(BaseUrl + path);
            var query = new NameValueCollection
            {
                {"grant_type", "authorization_code"},
                {"code", authorizationCode},
                {"access_token", _appAccessToken},
            };
            uri.Query = query.ToQueryString();
            var response = await _client.GetAsync(uri.ToString());
            if (response.IsSuccessStatusCode)
            {
                Token = await response.Content.ReadAsAsync<AccountKitToken>();
                return Token.access_token;
            }
            var responseError = await response.Content.ReadAsStringAsync();
            throw new Error(responseError);
        }

        /// <summary>
        /// Get User Basic Informations
        /// </summary>
        /// <returns></returns>
        public async Task<UserInformation> GetUserInformationAsync()
        {
            const string path = "me";

            var uri = new UriBuilder(BaseUrl + path);
            var query = new NameValueCollection
                {
                    {"access_token", Token.access_token},
                };
            uri.Query = query.ToQueryString();
            var response = await _client.GetAsync(uri.ToString());
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<UserInformation>();
                return result;
            }
            var responseError = await response.Content.ReadAsStringAsync();
            throw new Error(responseError);
        }

        /// <summary>
        /// Validate is Phone number and appId belongs to the given token.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public async Task<bool> ValidateUserAsync(string phoneNumber)
        {
            var userInfo = await GetUserInformationAsync();
            if (phoneNumber != userInfo.phone.number)
            {
                return false;
            }
            if (userInfo.application.id != _facebookAppId)
            {
                return false;
            }
            return true;
        }

    }

}
