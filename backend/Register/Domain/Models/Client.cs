using System.Text.Json.Serialization;

namespace backend.Register.Domain.Models;

public class Client
{
    public long Id { get; set; }
    
    public string Name { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    
    public string Email { get; set; } = String.Empty;
    
    [JsonIgnore] 
    public string PasswordHash { get; set; }

    public string Phone { get; set; }
    public string Address { get; set; } = String.Empty;
    public string Img { get; set; } = String.Empty;

    public IList<Request> Requests { get; set; } = new List<Request>();

    
}