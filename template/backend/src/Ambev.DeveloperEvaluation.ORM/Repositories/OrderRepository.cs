using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IOrderRepository using Entity Framework Core
/// </summary>
public class OrderRepository : IOrderRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of OrderRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public OrderRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new order in the database
    /// </summary>
    /// <param name="order">The order to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created order</returns>
    public async Task<Order> CreateAsync(Order order, CancellationToken cancellationToken = default)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return order;
    }

    /// <summary>
    /// Update a order in the database
    /// </summary>
    /// <param name="order">The order to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated order</returns>
    public async Task<Order> UpdateAsync(Order order, CancellationToken cancellationToken = default)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync(cancellationToken);
        return order;
    }

    /// <summary>
    /// Retrieves a order by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the order</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The order if found, null otherwise</returns>
    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Orders.Include(c => c.Items).ThenInclude(c => c.Product).FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a order by their sales number
    /// </summary>
    /// <param name="salesNumber">The sales number of the order</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The order if found, null otherwise</returns>
    public async Task<Order?> GetBySalesNumberAsync(string salesNumber, CancellationToken cancellationToken = default)
    {
        return await _context.Orders.FirstOrDefaultAsync(o => o.SalesNumber == salesNumber, cancellationToken);
    }

    /// <summary>
    /// Retrieves all orders
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of irders</returns>
    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Orders.ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Deletes a order from the database
    /// </summary>
    /// <param name="id">The unique identifier of the order to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the order was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await GetByIdAsync(id, cancellationToken);
        if (order == null)
            return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
