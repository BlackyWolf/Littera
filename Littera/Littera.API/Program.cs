using Littera.API.Endpoints;
using Littera.API.Extensions;
using Littera.API.Models.Options;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

services.ConfigureServices(configuration);

// Configure the HTTP request pipeline.
var app = builder.Build();

app.Run();