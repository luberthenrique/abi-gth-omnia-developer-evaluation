using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class OrderItemTestData
{
    /// <summary>
    /// Configures the Faker to generate valid OrderItem entities.
    /// The generated order items will have valid:
    /// - OrderId (using Random Uuid)
    /// - Price (using commerce price)
    /// </summary>
    private static readonly Faker<OrderItem> OrderFaker = new Faker<OrderItem>()
        .RuleFor(u => u.OrderId, f => f.Random.Uuid())
        .RuleFor(u => u.ProductId, f => f.Random.Uuid())
        .RuleFor(u => u.Quantity, f => f.Random.Double(0.1))
        .RuleFor(u => u.UnitPrice, f => double.Parse(f.Commerce.Price(0.1m)))
        .RuleFor(u => u.Discount, f => default)
        .RuleFor(u => u.TotalPrice, f => double.Parse(f.Commerce.Price(0.1m)));

    /// <summary>
    /// Generates a valid Order entity with randomized data.
    /// The generated order item will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Order entity with randomly generated data.</returns>
    public static OrderItem GenerateValidOrderItem()
    {
        return OrderFaker.Generate();
    }
}
