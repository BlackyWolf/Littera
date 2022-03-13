using System;
using Littera.API.Contracts;
using Xunit;

namespace Littera.API.UnitTests.Tests.Contracts;

public class NotNullContractTests
{
    [Theory]
    [InlineData("")]
    [InlineData("yo")]
    [InlineData(0)]
    [InlineData(false)]
    [InlineData('1')]
    public void NotNull_DoesNotThrow_OnPrimitives(object someData)
    {
        // Act
        someData.NotNull();
    }

    [Fact]
    public void NotNull_Exception_Contains_CustomMessage()
    {
        // Arrange
        string? data = null;
        var parameterName = "someStupidData";
        
        // Arrange/Act/Assert
        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            data.NotNull(parameterName);
        });
        
        Assert.Equal(
            $"Value cannot be null. (Parameter '{parameterName}')",
            exception.Message
        );
    }

    [Theory]
    [InlineData("")]
    [InlineData("yo")]
    [InlineData(0)]
    [InlineData(false)]
    [InlineData('1')]
    public void NotNull_Returns_SameInstance(object someData)
    {
        // Arrange/Act
        var returnedData = someData.NotNull();
        
        // Assert
        Assert.Same(someData, returnedData);
    }
    
    [Fact]
    public void NotNull_Throws_OnNull()
    {
        // Arrange
        string? emailAddress = null;
        
        // Arrange/Act/Assert
        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            emailAddress.NotNull();
        });
        
        Assert.Equal(
            $"Value cannot be null. (Parameter '{nameof(emailAddress)}')",
            exception.Message
        );
    }
}