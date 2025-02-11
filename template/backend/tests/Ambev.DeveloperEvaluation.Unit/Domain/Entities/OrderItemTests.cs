using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the OrderItem entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class OrderItemTests
{
    /// <summary>
    /// Tests that validation passes when all order item properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid order item data")]
    public async void Given_ValidOrderItemData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var orderItem = OrderItemTestData.GenerateValidOrderItem();
        // Act
        var result = orderItem.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when order properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid order item data")]
    public void Given_InvalidOrderItemData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var orderItem = new OrderItem
        {
            OrderId = default, // Invalid: empty
            ProductId = default, // Invalid: empty
            Quantity = 0, // Invalid: empty
            Discount = -1, // Invalid: negative
            TotalPrice = 0,// Invalid: empty
        };

        // Act
        var result = orderItem.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Calculate discount for items to quantity between 4 and 9
    /// </summary>
    [Theory(DisplayName = "Calculate discount for items to quantity between 4 and 9")]
    [InlineData(4)]
    [InlineData(9)]
    public void Given_CalculateDiscount_When_QuantityBetweenFourAndNine_Then_ShouldDiscount(double quantity)
    {
        // Arrange
        var unitPrice = 10;
        var orderItem = OrderItemTestData.GenerateValidOrderItem();
        orderItem.Quantity = quantity;

        // Act
        orderItem.CalculatePriceAndDiscount(unitPrice);

        // Assert
        Assert.Equal(unitPrice * quantity * 0.1, orderItem.Discount);
    }

    /// <summary>
    /// Calculate total price for items to quantity between 4 and 9
    /// </summary>
    [Theory(DisplayName = "Calculate total price for items to quantity between 4 and 9")]
    [InlineData(4)]
    [InlineData(9)]
    public void Given_CalculateTotalPrice_When_QuantityBetweenFourAndNine_Then_ShouldTotalPrice(double quantity)
    {
        // Arrange
        var unitPrice = 10;
        var orderItem = OrderItemTestData.GenerateValidOrderItem();
        orderItem.Quantity = quantity;

        // Act
        orderItem.CalculatePriceAndDiscount(unitPrice);

        // Assert
        Assert.Equal(quantity * unitPrice * 0.9, orderItem.TotalPrice);
    }

    /// <summary>
    /// Calculate discount for items to quantity between 10 and 20
    /// </summary>
    [Theory(DisplayName = "Calculate discount for items to quantity between 10 and 20")]
    [InlineData(10)]
    [InlineData(20)]
    public void Given_CalculateDiscount_When_QuantityBetweenTenAndTwenty_Then_ShouldDiscount(double quantity)
    {
        // Arrange
        var unitPrice = 10;
        var orderItem = OrderItemTestData.GenerateValidOrderItem();
        orderItem.Quantity = quantity;

        // Act
        orderItem.CalculatePriceAndDiscount(unitPrice);

        // Assert
        Assert.Equal(unitPrice * quantity * 0.2, orderItem.Discount);
    }

    /// <summary>
    /// Calculate total price for items to quantity between 10 and 20
    /// </summary>
    [Theory(DisplayName = "Calculate total price for items to quantity between 10 and 20")]
    [InlineData(10)]
    [InlineData(20)]
    public void Given_CalculateTotalPrice_When_QuantityBetweenTenAndTwenty_Then_ShouldTotalPrice(double quantity)
    {
        // Arrange
        var unitPrice = 10;
        var orderItem = OrderItemTestData.GenerateValidOrderItem();
        orderItem.Quantity = quantity;

        // Act
        orderItem.CalculatePriceAndDiscount(unitPrice);

        // Assert
        Assert.Equal(quantity * unitPrice * 0.8, orderItem.TotalPrice);
    }
}
