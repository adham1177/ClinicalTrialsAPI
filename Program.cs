using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ClinicalTrialsAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = 
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=clinicaltrials.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.Servers = new[]
    {
        new ScalarServer("https://clinical-trials-api.azurewebsites.net"),
        new ScalarServer("http://localhost:5067")
    };
});

app.MapControllers();
app.Run();