using Littera.API.Models.Options;
using Xunit;

namespace Littera.API.UnitTests.Tests.Models.Options;

public class SettingsOptionsTests
{
    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    public void SettingsOptions_Overrides_Defaults(bool enableDocs, bool enableUi)
    {
        // Arrange
        var openApiOptions = new OpenApiOptions
        {
            EnableDocumentation = enableDocs,
            EnableUi = enableUi
        };
        var settingsOptions = new SettingsOptions
        {
            OpenApi = openApiOptions
        };
        
        // Assert
        Assert.Equal(enableDocs, settingsOptions.OpenApi.EnableDocumentation);
        Assert.Equal(enableUi, settingsOptions.OpenApi.EnableUi);
    }

    [Fact]
    public void SettingsOptions_SectionName_Is_Settings()
    {
        // Assert
        Assert.Equal("Settings", SettingsOptions.Settings);
    }
    
    [Fact]
    public void SettingsOptions_Sets_Defaults()
    {
        // Arrange
        var options = new SettingsOptions();
        
        // Assert
        Assert.NotNull(options.OpenApi);
        Assert.True(options.OpenApi.EnableDocumentation);
        Assert.True(options.OpenApi.EnableUi);
    }
}