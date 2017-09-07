# Tolga The Api Wizard

The projects here can be useful to speed up your day-to-day business. <br>
This codes are not suitiable for production  because they are built and updated quickly, and not tested.

### Installing 

```
-Install-Package Betalgo.TolgaTheApiWizard 
```

## Code Examples
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


