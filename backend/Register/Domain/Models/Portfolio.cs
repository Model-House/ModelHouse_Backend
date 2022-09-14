namespace backend.Register.Domain.Models;

public class Portfolio
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public long ContractDate { get; set; }
    
    public string Email { get; set; }
    
    public long Phone { get; set; }
    
    public Business Business { get; set; }
    public long BusinessId { get; set; }
    public IList<Activity> Activities { get; set; } = new List<Activity>();
}