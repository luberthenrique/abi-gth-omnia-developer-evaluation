namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder;

/// <summary>
/// Represents a request to update a item for order in the system.
/// </summary>
public class UpdateOrderItemRequest
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