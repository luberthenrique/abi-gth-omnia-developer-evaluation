namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrder;

/// <summary>
/// Response model for item in GetOrder operation
/// </summary>
public class GetOrderItemResult
{
    /// <summary>
    /// The unique identifier of the order item
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The order item's product id
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The order item's quantity for product
    /// </summary>
    public double Quantity { get; set; }

    /// <summary>
    /// The order item's unit price for product
    /// </summary>
    public double UnitPrice { get; set; }

    /// <summary>
    /// The order item's total discount for product
    /// </summary>
    public double Discount { get; set; }

    /// <summary>
    /// The order item's total price for product
    /// </summary>
    public double TotalPrice { get; set; }

    /// <summary>
    /// The order item's product name
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// The order item's product price
    /// </summary>
    public double ProductPrice { get; set; }
}
