using Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Orders;

public class UpdateOrderRequestProfile : Profile
{
    public UpdateOrderRequestProfile()
    {
        CreateMap<UpdateOrderRequest, UpdateOrderCommand>();
        CreateMap<UpdateOrderItemRequest, UpdateOrderItemCommand>();
        CreateMap<UpdateOrderResult, UpdateOrderResponse>();
    }
}