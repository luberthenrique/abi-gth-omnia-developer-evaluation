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
        CreateMap<CreateOrderCommand, Product>();
        CreateMap<CreateOrderItemCommand, OrderItem>();
        CreateMap<Product, CreateOrderResult>();
    }
}
