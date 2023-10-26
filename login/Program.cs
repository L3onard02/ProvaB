using Microsoft.EntityFrameworkCore;
using punto1.Service;
using Punto1.DataSource;
using WebApiJWT.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();







builder.Services.AddDbContext<ProvaContext>(options =>
{
    //modo 1
    string? cnProdotti = builder.Configuration.GetConnectionString("cnNW");
    //modo 2
    //string cnNorthwind2 = builder.Configuration.GetValue<string>("ConnectionStrings:cnNW");



    options.UseSqlServer(cnProdotti);



});

//context
builder.Services.AddScoped<ProvaContext, ProvaContext>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IJWTHelper, JWTHelper>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
