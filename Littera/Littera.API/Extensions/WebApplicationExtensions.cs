using Littera.API.Contracts;
using Littera.API.Endpoints;
using Littera.API.Models.Options;

namespace Littera.API.Extensions;

/// <summary>
///     A set of extension methods for managing the
///     <see cref="WebApplication" /> object.
/// </summary>
public static class WebApplicationExtensions
{
    /// <summary>
    ///     Sets up the web app object for the application.
    /// </summary>
    /// <param name="app">
    ///     The web app object to add middleware to.
    /// </param>
    /// <param name="configuration">
    ///     The configuration object to get options data.
    /// </param>
    /// <returns>The web app object for method chaining.</returns>
    public static WebApplication SetupWebApp(
        this WebApplication app,
        IConfiguration configuration)
    {
        var settings = app.Services
            .GetService<SettingsOptions>()
            .NotNull();

        if (settings.OpenApi.EnableDocumentation)
        {
            app.UseSwagger();
        }

        if (settings.OpenApi.EnableUi)
        {
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app
            .MapGet(WeatherForecastEndpoint.Pattern, WeatherForecastEndpoint.Handler)
            .WithName(WeatherForecastEndpoint.Name);

        return app;
    }
}