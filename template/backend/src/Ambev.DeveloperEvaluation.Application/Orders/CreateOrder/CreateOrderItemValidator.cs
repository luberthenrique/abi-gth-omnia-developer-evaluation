using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;

/// <summary>
/// Validator for CreateOrderItemCommand that defines validation rules for order item creation command.
/// </summary>
public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateOrderItemValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ProductId: Required
    /// - Quantity: Required, must be greater than zero and must be less than or equal to twenty
    /// </remarks>
    public CreateOrderItemValidator()
    {
        RuleFor(order => order.ProductId).NotEmpty();
        RuleFor(order => order.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
    }
}