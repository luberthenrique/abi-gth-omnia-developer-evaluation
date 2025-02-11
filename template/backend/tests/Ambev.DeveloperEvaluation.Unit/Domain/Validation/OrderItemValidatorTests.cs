using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the OrderItemValidator class.
/// Tests cover validation of all order item properties including ordername, email,
/// password, phone, status, and role requirements.
/// </summary>
public class OrderItemValidatorTests
{
    private readonly OrderItemValidator _validator;

    public OrderItemValidatorTests()
    {
        _validator = new OrderItemValidator();
    }

    /// <summary>
    /// Tests that validation passes when all order properties are valid.
    /// This test verifies that a order with valid:
    /// - SalesNumber (2-50 characters)
    /// - Client (2-50 characters)
    /// - SalesNumber (3-150 characters)
    /// - SalesNumber (3-150 characters)
    /// - TotalPrice (greater than 0)
    /// - OrderItems (not empty)
    /// passes all validation rules without any errors.
    /// </summary>
    [Fact(DisplayName = "Valid order should pass all validation rules")]
    public void Given_ValidOrder_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var orderItem = OrderItemTestData.GenerateValidOrderItem();

        // Act
        var result = _validator.TestValidate(orderItem);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for invalid quantity formats.
    /// This test verifies that quantity that are:
    /// - Less than 0 value
    /// - Equal 0 value
    /// fail validation with appropriate error messages.
    /// </summary>
    /// <param name="quantity">The invalid quantity to test.</param>
    [Theory(DisplayName = "Invalid quantity formats should fail validation")]
    [InlineData(-0.1)] // negative
    [InlineData(0)] // empty
    public void Given_InvalidQuantity_When_Validated_Then_ShouldHaveError(double quantity)
    {
        // Arrange
        var orderItem = OrderItemTestData.GenerateValidOrderItem();
        orderItem.Quantity = quantity;

        // Act
        var result = _validator.TestValidate(orderItem);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Quantity);
    }

    /// <summary>
    /// Tests that validation fails for invalid unit price formats.
    /// This test verifies that unit price that are:
    /// - Less than 0 value
    /// - Equal 0 value
    /// fail validation with appropriate error messages.
    /// </summary>
    /// <param name="unitPrice">The invalid unit price to test.</param>
    [Theory(DisplayName = "Invalid unit price formats should fail validation")]
    [InlineData(-0.1)] // negative
    [InlineData(0)] // empty
    public void Given_InvalidUnitPrice_When_Validated_Then_ShouldHaveError(double unitPrice)
    {
        // Arrange
        var orderItem = OrderItemTestData.GenerateValidOrderItem();
        orderItem.UnitPrice = unitPrice;

        // Act
        var result = _validator.TestValidate(orderItem);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.UnitPrice);
    }

    /// <summary>
    /// Tests that validation fails for invalid discount formats.
    /// This test verifies that discount that are:
    /// - Less than 0 value
    /// fail validation with appropriate error messages.
    /// </summary>
    /// <param name="discount">The invalid discount to test.</param>
    [Theory(DisplayName = "Invalid discount formats should fail validation")]
    [InlineData(-0.1)] // negative
    public void Given_InvalidDiscount_When_Validated_Then_ShouldHaveError(double discount)
    {
        // Arrange
        var orderItem = OrderItemTestData.GenerateValidOrderItem();
        orderItem.Discount = discount;

        // Act
        var result = _validator.TestValidate(orderItem);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Discount);
    }

    /// <summary>
    /// Tests that validation fails for invalid total price formats.
    /// This test verifies that total price that are:
    /// - Less than 0 value
    /// - Equal 0 value
    /// fail validation with appropriate error messages.
    /// </summary>
    /// <param name="totalPrice">The invalid total price to test.</param>
    [Theory(DisplayName = "Invalid total price formats should fail validation")]
    [InlineData(-0.1)] // negative
    [InlineData(0)] // empty
    public void Given_InvalidTotalPrice_When_Validated_Then_ShouldHaveError(double totalPrice)
    {
        // Arrange
        var orderItem = OrderItemTestData.GenerateValidOrderItem();
        orderItem.TotalPrice = totalPrice;

        // Act
        var result = _validator.TestValidate(orderItem);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.TotalPrice);
    }
}
