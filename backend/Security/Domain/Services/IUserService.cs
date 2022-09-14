using backend.Register.Domain.Models;
using backend.Register.Domain.Services.Communication;
using backend.Security.Domain.Models;
using backend.Security.Domain.Services.Communication;

namespace backend.Security.Domain.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<IEnumerable<Business>> ListAsync();
    Task<Business> GetByIdAsync(long id);
    Task<RegisterResponse> RegisterAsync(RegisterRequest request);
    Task UpdateAsync(long id, UpdateRequest request);
    Task DeleteAsync(long id);
    
    
    Task<AuthenticateResponse> AuthenticateClient(AuthenticateRequest request);
    Task<IEnumerable<Client>> ListAsyncClient();
    Task<Client> GetByIdAsyncClient(long id);
    Task<RegisterClientResponse> RegisterAsyncClient(RegisterClientRequest request);
    Task UpdateAsyncClient(long id, UpdateRequest request);
    Task DeleteAsyncClient(long id);
}