using ModelHouse.Security.Resources;

namespace ModelHouse.Interest.Resources;

public class AreaResource
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool Check { get; set; }
    public UserResource User { get; set; }
    public long UserId { get; set; }
}