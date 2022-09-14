
namespace backend.Shared.Domain.Services.Communication;

public abstract class BaseResponse<T>
{
    protected BaseResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }

    protected BaseResponse(T resource)
    {
        Success = true;
        Resource = resource;
        Message = string.Empty;
    }

    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T? Resource { get; private set; }
}