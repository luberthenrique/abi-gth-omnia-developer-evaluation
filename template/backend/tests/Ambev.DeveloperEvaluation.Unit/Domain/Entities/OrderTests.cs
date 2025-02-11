using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Order entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class OrderTests
{
    /// <summary>
    /// Tests that validation passes when all order properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid order data")]
    public async void Given_ValidOrderData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var order = OrderTestData.GenerateValidOrder();

        // Act
        var result = order.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when order properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid order data")]
    public void Given_InvalidOrderData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var order = new Order
        {
            SalesNumber = "", // Invalid: empty
            Client = "", // Invalid: empty
            Branch = "", // Invalid: empty
            TotalDiscount = -1, // Invalid: negative
            TotalPrice = -1,// Invalid: negative
            OrderItems = [] // Invalid: empty
        };

        // Act
        var result = order.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}
