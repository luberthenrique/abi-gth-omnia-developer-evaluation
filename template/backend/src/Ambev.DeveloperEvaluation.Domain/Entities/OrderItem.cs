using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a order items in the system.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class OrderItem : BaseEntity
    {
        /// <summary>
        /// Gets the item's order id.
        /// Must not be null or empty.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Gets the item's product id.
        /// Must not be null or empty.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets the item's quantity.
        /// Must be greater than zero.
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Gets the item's unit price.
        /// Must be greater than zero.
        /// </summary>
        public double UnitPrice { get; set; }

        /// <summary>
        /// Gets the item's discount.
        /// </summary>
        public double Discount { get; set; }

        /// <summary>
        /// Must be greater than zero.
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// Gets the order related to item.
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Gets the product related to item.
        /// </summary>
        public virtual Product Product { get; set; }

        public void CalculatePriceAndDiscount(double unitPrice)
        {
            UnitPrice = unitPrice;

            if (Quantity >= 10)
                Discount = (UnitPrice * Quantity) * 0.2;
            else if (Quantity >= 4)
                Discount = (UnitPrice * Quantity) * 0.1;

            TotalPrice = (UnitPrice * Quantity) - Discount;
        }

        public void Update(double unitPrice, double quantity)
        {
            UnitPrice = unitPrice;
            Quantity = quantity;

            CalculatePriceAndDiscount(UnitPrice);
        }

        public ValidationResultDetail Validate()
        {
            var validator = new OrderItemValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
