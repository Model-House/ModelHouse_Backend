using AutoMapper;
using LearningCenter.API.Profile.Domain.Models;
using LearningCenter.API.Profile.Domain.Services;
using LearningCenter.API.Profile.Resources;
using LearningCenter.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Profile.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class OrderController: ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<OrderResource>> GetAllAsync()
    {
        var orders = await _orderService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
        return resources;
    }
    [HttpGet("" +
             "user/{id}")]
    public async Task<IEnumerable<OrderResource>> GetAllByUserId(long id)
    {
        var projects = await _orderService.ListByUserId(id);
        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(projects);
        return resources;
    }
    [HttpGet("{id}")]
    public async Task<OrderResource> GetAccountById(long id)
    {
        var orderId = await _orderService.GetOrderById(id);
        var resources = _mapper.Map<Order, OrderResource>(orderId.Resource);
        return resources;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _orderService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var projectResource = _mapper.Map<Order, OrderResource>(result.Resource);

        return Ok(projectResource);
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveOrderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var project = _mapper.Map<SaveOrderResource, Order>(resource);

        var result = await _orderService.CreateAsync(project);

        if (!result.Success)
            return BadRequest(result.Message);

        var clientResource = _mapper.Map<Order, OrderResource>(result.Resource);
        return Ok(clientResource);
    }
}