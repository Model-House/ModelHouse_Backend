namespace backend.Register.Domain.Models;

public abstract class User
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

}