namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;

/// <summary>
/// Represents a request to create a item for order in the system.
/// </summary>
public class CreateOrderItemRequest
{
    /// <summary>
    /// Gets or sets the product id. Must to be existing product id.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity. Must be greater than zero and
    /// </summary>
    public double Quantity { get; set; }
}