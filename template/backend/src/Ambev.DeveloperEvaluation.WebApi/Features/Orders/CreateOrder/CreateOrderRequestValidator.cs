using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;

/// <summary>
/// Validator for CreateOrderRequest that defines validation rules for order creation.
/// </summary>
public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateOrderRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SalesNumber: Required, must be between 2 and 50 characters
    /// - Client: Required, must be between 3 and 150 characters
    /// - Branch: Required, must be between 3 and 150 characters
    /// - Items: Required
    /// </remarks>
    public CreateOrderRequestValidator()
    {
        RuleFor(order => order.SalesNumber).NotEmpty().Length(2, 50);
        RuleFor(order => order.Client).NotEmpty().Length(3, 150);
        RuleFor(order => order.Branch).NotEmpty().Length(3, 150);
        RuleFor(order => order.Items).NotEmpty();

        RuleForEach(order => order.Items).SetValidator(new CreateOrderItemRequestValidator());
    }
}