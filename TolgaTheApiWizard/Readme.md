# Tolga The Api Wizard

The projects here can be useful to speed up your day-to-day business. <br>
This codes are not suitiable for production  because they are built and updated quickly, and not tested.

### Installing 

```
-Install-Package Betalgo.TolgaTheApiWizard 
```

## Code Examples
You can find common usage of methods. Also you need to check my base library too
https://github.com/kayhantolga/TolgaTheWizard
#### Swagger Header Parameter
Add header parameters to swagger documentation
```csharp
   public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
...
            var AuthHeader = new SwaggerHeaderParameter
            {
                Description = "Authorization Code",
                Key = "Language",
                Name = "Authorization",
                DefaultValue = "Bearer apGn...Ab8uczk"
            };


            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        AuthHeader.Apply(c);
...
```

#### AiHandleErrorAttribute
Add this codes for track exceptions on Application Insight

```csharp
    //in your FilterConfig class
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.Add(new AiHandleErrorAttribute());
    }
```
#### BadRequestErrorResult
Helps error messages become user and developer friendly.

When you wand to handle ErrorCodes

Add filter in your WebApiConfig class
```csharp

 public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ...
            config.Filters.Add(new GlobalErrorHandler());
            ...         
```
Or use your Controllers like this
```csharp
    /// <summary>
    /// Try to get sample error
    /// </summary>
    [HttpGet, Route("Error/GetError"), ResponseType(typeof(SampleViewModel))]
    public async Task<IHttpActionResult> GetErrorAsync()
    {
        try
        {
            //For sample Error
            throw ErrorCodes.AccessDenied;

            return Ok(new SampleViewModel());
        }
        catch (Error error)
        {
            return new BadRequestErrorResult(error);
        }
    }
```

Sample Response after throw an Error
```json
{
  "Code": "0X0403",
  "UserFriendlyMessage": "Access Denied",
  "DeveloperMessage": "AccessDenied"
}
```
#### Facebook Login from token
if you need to get user information from user accesstoken

```xml
    <appSettings>
        <add key="FacebookLoginAppId" value="123....45" />
        <add key="FacebookLoginAppToken" value="12...ab" />
    </appSettings>
```
```csharp

    try
    {
        FacebookLogin facebook = new FacebookLogin(token);
        //or
        //FacebookLogin facebook = new FacebookLogin(token,myAppID,myAppToken);
        facebook.IncludeBasicInformation().IncludeBirthday().IncludeEmail().IncludeProfilePicture(500, 500).IncludeFriendList();
        if (!await facebook.CheckTokenAsync())
        {
            Console.WriteLine("bad boy");
        }

        var user = await facebook.GetUserInformationsAsync();
        
        Console.WriteLine(user.Name);
        Console.WriteLine(user.Friends.Data.Count);
    }
    catch (Error e)
    {
        Console.WriteLine(e);
        throw;
    }


```

