using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Littera.API.UnitTests.Mocks.Configuration;

public class OptionsConfigurationBuilder
{
    public IConfiguration Build()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonStream(GetJsonConfigurationStream())
            .Build();

        return configuration;
    }

    private string GetJsonConfiguration()
    {
        return @"{
            ""Logging"": {
                ""LogLevel"": {
                    ""Default"": ""Information"",
                    ""Microsoft.AspNetCore"": ""Warning""
                }
            },
            ""Settings"": {
                ""OpenApi"": {
                    ""EnableDocumentation"": true,
                    ""EnableUi"": false
                }
            }
        }";
    }

    private byte[] GetJsonConfigurationBytes()
    {
        return Encoding.UTF8.GetBytes(GetJsonConfiguration());
    }

    private Stream GetJsonConfigurationStream()
    {
        return new MemoryStream(GetJsonConfigurationBytes());
    }
}