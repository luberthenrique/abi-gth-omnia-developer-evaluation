using Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder;

/// <summary>
/// Represents a request to create a new order in the system.
/// </summary>
public class UpdateOrderRequest
{
    /// <summary>
    /// The unique identifier of the order to update
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Gets or sets the name. Must be unique and contain only valid characters.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Gets or sets the items. Muste contain items
    /// </summary>
    public IList<UpdateOrderItemRequest> Items { get; set; } = [];
}