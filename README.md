ASP.NET SimpleIdentity
======================

A simple ASP.NET 5 authentication and identity provider, ideal for smaller websites. Valid users are specified in a simple configuration file rather than a database.

Bug reports and feature requests are welcome!

Installation
============

If you are creating a brand new ASP.NET 5 web application, ensure you select "No Authentication" when creating it.

Install NuGet package:
```
Install-Package Daniel15.SimpleIdentity
```

Create configuration. SimpleIdentity uses the [standard ASP.NET configuration library](http://docs.asp.net/en/latest/fundamentals/configuration.html). Running `Daniel15.SimpleIdentity.Setup` will allow you to enter a email address and password, and output the required config section. An example using `user@example.com` as the email address and `password` as the password:

```json
    "Auth": {
        "Users": {
            "USER@EXAMPLE.COM": {
                "Email": "user@example.com",
                "NormalizedUserName": "USER@EXAMPLE.COM",
                "PasswordHash": "AQAAAAEAACcQAAAAEJOYL0MGZ5CNnERvqzI2Wl9eJLXMsuchKP1EIWGQneZ1GuNCjheC4pD1AWgVy+decQ=="
            }
        }
    }
```

Place this in any config file (for example, `config.json`). In a production scenario, you will want to store this in a separate config file that's not checked in to source control.

Configure SimpleIdentity in `Startup.cs`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Add Identity services to the services container.
    services.AddIdentity<SimpleIdentityUser, SimpleIdentityRole>()
        .AddSimpleIdentity<SimpleIdentityUser>(Configuration.GetConfigurationSection("Auth"))
        .AddDefaultTokenProviders();
```

Enable identity services by adding this before `app.UseMvc`:
```csharp
// Add cookie-based authentication to the request pipeline.
app.UseIdentity();
```

Create login form. Some example files are included, based off the regular ASP.NET authentication:
 - [ViewModels/LoginViewModel.cs](https://github.com/Daniel15/SimpleIdentity/blob/master/src/Daniel15.SimpleIdentity.Sample/ViewModels/LoginViewModel.cs)
 - [Controllers/AccountController.cs](https://github.com/Daniel15/SimpleIdentity/blob/master/src/Daniel15.SimpleIdentity.Sample/Controllers/AccountController.cs)
 - [Views/Account/Login.cshtml](https://github.com/Daniel15/SimpleIdentity/blob/master/src/Daniel15.SimpleIdentity.Sample/Views/Account/Login.cshtml)
 - [Views/Shared/_LoginPartial.cshtml](https://github.com/Daniel15/SimpleIdentity/blob/master/src/Daniel15.SimpleIdentity.Sample/Views/Shared/_LoginPartial.cshtml)

Hit `/Account/Login` and it should work :)

For a full example, see the included [sample project](https://github.com/Daniel15/SimpleIdentity/blob/master/src/Daniel15.SimpleIdentity.Sample/).

Changelog
=========
1.0 - 8th August 2015
-------------------------
 - Initial release
