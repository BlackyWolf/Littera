using Littera.API.Extensions;
using Littera.API.UnitTests.Mocks.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Littera.API.UnitTests.Mocks;

public class AppBuilder
{
    public WebApplicationBuilder CreateBuilder()
    {
        var configuration = new OptionsConfigurationBuilder().Build();
        var appBuilder = WebApplication.CreateBuilder();

        appBuilder.Configuration.AddConfiguration(configuration);

        appBuilder.Services.ConfigureServices(appBuilder.Configuration);

        return appBuilder;
    }
}