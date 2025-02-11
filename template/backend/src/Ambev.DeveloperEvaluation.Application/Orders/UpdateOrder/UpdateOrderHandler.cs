using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder;

/// <summary>
/// Handler for processing UpdateOrderCommand requests
/// </summary>
public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderResult>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateOrderHandler
    /// </summary>
    /// <param name="orderRepository">The order repository</param>
    /// <param name="orderRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateOrderCommand</param>
    public UpdateOrderHandler(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the UpdateOrderCommand request
    /// </summary>
    /// <param name="command">The UpdateOrder command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated order details</returns>
    public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateOrderCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingOrder = await _orderRepository.GetBySalesNumberAsync(command.SalesNumber, cancellationToken);
        if (existingOrder != null && existingOrder.Id != command.Id)
            throw new InvalidOperationException($"Order with sales number {command.SalesNumber} already exists");

        var order = await _orderRepository.GetByIdAsync(command.Id, cancellationToken);
        if (order == null)
            throw new KeyNotFoundException($"Order with ID {command.Id} not found");

        order.Update(command.SalesNumber, command.OrderDate, command.Client, command.Branch);

        foreach (var orderItemCommand in command.Items)
        {
            var product = await _productRepository.GetByIdAsync(orderItemCommand.ProductId, cancellationToken);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {orderItemCommand.ProductId} not found");

            var existingOrderItem = order.Items.FirstOrDefault(c => c.ProductId == orderItemCommand.ProductId);
            if (existingOrderItem != null && existingOrderItem.Quantity != orderItemCommand.Quantity)
            {
                existingOrderItem.Update(product.Price, orderItemCommand.Quantity);
                if (existingOrderItem.TotalPrice <= 0)
                    throw new InvalidOperationException($"Order item with product id {orderItemCommand.ProductId} has a price less than or equal to zero");
            }
            else if (existingOrderItem == null)
            {
                var orderItem = _mapper.Map<OrderItem>(orderItemCommand);
                orderItem.CalculatePriceAndDiscount(product.Price);
                order.Items.Add(orderItem);
            }

        }

        var orderItemIdsForRemove = order.Items.Select(c => c.ProductId).Except(command.Items.Select(c => c.ProductId));
        foreach (var orderItemForemove in order.Items.Where(c => orderItemIdsForRemove.Contains(c.ProductId)))
            order.Items.Remove(orderItemForemove);

        order.CalculateTotalPrice();
        order.CalculateTotalDiscount();

        var updatedOrder = await _orderRepository.UpdateAsync(order, cancellationToken);
        var result = _mapper.Map<UpdateOrderResult>(updatedOrder);
        return result;
    }
}
