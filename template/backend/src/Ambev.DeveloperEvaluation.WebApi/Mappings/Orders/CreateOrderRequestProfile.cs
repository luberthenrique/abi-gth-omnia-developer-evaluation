using Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Orders;

public class CreateOrderRequestProfile : Profile
{
    public CreateOrderRequestProfile()
    {
        CreateMap<CreateOrderRequest, CreateOrderCommand>();
        CreateMap<CreateOrderItemRequest, CreateOrderItemCommand>();
        CreateMap<CreateOrderResult, CreateOrderResponse>();
    }
}