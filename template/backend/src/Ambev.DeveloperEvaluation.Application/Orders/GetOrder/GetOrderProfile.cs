using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrder;

/// <summary>
/// Profile for mapping between Order entity and GetOrderResult
/// </summary>
public class GetOrderProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetOrder operation
    /// </summary>
    public GetOrderProfile()
    {
        CreateMap<Order, GetOrderResult>().ForMember(c => c.OrderDate, map => map.MapFrom(c => c.OrderDate.ToLocalTime()));
        CreateMap<OrderItem, GetOrderItemResult>()
            .ForMember(c => c.ProductName, map => map.MapFrom(c => c.Product.Name))
            .ForMember(c => c.ProductPrice, map => map.MapFrom(c => c.Product.Price));
    }
}
