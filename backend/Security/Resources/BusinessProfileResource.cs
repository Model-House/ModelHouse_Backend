using backend.Register.Resources;

namespace backend.Security.Resources;
public class BusinessProfileResource
{
    /*public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }*/
    public long Id { get; set; }
    public string Name { get; set; }
    public long Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public string WebSite { get; set; }
    public string Days { get; set; }
}