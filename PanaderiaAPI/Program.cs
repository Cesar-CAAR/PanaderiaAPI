using Microsoft.EntityFrameworkCore;
using PanaderiaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar la conexión a PostgreSQL (Neon) y forzar minúsculas
builder.Services.AddDbContext<PanaderiaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .UseLowerCaseNamingConvention());

// 2. Agregar soporte para Controladores
builder.Services.AddControllers();

// 3. Configurar CORS para permitir peticiones desde tu App Shell
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirAppShell", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configuración de OpenAPI (Swagger) incluida por defecto en .NET 10
builder.Services.AddOpenApi();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 4. Activar CORS en el entorno de ejecución
app.UseCors("PermitirAppShell");

// 5. Mapear las rutas de los controladores
app.MapControllers();

app.Run();