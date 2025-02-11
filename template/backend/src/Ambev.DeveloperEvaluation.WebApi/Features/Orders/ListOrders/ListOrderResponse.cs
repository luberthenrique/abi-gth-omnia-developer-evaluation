namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.ListOrder;

/// <summary>
/// API response model for ListOrder operation
/// </summary>
public class ListOrderResponse
{
    /// <summary>
    /// The list of the order
    /// </summary>
    public List<OrderResponse> Orders { get; set; } = [];
}
