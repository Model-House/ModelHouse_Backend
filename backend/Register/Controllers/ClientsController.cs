
using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Domain.Services;
using backend.Register.Resources;
using backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace backend.Register.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ClientsController: ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IMapper _mapper;

    public ClientsController(IClientService clientService, IMapper mapper)
    {
        _clientService = clientService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ClientResource>> GetAllAsync()
    {
        var clients = await _clientService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
        return resources;
    }
    
    [HttpGet("/api/v1/clients/account/{email}")]
    
    public async Task<ClientResource> GetAccount(string email)
    {
        var clientAccount = await _clientService.GetAccount(email);
        Console.WriteLine(clientAccount.Resource);
        var resources = _mapper.Map<Client, ClientResource>(clientAccount.Resource);
        return resources;
    }
    
    [HttpGet("/api/v1/clients/id/{clientId}")]
    public async Task<ClientResource> GetAccountById(int clientId)
    {
        var clientAccountById = await _clientService.GetAccountById(clientId);
        var resources = _mapper.Map<Client, ClientResource>(clientAccountById.Resource);
        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveClientResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var client = _mapper.Map<SaveClientResource, Client>(resource);

        var result = await _clientService.CreateAsync(client);

        if (!result.Success)
            return BadRequest(result.Message);

        var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
        return Ok(clientResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClientResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var client = _mapper.Map<SaveClientResource, Client>(resource);
        var result = await _clientService.UpdateAsync(id, client);
        if (!result.Success)
            return BadRequest(result.Message);
        var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
        return Ok(clientResource);

    }
    
}