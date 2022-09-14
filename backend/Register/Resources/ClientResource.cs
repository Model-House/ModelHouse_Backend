using System.Text.Json.Serialization;

namespace backend.Register.Resources;

public class ClientResource
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
    public string Address { get; set; }
    public string Img { get; set; }
    
}