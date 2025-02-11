using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.ListOrder;

/// <summary>
/// Handler for processing ListOrderCommand requests
/// </summary>
public class ListOrderHandler : IRequestHandler<ListOrderCommand, ListOrderResult>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListOrderHandler
    /// </summary>
    /// <param name="orderRepository">The order repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for ListOrderCommand</param>
    public ListOrderHandler(
        IOrderRepository orderRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListOrderCommand request
    /// </summary>
    /// <param name="request">The ListOrder command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The order details if found</returns>
    public async Task<ListOrderResult> Handle(ListOrderCommand request, CancellationToken cancellationToken)
    {

        var orders = await _orderRepository.GetAllAsync(cancellationToken);

        return _mapper.Map<ListOrderResult>(orders);
    }
}
