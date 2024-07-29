using Microsoft.EntityFrameworkCore;
using WebApiPersons.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//creamos variable para la cadena de conexion
var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddControllers();
//registramos servicio para la conexion
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connection));
//añadimos Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My api v1");
        c.RoutePrefix = string.Empty;// abilita swagger ui para la url root
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
