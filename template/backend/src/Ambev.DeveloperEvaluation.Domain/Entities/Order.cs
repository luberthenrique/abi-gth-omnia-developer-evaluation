using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a orders in the system.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Order : BaseEntity
    {
        /// <summary>
        /// Gets the order's sales number.
        /// Must not be null or empty.
        /// </summary>
        public string SalesNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets the order's data.
        /// Must not be null or empty.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets the order's client.
        /// Must not be null or empty.
        /// </summary>
        public string Client { get; set; } = string.Empty;

        /// <summary>
        /// Gets the order's branch.
        /// Must not be null or empty.
        /// </summary>
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// Gets the order's total discount.
        /// </summary>
        public double TotalDiscount { get; set; }

        /// <summary>
        /// Gets the order's total price.
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// Gets the order's is cancelled.
        /// </summary>
        public bool IsCancelled { get; set; } = false;

        /// <summary>
        /// Gets the order's items.
        /// Must not be null or empty.
        /// </summary>
        public virtual ICollection<OrderItem> Items { get; set; }


        public void Update(
            string salesNumber,
            DateTime orderDate,
            string client,
            string branch)
        {
            SalesNumber = salesNumber;
            OrderDate = orderDate;
            Client = client;
            Branch = branch;
        }

        public void CalculateTotalPrice()
        {
            TotalPrice = Items.Sum(c => c.TotalPrice);
        }

        public void CalculateTotalDiscount()
        {
            TotalDiscount = Items.Sum(c => c.Discount);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }

        public ValidationResultDetail Validate()
        {
            var validator = new OrderValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
