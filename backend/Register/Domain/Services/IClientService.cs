using backend.Register.Domain.Models;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Domain.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> ListAsync();
    Task<ClientResponse> CreateAsync(Client client);
    Task<ClientResponse> GetAccount(string email);
    Task<ClientResponse> GetAccountById(long id);
    Task<ClientResponse> UpdateAsync(long id, Client client);
}