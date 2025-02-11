using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Order entity operations
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Creates a new order in the repository
    /// </summary>
    /// <param name="order">The order to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task<Order> CreateAsync(Order order, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a order in the repository
    /// </summary>
    /// <param name="order">The order to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task<Order> UpdateAsync(Order order, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a order by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the order</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The order if found, null otherwise</returns>
    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a order by their sales number
    /// </summary>
    /// <param name="salesNumber">The sales number of the order</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The order if found, null otherwise</returns>
    Task<Order?> GetBySalesNumberAsync(string salesNumber, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all orders
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of irders</returns>
    Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a order from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the order to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the order was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
