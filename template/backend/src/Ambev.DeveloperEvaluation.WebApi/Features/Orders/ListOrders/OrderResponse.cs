namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.ListOrder;

/// <summary>
/// API response model for a single Order
/// </summary>
public class OrderResponse
{
    /// <summary>
    /// The unique identifier of the order
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The order's name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The order's price
    /// </summary>
    public double Price { get; set; }
}
