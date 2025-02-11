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
    /// The order's sales number
    /// </summary>
    public string SalesNumber { get; set; } = string.Empty;

    /// <summary>
    /// The order's date
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// The order's client.
    /// </summary>
    public string Client { get; set; } = string.Empty;

    /// <summary>
    /// The order's branch.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// The order's total price.
    /// </summary>
    public double TotalPrice { get; set; }

    /// <summary>
    /// The order's is cancelled.
    /// </summary>
    public bool IsCancelled { get; set; } = false;
}
