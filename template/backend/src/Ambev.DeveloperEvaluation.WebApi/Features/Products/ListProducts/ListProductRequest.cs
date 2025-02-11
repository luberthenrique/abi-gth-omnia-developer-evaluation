namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Request model for getting a product list
/// </summary>
public class ListProductRequest
{
    /// <summary>
    /// The name for identifier of the products to retrieve
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
