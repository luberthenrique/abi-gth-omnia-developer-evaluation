using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;

/// <summary>
/// Handler for processing CreateOrderCommand requests
/// </summary>
public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateOrderHandler
    /// </summary>
    /// <param name="orderRepository">The order repository</param>
    /// <param name="orderRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateOrderCommand</param>
    public CreateOrderHandler(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateOrderCommand request
    /// </summary>
    /// <param name="command">The CreateOrder command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created order details</returns>
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateOrderCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingOrder = await _orderRepository.GetBySalesNumberAsync(command.SalesNumber, cancellationToken);
        if (existingOrder != null)
            throw new InvalidOperationException($"Order with sales number {command.SalesNumber} already exists");

        var order = _mapper.Map<Order>(command);
        foreach (var orderItem in order.OrderItems)
        {
            var product = await _productRepository.GetByIdAsync(orderItem.ProductId, cancellationToken);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {orderItem.ProductId} not found");
            orderItem.CalculatePriceAndDiscount(product.Price);

            if (orderItem.TotalPrice <= 0)
                throw new InvalidOperationException($"Order item with product id {orderItem.ProductId} has a price less than or equal to zero");
        }

        order.CalculateTotalPrice();
        order.CalculateTotalDiscount();

        var createdOrder = await _orderRepository.CreateAsync(order, cancellationToken);
        var result = _mapper.Map<CreateOrderResult>(createdOrder);
        return result;
    }
}
