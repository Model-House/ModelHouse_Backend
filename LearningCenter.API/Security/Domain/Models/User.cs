using System.Text.Json.Serialization;
using LearningCenter.API.Profile.Domain.Models;

namespace LearningCenter.API.Security.Domain.Models;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    
    [JsonIgnore]
    public string PasswordHash { get; set; }
    public IList<Project> Projects { get; set; } = new List<Project>();
    public IList<Order> Orders { get; set; } = new List<Order>();
}