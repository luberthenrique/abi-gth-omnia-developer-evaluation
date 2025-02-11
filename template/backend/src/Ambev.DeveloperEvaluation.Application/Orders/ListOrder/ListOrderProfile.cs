using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Orders.ListOrder;

/// <summary>
/// Profile for mapping between Order entity and ListOrderResult
/// </summary>
public class ListOrderProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListOrder operation
    /// </summary>
    public ListOrderProfile()
    {
        CreateMap<Order, OrderResult>();
    }
}

