# Facebook Account Kit SDK

This project uses sms validation using facebook account kit. Not suitable for production environment. Remember to check before using the codes.

## Code Example

```csharp
FacebookAccountKitSdk facebookAccountKitSdk = new FacebookAccountKitSdk("MyFacebookAppId", "MyFacebookAccountKitSecretKey");
var result =await facebookAccountKitSdk.GetTokenAsync("MyClientAuthCode");
var userInformation =await facebookAccountKitSdk.GetUserInformationAsync();
var isValidated = facebookAccountKitSdk.ValidateUserAsync("+015551234567");
```

## Installing 

```
-Install-Package Betalgo.FacebookAccountKit 
```

