using backend.Register.Domain.Models;
using backend.Security.Domain.Models;

namespace backend.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    string GenerateToken(Business user);
    int? ValidateToken(string token);
    string GenerateTokenClient(Client user);
}