using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder;

/// <summary>
/// Command for updating a new order item.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating a order item, 
/// including product id, quantity and discount. 
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateOrderItemCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateOrderItemCommand
{
    /// <summary>
    /// Gets or sets the product id of the item to be updated.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the item to be updated.
    /// </summary>
    public double Quantity { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateOrderItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}