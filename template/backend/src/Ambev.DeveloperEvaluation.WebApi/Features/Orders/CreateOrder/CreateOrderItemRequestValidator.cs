using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;

/// <summary>
/// Validator for CreateOrderItemRequest that defines validation rules for order creation.
/// </summary>
public class CreateOrderItemRequestValidator : AbstractValidator<CreateOrderItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateOrderItemRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ProductId: Required
    /// - Quantity: Required, must be greater than zero
    /// </remarks>
    public CreateOrderItemRequestValidator()
    {
        RuleFor(order => order.ProductId).NotEmpty();
        RuleFor(order => order.Quantity);
    }
}