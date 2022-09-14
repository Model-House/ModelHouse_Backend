namespace backend.Register.Domain.Models;

public class BusinessProject
{
    public long Id { get; set; }
    public string Style { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Img { get; set; }
    public int Score { get; set; }
    public long BusinessId { get; set; }

    public Business Business;
}