using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {

        RuleFor(product => product.SalesNumber)
            .NotEmpty()
            .MinimumLength(2).WithMessage("Sales number must be at least 2 characters long.")
            .MaximumLength(50).WithMessage("Sales number cannot be longer than 50 characters.");

        RuleFor(product => product.Client)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Client must be at least 3 characters long.")
            .MaximumLength(150).WithMessage("Client cannot be longer than 150 characters.");

        RuleFor(product => product.Branch)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Branch must be at least 3 characters long.")
            .MaximumLength(150).WithMessage("Branch cannot be longer than 150 characters.");

        RuleFor(product => product.TotalDiscount)
            .GreaterThanOrEqualTo(0).WithMessage("Total discount must be greater than or equal to 0.");

        RuleFor(product => product.TotalPrice)
            .GreaterThan(0).WithMessage("Total price must be greater than 0.");

        RuleFor(product => product.OrderItems)
            .NotEmpty().WithMessage("Order items is required.");
    }
}
