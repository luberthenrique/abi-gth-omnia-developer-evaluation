namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder;

/// <summary>
/// API response model for UpdateOrder operation
/// </summary>
public class UpdateOrderResponse
{
    /// <summary>
    /// The unique identifier of the created order
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The order's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The order's price
    /// </summary>
    public double Price { get; set; }
}
