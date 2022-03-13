using Littera.API.Models.Options;

namespace Littera.API.Extensions;

public static class ConfigurationExtensions
{
    public static SettingsOptions GetSettingsOptions(this IConfiguration configuration)
    {
        return configuration
            .GetRequiredSection(SettingsOptions.Settings)
            .Get<SettingsOptions>();
    }
}