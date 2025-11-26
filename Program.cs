using System.Reflection;
using api_careluna.Data;
using api_careluna.Middleware;
using api_careluna.Services.Productos.Implementations;
using api_careluna.Services.Productos.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Agregar conexión a PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod());
});


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IProductosServices, ProductosServices>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware global
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");
app.UseStaticFiles();

app.MapControllers();

app.Run();
