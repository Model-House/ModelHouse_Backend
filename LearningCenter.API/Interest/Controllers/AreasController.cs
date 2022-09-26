using AutoMapper;
using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Interest.Domain.Services;
using LearningCenter.API.Interest.Domain.Services.Communication;
using LearningCenter.API.Interest.Resources;
using LearningCenter.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Interest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AreasController: ControllerBase
{
    private readonly IAreaService _areaService;
    private readonly IMapper _mapper;


    public AreasController(IAreaService areaService, IMapper mapper)
    {
        _areaService = areaService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<AreaResource>> GetAllASync()
    {
        var areas = await _areaService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Area>, IEnumerable<AreaResource>>(areas);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UpdateAreaResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var area = _mapper.Map<UpdateAreaResource, Area>(resource);

        var result = await _areaService.SaveAsync(area);

        if (!result.Success)
            return BadRequest(result.Message);

        var areaResource = _mapper.Map<Area, AreaResource>(result.Resource);

        return Ok(areaResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAreaResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var area = _mapper.Map<SaveAreaResource, Area>(resource);

        var result = await _areaService.UpdateAsync(id, area);

        if (!result.Success)
            return BadRequest(result.Message);

        var areaResource = _mapper.Map<Area, AreaResource>(result.Resource);

        return Ok(areaResource);
    }
}