using Hospital.Application.UseCases;
using Hospital.Infrastructure.Database;
using Hospital.Infrastructure.Helpers;
using Hospital.Infrastructure.Injections;
using Hospital.Infrastructure.Services;
using Hospital.WebApi.Filter;
using Hospital.WebApi.Injections;

using Microsoft.EntityFrameworkCore;

using NLog;
using NLog.Web;

var basedir = AppDomain.CurrentDomain.BaseDirectory;
var logger = NLog.LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configuration.AddJsonFile("appsettings.Local.json");

configuration
    .CheckConfigurations()
    .CheckAndCreateFolders();

logger.Debug("Starting application");

// Logger Initialization
builder.Logging.ClearProviders();
builder.Host.UseNLog();

AppDomain.CurrentDomain
.UnhandledException += (sender, eventArgs) =>
{
    logger.Error(eventArgs.ExceptionObject.ToString(), "Stopped program because of exception");
    NLog.LogManager.Shutdown();
    Console.WriteLine(eventArgs.ExceptionObject.ToString());
};

Directory.CreateDirectory($"{basedir}\\logs");

// Exceptions Filter
builder.Services.AddMvc(options =>
    options.Filters.Add(typeof(ExceptionFilter)
));

builder.Services.InjectEntityFramework(configuration);
builder.Services.InjectIdentity();

builder.Services.InjectAuthAuthen(configuration);
builder.Services.InjectServices();
builder.Services.RegisterUseCase();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.InjectSawagger();
builder.Services.InjectCORS();

var app = builder.Build();

/* // 4.1. Add seed */
/* using (var scope = app.Services.CreateScope()) */
/* { */
/*     var services = scope.ServiceProvider; */
/*     await SeedManager.Seed(services); */
/* } */

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    });
}

// //7. Use CORS
// app.UseCors("AllowAngularDevClient");
app.UseHttpsRedirection();

// 8. Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();