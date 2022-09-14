using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Domain.Services;
using backend.Register.Resources;
using backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace backend.Register.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PortfoliosController: ControllerBase
{
    private readonly IPortfolioService _portfolioService;
    private readonly IMapper _mapper;

    public PortfoliosController(IPortfolioService portfolioService, IMapper mapper)
    {
        _portfolioService = portfolioService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<PortfolioResource>> GetAllAsync()
    {
        
        var portfolios = await _portfolioService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(portfolios);
        return resources;
    }
    [HttpGet("{id}")]
    public async Task<PortfolioResource> GetAccountById(long id)
    {
        var portfolioById = await _portfolioService.GetPortfolioById(id);
        var resources = _mapper.Map<Portfolio, PortfolioResource>(portfolioById.Resource);
        return resources;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _portfolioService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var businessProjectResource = _mapper.Map<Portfolio, PortfolioResource>(result.Resource);

        return Ok(businessProjectResource);
    } 
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePortfolioResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var portfolio = _mapper.Map<SavePortfolioResource, Portfolio>(resource);

        var result = await _portfolioService.CreateAsync(portfolio);

        if (!result.Success)
            return BadRequest(result.Message);

        var clientResource = _mapper.Map<Portfolio, PortfolioResource>(result.Resource);
        return Ok(clientResource);
    }
}