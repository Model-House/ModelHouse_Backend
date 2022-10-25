using System.ComponentModel.DataAnnotations;

namespace ModelHouse.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}