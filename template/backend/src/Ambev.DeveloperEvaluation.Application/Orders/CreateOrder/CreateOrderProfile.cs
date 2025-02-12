using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;

/// <summary>
/// Profile for mapping between Order entity and CreateOrderResponse
/// </summary>
public class CreateOrderProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProduct operation
    /// </summary>
    public CreateOrderProfile()
    {
        CreateMap<CreateOrderCommand, Order>()
            .ForMember(c => c.OrderDate, c => c.MapFrom(map => map.OrderDate.ToUniversalTime()));
        CreateMap<CreateOrderItemCommand, OrderItem>();
        CreateMap<Order, CreateOrderResult>();
    }
}
