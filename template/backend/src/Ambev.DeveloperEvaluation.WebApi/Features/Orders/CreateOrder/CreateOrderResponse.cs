namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;

/// <summary>
/// API response model for CreateOrder operation
/// </summary>
public class CreateOrderResponse
{
    /// <summary>
    /// The unique identifier of the created order
    /// </summary>
    public Guid Id { get; set; }
}
