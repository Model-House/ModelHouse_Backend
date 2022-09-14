using backend.Register.Domain.Models;
using backend.Security.Domain.Models;

namespace backend.Security.Domain.Repositories;

public interface IBusinessProfileRepository
{
    Task<IEnumerable<Business>> ListAsync();
    Task AddAsync(Business user);
    Task<Business> FindByIdAsync(long id);
    /*Task<Business> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);*/
    Task<Business> FindByEmailAsync(string email);
    bool ExistsByEmail(string email);
    Business FindById(long id);
    void Update(Business user);
    void Remove(Business user);
}