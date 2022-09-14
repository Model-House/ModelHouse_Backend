using System.ComponentModel.DataAnnotations;

namespace backend.Register.Resources;

public class SavePortfolioResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public long ContractDate { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public long Phone { get; set; }
    [Required]
    public long BusinessId { get; set; }
}