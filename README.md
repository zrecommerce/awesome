Awesome messaging app
=====================
The back-end REST API service (AwesomeCore) is built upon the Microsoft C# .NET Core 1.0

You will need the `dotnet` tools provided by Microsoft for your OS of choice.


## Version 0.0.1 ##
 * It implements the following security mechanisms: ACLs, Authorization (OAuth2), AntiForgery, SSL connections
 * It uses the following performance features: WebSockets, Caching, Partial updates (HTTP PATCH)
 * It has the following usability features: Swagger documentation generator (via Swashbuckle)
 * It follows the following scalability features: RESTful design (see Richardson Maturity Model), Entity Framework 7 (ORM) database models, CORS (Cross-origin Requests)

When deploying, please note: non-development mode requires an actuall SSL setup. Thanks to LetsEncrypt.org, there is no longer any excuse to avoid such an important safety feature.


## How To Run ##

Use your shell, and navigate to awesome/AwesomeCore/src/AwesomeCore
Run the following command to build:

```
dotnet build
```

If this is the first time you are running the Awesome messaging app on your machine, you will need to initialize the sample Sqlite3 database:

```
dotnet ef database update Initial
```

Now, run the app with the following command (or simply run via Visual Studio 2015):

```
dotnet run
```