namespace backend.Register.Resources;

public class ActivityResource
{
    public long Id { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public string StartDate { get; set; }
    public string FinishDate { get; set; }
    public PortfolioResource Portfolio { get; set; }
    public long PortfolioId { get; set; }
}