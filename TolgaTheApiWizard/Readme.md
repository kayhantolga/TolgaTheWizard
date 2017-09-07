# Tolga The Api Wizard

The projects here can be useful to speed up your day-to-day business. <br>
This codes are not suitiable for production  because they are built and updated quickly, and not tested.

### Installing 

```
-Install-Package Betalgo.TolgaTheApiWizard 
```

## Code Examples
#### Swagger Header Parameter
Add your pages to an enum
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
