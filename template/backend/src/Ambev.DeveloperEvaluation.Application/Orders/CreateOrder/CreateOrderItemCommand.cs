using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;

/// <summary>
/// Command for creating a new order item.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a order item, 
/// including product id, quantity and discount. 
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateOrderItemCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateOrderItemCommand
{
    /// <summary>
    /// Gets or sets the product id of the item to be created.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the item to be created.
    /// </summary>
    public double Quantity { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateOrderItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}