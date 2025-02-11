using Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder;

/// <summary>
/// Validator for UpdateOrderRequest that defines validation rules for order updation.
/// </summary>
public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateOrderRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Id: Required
    /// - Name: Required, must be between 3 and 100 characters
    /// - Price: Must be greater than zero
    /// </remarks>
    public UpdateOrderRequestValidator()
    {
        RuleFor(order => order.Id).NotEmpty();
        RuleFor(order => order.Name).NotEmpty().Length(3, 100);
        RuleFor(order => order.Price).GreaterThan(0);
        RuleFor(order => order.Items).NotEmpty();

        RuleForEach(order => order.Items).SetValidator(new UpdateOrderItemRequestValidator());
    }
}