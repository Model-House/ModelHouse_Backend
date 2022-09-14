namespace backend.Register.Domain.Models;

public class Activity
{
    public long Id { get; set; }
    
    public string Description { get; set; }
    
    public string Title { get; set; }
    public string StartDate { get; set; }
    
    public string FinishDate { get; set; }

    public long PortfolioId { get; set; }
    public Portfolio Portfolio { get; set; }
}