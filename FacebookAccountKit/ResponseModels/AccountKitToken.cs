namespace FacebookAccountKit.ResponseModels
{
    public class AccountKitToken
    {
        public string id { get; set; }
        public string access_token { get; set; }
        public int token_refresh_interval_sec { get; set; }
    }
}
