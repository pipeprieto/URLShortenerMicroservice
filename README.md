# URLShortenerMicroservice
This is an API which receives a valid url, build a new short url and store the info on a database provider using .NET EntityFramework scaffolding.

## Configuration
In order to make this API work on your computer, you must configure your connection string to your choosed provider on a `appsettings.json` file and then specify on your `program.cs` file how you are going to do the connection following the next example.

### appsettings.json
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    //PostgreSQL
    "{your connection string variable}":"User Id={DBUser}; Password={DBpassword}; Host={HOST}; Port={DBPort}; Database={DBName};"
  }
}
```
### Program.cs
``` 
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("{Your connection string variable}");
builder.Services.AddDbContext<URLDbContext>(options=> options.UseNpgsql(connectionString)); 
builder.Services.AddScoped<URLService>();
```
In this case the API is connecting to a PostgreSQL provider so make sure to configure a right connection string to your database provider. You can read more on [MirosoftDocs](https://learn.microsoft.com/en-us/ef/core/what-is-new/nuget-packages)

## Build
Use the command `dotnet build` in visual studio code integrated terminal to compile the app.

## Run the API
Use the command `dotnet run` in visual studio code integrated terminal to run the app on your localhost.

## Swagger DOCS
visit `http://localhost:{PORT}/swagger/index.html` to read the documentation and test the API.