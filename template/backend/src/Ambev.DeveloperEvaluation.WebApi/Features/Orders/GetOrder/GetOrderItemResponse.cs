namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder;

/// <summary>
/// API response model for items to GetOrder operation
/// </summary>
public class GetOrderItemResponse
{
    /// <summary>
    /// Gets the item's product id.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the item's quantity.
    /// </summary>
    public double Quantity { get; set; }

    /// <summary>
    /// Gets the item's unit price.
    /// </summary>
    public double UnitPrice { get; set; }

    /// <summary>
    /// Gets the item's discount.
    /// </summary>
    public double Discount { get; set; }

    /// <summary>
    /// Must be greater than zero.
    /// </summary>
    public double TotalPrice { get; set; }
}
