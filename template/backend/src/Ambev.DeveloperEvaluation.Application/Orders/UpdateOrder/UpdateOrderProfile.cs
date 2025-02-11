using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder;

/// <summary>
/// Profile for mapping between Order entity and UpdateOrderResponse
/// </summary>
public class UpdateOrderProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateOrder operation
    /// </summary>
    public UpdateOrderProfile()
    {
        CreateMap<UpdateOrderCommand, Order>();
        CreateMap<UpdateOrderItemCommand, OrderItem>();
        CreateMap<Order, UpdateOrderResult>();
    }
}
