using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;

/// <summary>
/// Command for creating a new order.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a order, 
/// including sales number, client, branch and items. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateOrderResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateOrderCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateOrderCommand : IRequest<CreateOrderResult>
{
    /// <summary>
    /// Gets or sets the sales number of the order to be created.
    /// </summary>
    public string SalesNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the client of the order to be created.
    /// </summary>
    public string Client { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the branch of the order to be created.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the items of the order to be created.
    /// </summary>
    public ICollection<CreateOrderItemCommand> Items { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateOrderCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}