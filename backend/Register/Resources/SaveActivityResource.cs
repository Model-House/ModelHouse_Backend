using System.ComponentModel.DataAnnotations;

namespace backend.Register.Resources;

public class SaveActivityResource
{
   
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string StartDate { get; set; }
    
    [Required]
    public string FinishDate { get; set; }
    
    [Required]
    public long PortfolioId { get; set; }
}