using Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;

/// <summary>
/// Validator for UpdateOrderItemRequest that defines validation rules for order creation.
/// </summary>
public class UpdateOrderItemRequestValidator : AbstractValidator<UpdateOrderItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateOrderItemRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ProductId: Required
    /// - Quantity: Required, must be greater than zero
    /// </remarks>
    public UpdateOrderItemRequestValidator()
    {
        RuleFor(order => order.ProductId).NotEmpty();
        RuleFor(order => order.Quantity);
    }
}