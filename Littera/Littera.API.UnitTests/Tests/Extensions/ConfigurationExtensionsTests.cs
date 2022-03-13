using Littera.API.Extensions;
using Littera.API.UnitTests.Mocks.Configuration;
using Xunit;

namespace Littera.API.UnitTests.Tests.Extensions;

public class ConfigurationExtensionsTests
{
    [Fact]
    public void GetSettingsOptions_Returns_Correct_Settings()
    {
        // Arrange
        var configuration = new OptionsConfigurationBuilder().Build();
        
        // Act
        var settings = configuration.GetSettingsOptions();
        
        // Assert
        Assert.NotNull(settings);
        Assert.True(settings.OpenApi.EnableDocumentation);
        Assert.False(settings.OpenApi.EnableUi);
    }
}