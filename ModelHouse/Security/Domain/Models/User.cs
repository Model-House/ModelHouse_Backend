using System.Text.Json.Serialization;
using LearningCenter.API.Interest.Services;
using ModelHouse.Interest.Domain.Models;
using ModelHouse.Profile.Domain.Models;

namespace ModelHouse.Security.Domain.Models;

public class User
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Image { get; set; }
    public string Phone { get; set; }


    [JsonIgnore]
    public string PasswordHash { get; set; }
    public IList<Order> Orders { get; set; } = new List<Order>();
    public IList<Post> Posts { get; set; } = new List<Post>();
    public IList<Area> Areas { get; set; } = new List<Area>();
    public IList<Room> Rooms { get; set; } = new List<Room>();
    public IList<Service> Services { get; set; } = new List<Service>();
    public IList<Notification> Notifications { get; set; } = new List<Notification>();
    public IList<Contact> Contacts { get; set; } = new List<Contact>();

}