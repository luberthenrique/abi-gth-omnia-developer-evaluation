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
    /// - Client: Required, must be between 3 and 150 characters
    /// - Branch: Required, must be between 3 and 150 characters
    /// - OrderDate: Required
    /// - Items: Must be does not empty
    /// </remarks>
    public UpdateOrderRequestValidator()
    {
        RuleFor(order => order.Id).NotEmpty();
        RuleFor(order => order.SalesNumber).NotEmpty().Length(2, 50);
        RuleFor(order => order.Client).NotEmpty().Length(3, 150);
        RuleFor(order => order.Branch).NotEmpty().Length(3, 150);
        RuleFor(order => order.OrderDate).NotEmpty();
        RuleFor(order => order.Items).NotEmpty();

        RuleForEach(order => order.Items).SetValidator(new UpdateOrderItemRequestValidator());
    }
}