using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;
using backend.Shared.Domain.Repositories;

namespace backend.Register.Services;

public class ClientServiceImpl: IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ClientServiceImpl(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Client>> ListAsync()
    {
        return await _clientRepository.ListAsync();
    }

    public async Task<ClientResponse> CreateAsync(Client client)
    {
        try
        {
            await _clientRepository.AddAsync(client);
            await _unitOfWork.CompleteAsync();
            return new ClientResponse(client);
        }
        catch (Exception e)
        {
            return new ClientResponse($"Failed to register a client: {e.Message}");
        }
    }

    public async Task<ClientResponse> GetAccount(string email)
    {
        try
        {
            var currentUser = await _clientRepository.FindByEmailAsync(email);
            return new ClientResponse(currentUser);
        }
        catch (Exception e)
        {
            return new ClientResponse($"Failed to find a current user client: {e.Message}");
        }
    }

    public async Task<ClientResponse> GetAccountById(long id)
    {
        try
        {
            var currentUser = await _clientRepository.FindByIdAsync(id);
            return new ClientResponse(currentUser);
        }
        catch (Exception e)
        {
            return new ClientResponse($"Failed to find a current user client: {e.Message}");
        }
    }

    public async Task<ClientResponse> UpdateAsync(long id, Client client)
    {
        var existingClient = await _clientRepository.FindByIdAsync(id);
        if (existingClient == null)
            return new ClientResponse("Client already exists");
        existingClient.Name = client.Name;
        existingClient.LastName = client.LastName;
        existingClient.Id = client.Id;
        existingClient.Email = client.Email;
        existingClient.Phone = client.Phone;
        existingClient.Address = client.Address;
        existingClient.Img = client.Img;
        try
        {
            _clientRepository.Update(existingClient);
            await _unitOfWork.CompleteAsync();
            return new ClientResponse(existingClient);
        }
        catch (Exception e)
        {
            return new ClientResponse($"Failed to updating the client: {e.Message}");
        }
    }
}