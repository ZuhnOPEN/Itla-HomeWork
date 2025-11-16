using System.IO;
using System.Reflection;
using Microsoft.OpenApi;
using tierdwebapp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registrar repositorio en memoria
builder.Services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "tierdwebapp API",
        Version = "v1",
        Description = "CRUD API de ejemplo para probar con Swagger"
    });

    // Incluir comentarios XML si se generaron
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "tierdwebapp API v1");
       // c.RoutePrefix = string.Empty; // SI quieres la UI en /swagger, quita esta línea
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
