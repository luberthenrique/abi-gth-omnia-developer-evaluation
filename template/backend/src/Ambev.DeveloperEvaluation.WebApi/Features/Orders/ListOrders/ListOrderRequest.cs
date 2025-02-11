namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder;

/// <summary>
/// Request model for getting a order list
/// </summary>
public class ListOrderRequest
{
    /// <summary>
    /// The name for identifier of the orders to retrieve
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
