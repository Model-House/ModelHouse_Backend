using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Domain.Services;
using backend.Register.Resources;
using backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace backend.Register.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class BusinessProjectsController: ControllerBase
{
    private readonly IBusinessProjectService _businessProjectService;
    private readonly IMapper _mapper;

    public BusinessProjectsController(IBusinessProjectService businessProjectService, IMapper mapper)
    {
        _businessProjectService = businessProjectService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<BusinessProjectResource>> GetAllAsync()
    {
        var businessProjects = await _businessProjectService.ListAsync();
        var resources = _mapper.Map<IEnumerable<BusinessProject>, IEnumerable<BusinessProjectResource>>(businessProjects);
        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBusinessProjectResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var businessProject = _mapper.Map<SaveBusinessProjectResource, BusinessProject>(resource);

        var result = await _businessProjectService.CreateAsync(businessProject);

        if (!result.Success)
            return BadRequest(result.Message);

        var clientResource = _mapper.Map<BusinessProject, BusinessProjectResource>(result.Resource);
        return Ok(clientResource);
    }
    [HttpGet("{id}")]
    public async Task<BusinessProjectResource> GetAccountById(long id)
    {
        var businessesAccountById = await _businessProjectService.GetBusinessProjectById(id);
        var resources = _mapper.Map<BusinessProject, BusinessProjectResource>(businessesAccountById.Resource);
        return resources;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _businessProjectService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var businessProjectResource = _mapper.Map<BusinessProject, BusinessProjectResource>(result.Resource);

        return Ok(businessProjectResource);
    } 
}