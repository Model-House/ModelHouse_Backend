using ModelHouse.Security.Domain.Models;

namespace ModelHouse.Interest.Domain.Models;

public class Area
{
    public long Id { get; set; }
    
    public string Name { get; set; }

    public bool Check { get; set; }
    public User User { get; set; }
    
    public long UserId { get; set; }
}