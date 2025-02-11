namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder;

/// <summary>
/// API response model for GetOrder operation
/// </summary>
public class GetOrderResponse
{
    /// <summary>
    /// The unique identifier of the order
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the order's sales number.
    /// </summary>
    public string SalesNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets the order's data.
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Gets the order's client.
    /// </summary>
    public string Client { get; set; } = string.Empty;

    /// <summary>
    /// Gets the order's branch.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Gets the order's total discount.
    /// </summary>
    public double TotalDiscount { get; set; }

    /// <summary>
    /// Gets the order's total price.
    /// </summary>
    public double TotalPrice { get; set; }

    /// <summary>
    /// Gets the order's is cancelled.
    /// </summary>
    public bool IsCancelled { get; set; } = false;

    /// <summary>
    /// Gets the order's items.
    /// </summary>
    public virtual ICollection<GetOrderItemResponse> Items { get; set; }
}
