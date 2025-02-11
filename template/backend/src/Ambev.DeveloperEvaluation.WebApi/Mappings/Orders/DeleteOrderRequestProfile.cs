using Ambev.DeveloperEvaluation.Application.Orders.DeleteOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.DeleteOrder;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Orders;

public class DeleteOrderRequestProfile : Profile
{
    public DeleteOrderRequestProfile()
    {
        CreateMap<DeleteOrderRequest, DeleteOrderCommand>();
    }
}