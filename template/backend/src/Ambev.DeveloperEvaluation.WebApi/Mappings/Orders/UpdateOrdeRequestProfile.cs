using Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Orders;

public class UpdateOrderRequestProfile : Profile
{
    public UpdateOrderRequestProfile()
    {
        CreateMap<UpdateOrderRequest, UpdateOrderCommand>();
        CreateMap<UpdateOrderItemRequest, UpdateOrderItemCommand>();
        CreateMap<CreateProductResult, CreateProductResponse>();
    }
}