using System.ComponentModel.DataAnnotations;

namespace backend.Register.Resources;

public class SaveBusinessProjectResource
{
    [Required]
    [MaxLength(50)]
    public string Style { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Location { get; set; }
    
    public string Img { get; set; }
    
    public int Score { get; set; }
    
    [Required]
    public int BusinessId { get; set; }
}