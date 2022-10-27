using System.ComponentModel.DataAnnotations;

namespace ModelHouse.Interest.Resources;

public class SaveAreaResource
{
    [Required]
    public string Name { get; set; }
    [Required]
    public bool Check { get; set; }
    [Required]
    public long UserId { get; set; }
}