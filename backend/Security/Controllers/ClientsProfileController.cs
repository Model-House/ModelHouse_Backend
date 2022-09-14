using AutoMapper;
using backend.Register.Domain.Models;
using backend.Security.Authorization.AttributesClient;
using backend.Security.Domain.Services;
using backend.Security.Domain.Services.Communication;
using backend.Security.Resources;
using Microsoft.AspNetCore.Mvc;

namespace backend.Security.Controllers;
[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class ClientsProfileController: ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public ClientsProfileController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _userService.AuthenticateClient(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterClientRequest request)
    {
        //var model = _mapper.Map<RegisterRequest, Business>(request);
        var response = await _userService.RegisterAsyncClient(request);
        //if (!result.Success)
        //  return BadRequest(result.Message);
        //var resource = _mapper.Map<Business, RegisterRequest>(result.Resource);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsyncClient();
        var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientProfileResource>>(users);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsyncClient(id);
        var resource = _mapper.Map<Client, ClientProfileResource>(user);

        return Ok(resource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _userService.UpdateAsyncClient(id, request);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsyncClient(id);
        return Ok(new { message = "User deleted successfully" });
    }
}