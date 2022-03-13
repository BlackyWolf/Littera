using Littera.API.Models.Options;

namespace Littera.API.Extensions
{
    /// <summary>
    ///     A set of extension methods for managing the
    ///     <see cref="IServiceCollection" /> object.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Sets up the <see cref="IServiceCollection" /> object for the
        ///     app.
        /// </summary>
        /// <param name="services">
        ///     The services object to add services to.
        /// </param>
        /// <param name="configuration">
        ///     The configuration object used to get options data.
        /// </param>
        /// <returns>The services object for method chaining.</returns>
        public static IServiceCollection ConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var settings = configuration.GetSettingsOptions();

            services.ConfigureOptions(configuration);
            services.AddEndpointsApiExplorer();

            if (settings.OpenApi.EnableDocumentation)
            {
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                services.AddSwaggerGen();
            }

            return services;
        }

        private static IServiceCollection ConfigureOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<SettingsOptions>(configuration.GetSection(SettingsOptions.Settings));
            services.Configure<OpenApiOptions>(
                configuration.GetSection($"{SettingsOptions.Settings}:{OpenApiOptions.OpenApi}")
            );

            return services;
        }
    }
}
