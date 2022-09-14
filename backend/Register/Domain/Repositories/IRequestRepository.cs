using backend.Register.Domain.Models;

namespace backend.Register.Domain.Repositories;

public interface IRequestRepository
{
    Task<IEnumerable<Request>> ListAsync();
    Task<Request> FindByIdAsync(long id);
    Task AddAsync(Request request);
}