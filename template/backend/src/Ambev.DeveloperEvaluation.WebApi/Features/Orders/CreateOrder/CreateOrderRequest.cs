namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;

/// <summary>
/// Represents a request to create a new order in the system.
/// </summary>
public class CreateOrderRequest
{
    /// <summary>
    /// Gets or sets the sales number. Must be unique.
    /// </summary>
    public string SalesNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the client.
    /// </summary>
    public string Client { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the branch.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the items. Muste contain items
    /// </summary>
    public IList<CreateOrderItemRequest> Items { get; set; } = [];
}