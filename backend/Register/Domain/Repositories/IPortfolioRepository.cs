using backend.Register.Domain.Models;

namespace backend.Register.Domain.Repositories;

public interface IPortfolioRepository
{
    Task<IEnumerable<Portfolio>> ListAsync();
    Task<Portfolio> FindByIdAsync(long id);
    Task AddAsync(Portfolio portfolio);
    void DeleteAsync(Portfolio portfolio);
}