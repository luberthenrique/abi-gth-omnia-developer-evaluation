namespace Ambev.DeveloperEvaluation.Application.Orders.ListOrder
{
    /// <summary>
    /// Response model for ListOrder operation
    /// </summary>
    public class ListOrderResult
    {
        /// <summary>
        /// The list of orders
        /// </summary>
        public List<OrderResult> Orders { get; set; } = new();
    }
}
