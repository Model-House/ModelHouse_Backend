using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Domain.Services;
using backend.Register.Resources;
using backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace backend.Register.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class RequestController : ControllerBase
{
    private readonly IRequestService _requestService;
    private readonly IMapper _mapper;

    public RequestController(IRequestService requestService, IMapper mapper)
    {
        _requestService = requestService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<RequestResource>> GetAllAsync()
    {
        var request = await _requestService.ListAsync();
        var resource = _mapper.Map<IEnumerable<Request>, IEnumerable<RequestResource>>(request);
        return resource;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRequestResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var request = _mapper.Map<SaveRequestResource, Request>(resource);

        var result = await _requestService.CreateAsync(request);

        if (!result.Success)
            return BadRequest(result.Message);

        var clientResource = _mapper.Map<Request, RequestResource>(result.Resource);
        return Ok(clientResource);
    }
}