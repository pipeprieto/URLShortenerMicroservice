using URLShortenerMicroservice.DB;
using URLShortenerMicroservice.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<URLDbContext>(options=> options.UseNpgsql(connectionString)); //Agregar cadena de conexión en el appsettings.json
builder.Services.AddScoped<URLService>();

//dotnet ef migrations add firstMigration --project URLShortenerMicroservice.csproj
//dotnet ef database update firstMigration --project URLShortenerMicroservice.csproj

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json","URL Shortener Microservice"));
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Map("/",()=>@"URL Shortener Microservice. Navigate to /swagger to open the Swagger test UI");

app.Run();
