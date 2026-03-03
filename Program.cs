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

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();
app.Run();