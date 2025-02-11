using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class OrderTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Order entities.
    /// The generated orders will have valid:
    /// - SalesNumber (using commerce Ean8)
    /// - Price (using commerce price)
    /// </summary>
    private static readonly Faker<Order> OrderFaker = new Faker<Order>()
        .RuleFor(u => u.SalesNumber, f => f.Commerce.Ean8())
        .RuleFor(u => u.OrderDate, f => f.Date.Recent())
        .RuleFor(u => u.Client, f => f.Name.FullName())
        .RuleFor(u => u.Branch, f => f.Name.FullName())
        .RuleFor(u => u.TotalDiscount, 0)
        .RuleFor(u => u.TotalPrice, f => double.Parse(f.Commerce.Price(1)))
        .RuleFor(u => u.OrderItems, f => f.Make(1, () => new OrderItem 
        { 
            ProductId = Guid.NewGuid(), 
            Quantity = f.Random.Int(1)            
        }));

    /// <summary>
    /// Generates a valid Order entity with randomized data.
    /// The generated order will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Order entity with randomly generated data.</returns>
    public static Order GenerateValidOrder()
    {
        return OrderFaker.Generate();
    }

    public static string GenerateLongSalesNumber()
    {
        return new Faker().Random.String2(51);
    }

    public static string GenerateLongClient()
    {
        return new Faker().Random.String2(151);
    }

    public static string GenerateLongBranch()
    {
        return new Faker().Random.String2(151);
    }
}
