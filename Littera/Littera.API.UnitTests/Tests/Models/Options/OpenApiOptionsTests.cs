using Littera.API.Models.Options;
using Xunit;

namespace Littera.API.UnitTests.Tests.Models.Options;

public class OpenApiOptionsTests
{
    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    public void OpenApiOptions_Overrides_Defaults(bool enableDocs, bool enableUi)
    {
        // Arrange
        var options = new OpenApiOptions
        {
            EnableDocumentation = enableDocs,
            EnableUi = enableUi
        };
        
        // Assert
        Assert.Equal(enableDocs, options.EnableDocumentation);
        Assert.Equal(enableUi, options.EnableUi);
    }

    [Fact]
    public void OpenApiOptions_SectionName_Is_OpenApi()
    {
        // Assert
        Assert.Equal("OpenApi", OpenApiOptions.OpenApi);
    }
    
    [Fact]
    public void OpenApiOptions_Sets_Defaults()
    {
        // Arrange
        var options = new OpenApiOptions();
        
        // Assert
        Assert.True(options.EnableDocumentation);
        Assert.True(options.EnableUi);
    }
}