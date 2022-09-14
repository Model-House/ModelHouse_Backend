using System.ComponentModel.DataAnnotations;

namespace backend.Register.Resources;

public class SaveBusinessResource: SaveUserResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    public long Phone { get; set; }
    
    [Required]
    public String Description { get; set; }
    
    [Required]
    public String Img { get; set; }
    
    [Required]
    public String Address { get; set; }
    public float Score { get; set; }
    public String WebSite { get; set; }
    [Required]
    public String Days { get; set; }
}