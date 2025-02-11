namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct
{
    /// <summary>
    /// Response model for ListProduct operation
    /// </summary>
    public class ListProductResult
    {
        /// <summary>
        /// The list of products
        /// </summary>
        public List<ProductResult> Products { get; set; } = new();
    }
}
