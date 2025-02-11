using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the OrderValidator class.
/// Tests cover validation of all order properties including ordername, email,
/// password, phone, status, and role requirements.
/// </summary>
public class OrderValidatorTests
{
    private readonly OrderValidator _validator;

    public OrderValidatorTests()
    {
        _validator = new OrderValidator();
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
        var order = OrderTestData.GenerateValidOrder();

        // Act
        var result = _validator.TestValidate(order);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for invalid sales number formats.
    /// This test verifies that sales numbers that are:
    /// - Empty strings
    /// - Less than 2 characters
    /// fail validation with appropriate error messages.
    /// The sales number is a required field and must be between 2 and 50 characters.
    /// </summary>
    /// <param name="salesNumber">The invalid sales number to test.</param>
    [Theory(DisplayName = "Invalid sales number formats should fail validation")]
    [InlineData("")] // Empty
    [InlineData("a")] // Less than 2 characters
    public void Given_InvalidSalesNumber_When_Validated_Then_ShouldHaveError(string salesNumber)
    {
        // Arrange
        var order = OrderTestData.GenerateValidOrder();
        order.SalesNumber = salesNumber;

        // Act
        var result = _validator.TestValidate(order);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SalesNumber);
    }

    /// <summary>
    /// Tests that validation fails when sales number exceeds maximum length.
    /// This test verifies that sales numbers longer than 50 characters fail validation.
    /// The test uses TestDataGenerator to create a sales number that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "SalesNumber longer than maximum length should fail validation")]
    public void Given_SalesNumberLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var order = OrderTestData.GenerateValidOrder();
        order.SalesNumber = OrderTestData.GenerateLongSalesNumber();

        // Act
        var result = _validator.TestValidate(order);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SalesNumber);
    }

    /// <summary>
    /// Tests that validation fails for invalid client formats.
    /// This test verifies that client that are:
    /// - Empty strings
    /// - Less than 3 characters
    /// fail validation with appropriate error messages.
    /// The client is a required field and must be between 3 and 150 characters.
    /// </summary>
    /// <param name="client">The invalid client to test.</param>
    [Theory(DisplayName = "Invalid client formats should fail validation")]
    [InlineData("")] // Empty
    [InlineData("ab")] // Less than 3 characters
    public void Given_InvalidClient_When_Validated_Then_ShouldHaveError(string client)
    {
        // Arrange
        var order = OrderTestData.GenerateValidOrder();
        order.Client = client;

        // Act
        var result = _validator.TestValidate(order);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Client);
    }

    /// <summary>
    /// Tests that validation fails when client exceeds maximum length.
    /// This test verifies that client longer than 150 characters fail validation.
    /// The test uses TestDataGenerator to create a client that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Client longer than maximum length should fail validation")]
    public void Given_ClientLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var order = OrderTestData.GenerateValidOrder();
        order.Client = OrderTestData.GenerateLongClient();

        // Act
        var result = _validator.TestValidate(order);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Client);
    }

    /// <summary>
    /// Tests that validation fails for invalid branch formats.
    /// This test verifies that branch that are:
    /// - Empty strings
    /// - Less than 3 characters
    /// fail validation with appropriate error messages.
    /// The branch is a required field and must be between 3 and 150 characters.
    /// </summary>
    /// <param name="branch">The invalid branch to test.</param>
    [Theory(DisplayName = "Invalid branch formats should fail validation")]
    [InlineData("")] // Empty
    [InlineData("ab")] // Less than 3 characters
    public void Given_InvalidBranch_When_Validated_Then_ShouldHaveError(string branch)
    {
        // Arrange
        var order = OrderTestData.GenerateValidOrder();
        order.Branch = branch;

        // Act
        var result = _validator.TestValidate(order);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Branch);
    }

    /// <summary>
    /// Tests that validation fails when branch exceeds maximum length.
    /// This test verifies that branch longer than 150 characters fail validation.
    /// The test uses TestDataGenerator to create a branch that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Branch longer than maximum length should fail validation")]
    public void Given_BranchLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var order = OrderTestData.GenerateValidOrder();
        order.Branch = OrderTestData.GenerateLongBranch();

        // Act
        var result = _validator.TestValidate(order);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Branch);
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
        var order = OrderTestData.GenerateValidOrder();
        order.TotalDiscount = discount;

        // Act
        var result = _validator.TestValidate(order);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.TotalDiscount);
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
        var order = OrderTestData.GenerateValidOrder();
        order.TotalPrice = totalPrice;

        // Act
        var result = _validator.TestValidate(order);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.TotalPrice);
    }
}
