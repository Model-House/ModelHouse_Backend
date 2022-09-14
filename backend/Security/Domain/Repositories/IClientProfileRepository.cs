using backend.Register.Domain.Models;

namespace backend.Security.Domain.Repositories;

public interface IClientProfileRepository
{
    Task<IEnumerable<Client>> ListAsync();
    Task AddAsync(Client user);
    Task<Client> FindByIdAsync(long id);
    /*Task<Business> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);*/
    Task<Client> FindByEmailAsync(string email);
    bool ExistsByEmail(string email);
    Client FindById(long id);
    void Update(Client user);
    void Remove(Client user);
}