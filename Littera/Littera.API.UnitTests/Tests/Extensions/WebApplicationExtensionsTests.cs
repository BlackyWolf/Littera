using Littera.API.Extensions;
using Littera.API.UnitTests.Mocks;
using Littera.API.UnitTests.Mocks.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting.Internal;
using Xunit;

namespace Littera.API.UnitTests.Tests.Extensions;

public class WebApplicationExtensionsTests
{
    [Fact]
    public void SetupWebApp_Returns_Same_App_Instances()
    {
        // Arrange
        var builder = new AppBuilder().CreateBuilder();
        var configuration = builder.Configuration;
        var environment = builder.Environment;
        var app = builder.Build();
        
        // Act
        var returnedApp = app.SetupWebApp(configuration, environment);
        
        // Assert
        Assert.Same(app, returnedApp);
    }
}