namespace backend.Register.Resources;

public class PortfolioResource
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public long Phone { get; set; }
    public long ContractDate { get; set; }
    public BusinessResource Business { get; set; }
    public long BusinessId { get; set; }
}