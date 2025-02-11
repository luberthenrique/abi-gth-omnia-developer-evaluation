namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

/// <summary>
/// API response model for ListProduct operation
/// </summary>
public class ListProductResponse
{
    /// <summary>
    /// The list of the product
    /// </summary>
    public List<ListProduct> Products { get; set; } = [];
}
