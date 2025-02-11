using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Handler for processing ListProductCommand requests
/// </summary>
public class ListProductHandler : IRequestHandler<ListProductCommand, ListProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProductHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for ListProductCommand</param>
    public ListProductHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProductCommand request
    /// </summary>
    /// <param name="request">The ListProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details if found</returns>
    public async Task<ListProductResult> Handle(ListProductCommand request, CancellationToken cancellationToken)
    {

        var products = await _productRepository.GetAllAsync(request.ProductName, cancellationToken);

        return _mapper.Map<ListProductResult>(products);
    }
}
