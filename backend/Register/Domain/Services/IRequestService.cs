using backend.Register.Domain.Models;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Domain.Services;

public interface IRequestService
{
    Task<IEnumerable<Request>> ListAsync();
    Task<RequestResponse> CreateAsync(Request request);
}