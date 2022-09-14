namespace backend.Register.Resources;

public class RequestResource
{
    public long Id { get; set; }
    public string BusinessName { get; set; }
    public string Email { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ClientResource Client { get; set; }
    public long ClientId { get; set; }
}