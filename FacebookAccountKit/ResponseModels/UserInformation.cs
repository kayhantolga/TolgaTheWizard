namespace FacebookAccountKit.ResponseModels
{
  
    public class Phone
    {
        public string number { get; set; }
        public string country_prefix { get; set; }
        public string national_number { get; set; }
    }

    public class Application
    {
        public string id { get; set; }
    }

    public class UserInformation
    {
        public string id { get; set; }
        public Phone phone { get; set; }
        public Application application { get; set; }
    }
}
