using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.ListOrder
{
    /// <summary>
    /// Command for retrieving a order list
    /// </summary>
    public class ListOrderCommand : IRequest<ListOrderResult>
    {
    }
}
