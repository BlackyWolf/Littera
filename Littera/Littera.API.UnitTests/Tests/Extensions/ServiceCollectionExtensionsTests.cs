using Littera.API.Extensions;
using Littera.API.Models.Options;
using Littera.API.UnitTests.Mocks.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Littera.API.UnitTests.Tests.Extensions;

public class ServiceCollectionExtensionsTests
{
    private readonly IConfiguration configuration;

    public ServiceCollectionExtensionsTests()
    {
        configuration = new OptionsConfigurationBuilder().Build();
    }

    [Fact]
    public void ConfigureServices_Returns_Same_IServiceCollection_Instance()
    {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        var returnedServices = services.ConfigureServices(configuration);
        
        // Assert
        Assert.Same(services, returnedServices);
    }
    
    [Fact]
    public void ConfigureServices_Registers_OpenApiOptions()
    {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        services.ConfigureServices(configuration);

        var provider = services.BuildServiceProvider();

        var options = provider.GetService<IOptions<OpenApiOptions>>();
        
        // Assert
        Assert.NotNull(options);
        Assert.NotNull(options!.Value);

        var openApi = options.Value;
        
        Assert.True(openApi.EnableDocumentation);
        Assert.False(openApi.EnableUi);
    }
    
    [Fact]
    public void ConfigureServices_Registers_SettingsOptions()
    {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        services.ConfigureServices(configuration);

        var provider = services.BuildServiceProvider();

        var options = provider.GetService<IOptions<SettingsOptions>>();
        
        // Assert
        Assert.NotNull(options);
        Assert.NotNull(options!.Value);

        var settings = options.Value;
        var openApi = settings.OpenApi;
        
        Assert.True(openApi.EnableDocumentation);
        Assert.False(openApi.EnableUi);
    }
}