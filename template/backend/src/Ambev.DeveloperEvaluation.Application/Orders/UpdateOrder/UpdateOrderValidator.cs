using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder;

/// <summary>
/// Validator for UpdateOrderCommand that defines validation rules for order creation command.
/// </summary>
public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateOrderCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SalesNumber: Required, must be between 2 and 50 characters
    /// - Client: Required, must be between 3 and 150 characters
    /// - Branch: Required, must be between 3 and 150 characters
    /// - Items: Required
    /// </remarks>
    public UpdateOrderCommandValidator()
    {
        RuleFor(order => order.SalesNumber).NotEmpty().Length(2, 50);
        RuleFor(order => order.Client).NotEmpty().Length(3, 150);
        RuleFor(order => order.Branch).NotEmpty().Length(3, 150);
        RuleFor(order => order.Items).NotEmpty();

        RuleForEach(order => order.Items).SetValidator(new UpdateOrderItemValidator());
    }
}