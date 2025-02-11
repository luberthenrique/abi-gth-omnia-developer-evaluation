using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class OrderItemValidator : AbstractValidator<OrderItem>
{
    public OrderItemValidator()
    {

        RuleFor(product => product.ProductId)
            .NotEmpty().WithMessage("Product id us required");

        RuleFor(product => product.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

        RuleFor(product => product.UnitPrice)
            .GreaterThan(0).WithMessage("Unit price must be greater than 0.");

        RuleFor(product => product.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount must be greater than or equal to 0.");


    }
}
