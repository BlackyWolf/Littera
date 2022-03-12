namespace Littera.API.Models.Options;

/// <summary>
///     Settings for configuring Swagger, Swashbuckle, and Open API code.
/// </summary>
public class OpenApiOptions
{
    /// <summary>
    ///     The name of the options key in the appsettings JSON.
    /// </summary>
    public static string OpenApi => "OpenApi";

    /// <summary>
    ///     Determines whether an open API document is generated from the API
    ///     endpoints. Default is true.
    /// </summary>
    public bool EnableDocumentation { get; set; } = true;

    /// <summary>
    ///     Determines whether the UI for displaying the open API document is
    ///     enabled or not. Default is true.
    /// </summary>
    public bool EnableUi { get; set; } = true;
}