using Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.Application.Orders.DeleteOrder;
using Ambev.DeveloperEvaluation.Application.Orders.GetOrder;
using Ambev.DeveloperEvaluation.Application.Orders.ListOrder;
using Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.DeleteOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.ListOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders;

/// <summary>
/// Controller for managing order operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrdersController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of OrdersController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public OrdersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new order
    /// </summary>
    /// <param name="request">The order creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created order details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateOrderResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateOrderRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateOrderCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, _mapper.Map<CreateOrderResponse>(response));
    }

    /// <summary>
    /// Retrieves a order by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the order</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The order details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetOrderResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrder([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetOrderRequest { Id = id };
        var validator = new GetOrderRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetOrderCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<GetOrderResponse>(response));
    }


    /// <summary>
    /// Retrieves all order
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The order details if found</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<ListOrderResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListOrders(CancellationToken cancellationToken)
    {
        var request = new ListOrderRequest { };

        var command = _mapper.Map<ListOrderCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<ListOrderResponse>(response));
    }

    /// <summary>
    /// Creates a new order
    /// </summary>
    /// <param name="request">The order creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created order details</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateOrderResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
            return BadRequest("The request id is different from the url");

        var validator = new UpdateOrderRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateOrderCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<UpdateOrderResponse>(response));
    }

    /// <summary>
    /// Deletes a order by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the order to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the order was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteOrder([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteOrderRequest { Id = id };
        var validator = new DeleteOrderRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteOrderCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(null);
    }
}
