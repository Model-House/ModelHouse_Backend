using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Resources;
using backend.Security.Authorization.Attributes;
using backend.Security.Domain.Models;
using backend.Security.Domain.Services;
using backend.Security.Domain.Services.Communication;
using backend.Security.Resources;
using backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace backend.Security.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _userService.Authenticate(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        //var model = _mapper.Map<RegisterRequest, Business>(request);
        var response = await _userService.RegisterAsync(request);
        //if (!result.Success)
          //  return BadRequest(result.Message);
        //var resource = _mapper.Map<Business, RegisterRequest>(result.Resource);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Business>, IEnumerable<UserResourceX>>(users);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<Business, UserResourceX>(user);

        return Ok(resource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }
}