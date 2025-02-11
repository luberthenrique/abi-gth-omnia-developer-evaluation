using Ambev.DeveloperEvaluation.Application.Products.ListProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Products;

public class ListProductRequestProfile : Profile
{
    public ListProductRequestProfile()
    {
        CreateMap<ListProductRequest, ListProductCommand>();
        CreateMap<ListProductResult, ListProductResponse>();
    }
}