using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder;

/// <summary>
/// Command for updating a new order.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating a order, 
/// including ordername, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateOrderResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateOrderCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateOrderCommand : IRequest<UpdateOrderResult>
{
    /// <summary>
    /// The unique identifier of the product to be updated
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the sales number of the order to be updated.
    /// </summary>
    public string SalesNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the order date of the order to be updated.
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Gets or sets the client of the order to be updated.
    /// </summary>
    public string Client { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the branch of the order to be updated.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the items of the order to be updated.
    /// </summary>
    public ICollection<UpdateOrderItemCommand> Items { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateOrderCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}