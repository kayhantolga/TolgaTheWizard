# Tolga The Wizard

The projects here can be useful to speed up your day-to-day business. <br>
This codes are not suitiable for production  because they are built and updated quickly, and not tested.

### Installing 

```
-Install-Package Betalgo.TolgaTheWizard 
```

## Code Examples

#### GenerateRandomUserFriendlyCode

Create UserFriendly Codes

```csharp
    //Only Numeric and default 10 character result
    string mycode1 = TokenHandlers.GenerateRandomUserFriednlyCode();
    //Only Numeric and 6 character result
    string mycode2 = TokenHandlers.GenerateRandomUserFriednlyCode(6);
    //Create from given string characters(repeating characters increase the frequency of use.) 
    //and  default 10 character result
    string mycode3 = TokenHandlers.GenerateRandomUserFriednlyCode("abcd123");
    //Create from given string characters and 8 character result
    string mycode4 = TokenHandlers.GenerateRandomUserFriednlyCode("abcd123",8);
```
 

#### Map object to another

Sample Derived Class
```csharp
    public class DerivedClass:BaseClass
    {
        ...
    }
```

Sample Usage
```csharp
    DerivedClass derived = new DerivedClass();
    BaseClass base =  derived.To<BaseClass>();
```
 