using System.Reflection;
using api_careluna.Data;
using api_careluna.Middleware;
using api_careluna.Services.Productos.Implementations;
using api_careluna.Services.Productos.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------
// 🔹 1. CONFIGURACIÓN DE SERVICIOS
// ------------------------------------------------------

// 🔸 Base de datos PostgreSQL (Railway usa variable de entorno)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// 🔸 Controladores
builder.Services.AddControllers();

// 🔸 Swagger + XML documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    if (File.Exists(xmlPath))
        options.IncludeXmlComments(xmlPath);

    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Careluna",
        Version = "v1",
        Description = "API para manejar productos, pedidos y clientes.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Cristian Jaramillo",
            Email = "tu-email@mail.com"
        }
    });
});

// 🔸 CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// 🔸 AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// 🔸 Inyección de dependencias
builder.Services.AddScoped<IProductosServices, ProductosServices>();


// ------------------------------------------------------
// 🔹 2. CONSTRUCCIÓN DE LA APP
// ------------------------------------------------------
var app = builder.Build();


// ------------------------------------------------------
// 🔹 3. MIDDLEWARES
// ------------------------------------------------------

// Middleware global para capturar excepciones
app.UseMiddleware<ExceptionMiddleware>();

// 🔸 Swagger SIEMPRE habilitado (útil para Railway)
app.UseSwagger();
app.UseSwaggerUI();

// ⚠️ Railway NO usa HTTPS interno — se deja solo en local
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseAuthorization();

// 🔸 Rutas
app.MapControllers();


// ------------------------------------------------------
// 🔹 4. EJECUTAR APP
// ------------------------------------------------------
app.Run();
