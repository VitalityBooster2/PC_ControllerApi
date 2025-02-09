using Microsoft.EntityFrameworkCore;
using PC_ControllerApi;
using PC_ControllerApi.Controllers;
using PC_ControllerApi.Implementations.Factories;
using PC_ControllerApi.Interfaces;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));
builder.Services.AddTransient<IDbManagerFactory, DbManagerFactory>();

builder.Services.AddTransient<UserController>();
builder.Services.AddSignalR();
var ap = builder.Services.BuildServiceProvider().GetService<ApplicationContext>();

builder.Services.AddControllers();


builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapHub<ChatHub>("api/regHub");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};


app.UseAuthorization();

app.MapControllers();

app.MapGet("/", (context) => context.Response.WriteAsync("Hello world"));


app.Run();
