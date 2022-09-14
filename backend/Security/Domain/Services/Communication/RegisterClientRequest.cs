using System.ComponentModel.DataAnnotations;

namespace backend.Security.Domain.Services.Communication;

public class RegisterClientRequest
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public long Phone { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
}