using System.Text.Json.Serialization;
using ModelHouse.Interest.Domain.Models;
using ModelHouse.Profile.Domain.Models;

namespace ModelHouse.Security.Domain.Models;

public class User
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    
    [JsonIgnore]
    public string PasswordHash { get; set; }
    public IList<Project> Projects { get; set; } = new List<Project>();
    public IList<Order> Orders { get; set; } = new List<Order>();
    public IList<Post> Posts { get; set; } = new List<Post>();
    public IList<Area> Areas { get; set; } = new List<Area>();
}