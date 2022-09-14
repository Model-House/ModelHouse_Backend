using backend.Register.Domain.Models;
using backend.Shared.Domain.Services.Communication;

namespace backend.Register.Domain.Services.Communication;

public class ClientResponse: BaseResponse<Client>
{
    public ClientResponse(string message) : base(message)
    {
    }

    public ClientResponse(Client resource) : base(resource)
    {
    }
}