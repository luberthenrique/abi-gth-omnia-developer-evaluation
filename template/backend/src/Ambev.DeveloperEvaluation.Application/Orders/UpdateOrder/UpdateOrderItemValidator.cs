using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder;

/// <summary>
/// Validator for UpdateOrderItemCommand that defines validation rules for order item updation command.
/// </summary>
public class UpdateOrderItemValidator : AbstractValidator<UpdateOrderItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the UpdateOrderItemValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ProductId: Required
    /// - Quantity: Required, must be greater than zero and must be less than or equal to twenty
    /// </remarks>
    public UpdateOrderItemValidator()
    {
        RuleFor(order => order.ProductId).NotEmpty();
        RuleFor(order => order.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
    }
}