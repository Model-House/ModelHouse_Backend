namespace backend.Security.Domain.Services.Communication;

public class RegisterClientResponse
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public long Phone { get; set; }
}