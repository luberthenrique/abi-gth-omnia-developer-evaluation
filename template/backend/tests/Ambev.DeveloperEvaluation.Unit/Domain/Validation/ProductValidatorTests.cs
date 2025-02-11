using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the ProductValidator class.
/// Tests cover validation of all product properties including productname adn price.
/// </summary>
public class ProductValidatorTests
{
    private readonly ProductValidator _validator;

    public ProductValidatorTests()
    {
        _validator = new ProductValidator();
    }

    /// <summary>
    /// Tests that validation passes when all product properties are valid.
    /// This test verifies that a product with valid:
    /// - Name (3-150 characters)
    /// - Price (greater than 0 and lass than or equal to 20)
    /// passes all validation rules without any errors.
    /// </summary>
    [Fact(DisplayName = "Valid product should pass all validation rules")]
    public void Given_ValidProduct_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for invalid productname formats.
    /// This test verifies that productnames that are:
    /// - Empty strings
    /// - Less than 3 characters
    /// fail validation with appropriate error messages.
    /// The productname is a required field and must be between 3 and 150 characters.
    /// </summary>
    /// <param name="productname">The invalid productname to test.</param>
    [Theory(DisplayName = "Invalid productname formats should fail validation")]
    [InlineData("")] // Empty
    [InlineData("ab")] // Less than 3 characters
    public void Given_InvalidProductname_When_Validated_Then_ShouldHaveError(string productname)
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Name = productname;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    /// <summary>
    /// Tests that validation fails when productname exceeds maximum length.
    /// This test verifies that productnames longer than 150 characters fail validation.
    /// The test uses TestDataGenerator to create a productname that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Productname longer than maximum length should fail validation")]
    public void Given_ProductnameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Name = ProductTestData.GenerateLongProductname();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    /// <summary>
    /// Tests that validation fails for invalid productname formats.
    /// This test verifies that productnames that are:
    /// - Negatives
    /// - Less than 1 value
    /// - Greater than 20 value
    /// fail validation with appropriate error messages.
    /// </summary>
    /// <param name="price">The invalid price to test.</param>
    [Theory(DisplayName = "Invalid price values should fail validation")]
    [InlineData(-0.1)] // negative
    [InlineData(0)] // Less than 1
    [InlineData(21)] // Greater than 20
    public void Given_InvalidPrice_When_Validated_Then_ShouldHaveError(double price)
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Price = price;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Price);
    }
}
