using System.ComponentModel.DataAnnotations;

namespace ModelHouse.Interest.Resources;

public class UpdateAreaResource
{
    public bool Check { get; set; }
    [Required]
    public long UserId { get; set; }
}