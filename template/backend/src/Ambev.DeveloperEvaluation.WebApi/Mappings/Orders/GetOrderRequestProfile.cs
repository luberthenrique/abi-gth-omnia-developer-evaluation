using Ambev.DeveloperEvaluation.Application.Orders.GetOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Orders;

public class GetOrderRequestProfile : Profile
{
    public GetOrderRequestProfile()
    {
        CreateMap<GetOrderRequest, GetOrderCommand>();
        CreateMap<GetOrderResult, GetOrderCommand>();
        CreateMap<GetOrderItemResult, GetOrderItemResponse>();
    }
}