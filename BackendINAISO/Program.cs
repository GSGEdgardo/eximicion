using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using backendINAISO.Data;
using System.Text.Json.Serialization; // Asegúrate de ajustar esto según la ubicación real de tu contexto

var builder = WebApplication.CreateBuilder(args);

// Cargar la configuración desde appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

builder.Services.AddDbContext<INAISOContextDB>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios al contenedor
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();


var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    // Swagger y otras configuraciones de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseCors("AllowLocalhost3000");

app.Run("http://localhost:5099");
