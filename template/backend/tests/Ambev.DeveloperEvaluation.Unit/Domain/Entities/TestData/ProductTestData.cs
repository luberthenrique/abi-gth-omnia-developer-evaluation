using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ProductTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Product entities.
    /// The generated products will have valid:
    /// - Name (using commerce product name)
    /// - Price (using commerce price)
    /// </summary>
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(u => u.Name, f => f.Commerce.ProductName())
        .RuleFor(u => u.Price, f => double.Parse(f.Commerce.Price()));

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }

    /// <summary>
    /// Generates a valid productname.
    /// The generated productname will:
    /// - Be between 3 and 100 characters
    /// - Use commerce productname conventions
    /// - Contain only valid characters
    /// </summary>
    /// <returns>A valid productname.</returns>
    public static string GenerateValidProductName()
    {
        return new Faker().Commerce.ProductName();
    }

    /// <summary>
    /// Generates a productname that exceeds the maximum length limit.
    /// The generated productname will:
    /// - Be longer than 100 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing productname length validation error cases.
    /// </summary>
    /// <returns>A productname that exceeds the maximum length limit.</returns>
    public static string GenerateLongProductname()
    {
        return new Faker().Random.String2(101);
    }
}
