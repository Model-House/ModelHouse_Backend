using backend.Register.Domain.Models;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Domain.Services;

public interface IBusinessService
{
    Task<IEnumerable<Business>> ListAsync();
    Task<BusinessResponse> CreateAsync(Business business);
    Task<BusinessResponse> GetAccount(string email);
    Task<BusinessResponse> GetAccountById(long id);
    Task<BusinessResponse> UpdateAsync(long id, Business business);
}