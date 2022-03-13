using Littera.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var environment = builder.Environment;
var services = builder.Services;

services.ConfigureServices(configuration);

// Configure the HTTP request pipeline.
var app = builder.Build();

app.SetupWebApp(configuration, environment);

app.Run();