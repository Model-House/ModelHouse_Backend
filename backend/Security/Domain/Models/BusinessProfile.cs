using System.ComponentModel;
using System.Text.Json.Serialization;
using Google.Protobuf.Reflection;

namespace backend.Security.Domain.Models;

public class BusinessProfile
{
    public string? _description = String.Empty;
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public long Phone { get; set; }
    public string Address { get; set; }

    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }
    //Security 
    [JsonIgnore]
    public string PasswordHash { get; set; }
}