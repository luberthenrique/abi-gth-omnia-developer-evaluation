namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

/// <summary>
/// API response model for a single Product
/// </summary>
public class ProductResponse
{
    /// <summary>
    /// The unique identifier of the product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The product's name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The product's price
    /// </summary>
    public double Price { get; set; }
}
