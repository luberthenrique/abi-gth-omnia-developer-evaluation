namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// API response model for CreateProduct operation
/// </summary>
public class CreateProductResponse
{
    /// <summary>
    /// The unique identifier of the created product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The product's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The product's price
    /// </summary>
    public double Price { get; set; }
}
