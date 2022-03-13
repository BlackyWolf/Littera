namespace Littera.API.Models.Options;

/// <summary>
///     Over-arching container used to retrieve all settings and options used
///     throughout the application.
/// </summary>
public class SettingsOptions
{
    /// <summary>
    ///     The name of the options key in the app settings JSON.
    /// </summary>
    public static string Settings => "Settings";

    /// <summary>
    ///     The settings used for configuring swagger, swashbuckle, and open
    ///     API code.
    /// </summary>
    public OpenApiOptions OpenApi { get; set; } = new();
}