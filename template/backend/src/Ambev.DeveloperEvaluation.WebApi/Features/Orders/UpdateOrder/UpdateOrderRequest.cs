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
    /// Gets or sets the sales number of the order to be updated.
    /// </summary>
    public string SalesNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the order date of the order to be updated.
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Gets or sets the client of the order to be updated.
    /// </summary>
    public string Client { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the branch of the order to be updated.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the items of the order to be updated.
    /// </summary>

    /// <summary>
    /// Gets or sets the items. Muste contain items
    /// </summary>
    public IList<UpdateOrderItemRequest> Items { get; set; } = [];
}