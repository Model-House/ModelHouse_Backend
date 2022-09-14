using System.Text.Json.Serialization;
using backend.RemodelKing.Domain.Models;

namespace backend.Register.Domain.Models;

public class Business
{
    /*public string? _description = String.Empty;
    public string? _img = String.Empty;
    public string? _webSite = String.Empty;
    public string? _days = String.Empty;*/
    public string Name { get; set; } = String.Empty;
    public long Phone { get; set; }

    public String Description { get; set; } = String.Empty;
    public String Img { get; set; } = String.Empty;
    public String Address { get; set; } = String.Empty;
    public float Score { get; set; }

    public String WebSite { get; set; } = String.Empty;

    public String Days { get; set; } = String.Empty;
    
    //Security
    public long Id { get; set; }
    public string Email { get; set; } = String.Empty;
    [JsonIgnore] 
    public string PasswordHash { get; set; }
    //public string ConfirmPassword { get; set; } = String.Empty;

    //Relationship
    //public IList<Client> Client { get; set; } = new List<Client>();
    public IList<BusinessProject> BusinessProjects { get; set; } = new List<BusinessProject>();
    public IList<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    public Payment Payment { get; set; }
    


}