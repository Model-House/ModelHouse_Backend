using System.ComponentModel.DataAnnotations;

namespace backend.Register.Resources;

public class SaveClientResource: SaveUserResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Img { get; set; }

    [Required]
    public string Email { get; set; }

}