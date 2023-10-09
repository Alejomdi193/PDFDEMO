using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// agrega el servicio AutoMapper al contenedor de servicios.
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddAplicacionServices();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PdfDemoContext>(option => {
string con = builder.Configuration.GetConnectionString("DefaultConecction");
option.UseMySql(con, ServerVersion.AutoDetect(con));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
