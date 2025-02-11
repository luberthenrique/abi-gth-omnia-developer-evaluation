using Ambev.DeveloperEvaluation.Application.Orders.ListOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.ListOrder;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Orders;

public class ListOrderRequestProfile : Profile
{
    public ListOrderRequestProfile()
    {
        CreateMap<ListOrderRequest, ListOrderCommand>();
        CreateMap<ListOrderResult, ListOrderResponse>();
        CreateMap<OrderResult, OrderResponse>();
    }
}