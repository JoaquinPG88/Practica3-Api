using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Practica3.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// 1) Registrar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Practica3 API – PatientCode",
        Version = "v1"
    });
});

var app = builder.Build();

// 2) Habilitar Swagger UI (sin condicional de entorno)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practica3 API V1");
    c.RoutePrefix = string.Empty; // opcional: lo expone en '/'
});

// 3) Routing y MapControllers
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
