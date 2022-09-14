using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Domain.Services;
using backend.Register.Resources;
using backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace backend.Register.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class BusinessesController: ControllerBase
{
    private readonly IBusinessService _businessService;
    private readonly IMapper _mapper;

    public BusinessesController(IBusinessService businessService, IMapper mapper)
    {
        _businessService = businessService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<BusinessResource>> GetAllAsync()
    {
        
        var businesses = await _businessService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Business>, IEnumerable<BusinessResource>>(businesses);
        return resources;
    }
    [HttpGet("/api/v1/businesses/account/{email}")]
    public async Task<BusinessResource> GetAccount(string email)
    {
        var businessesAccount = await _businessService.GetAccount(email);
        Console.WriteLine(businessesAccount.Resource);
        var resources = _mapper.Map<Business, BusinessResource>(businessesAccount.Resource);
        return resources;
    }
    [HttpGet("/api/v1/businesses/id/{businessId}")]
    public async Task<BusinessResource> GetAccountById(long businessId)
    {
        var businessesAccountById = await _businessService.GetAccountById(businessId);
        var resources = _mapper.Map<Business, BusinessResource>(businessesAccountById.Resource);
        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBusinessResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var business = _mapper.Map<SaveBusinessResource, Business>(resource);

        var result = await _businessService.CreateAsync(business);

        if (!result.Success)
            return BadRequest(result.Message);

        var clientResource = _mapper.Map<Business, BusinessResource>(result.Resource);
        return Ok(clientResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] SaveBusinessResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var business = _mapper.Map<SaveBusinessResource, Business>(resource);
        var result = await _businessService.UpdateAsync(id, business);
        if (!result.Success)
            return BadRequest(result.Message);
        var businessResource = _mapper.Map<Business, BusinessResource>(result.Resource);
        return Ok(businessResource);

    }
}