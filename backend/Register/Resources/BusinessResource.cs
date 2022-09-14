namespace backend.Register.Resources;

public class BusinessResource: UserResource
{
    public string Name { get; set; }
    public long Phone { get; set; }
    public String Description { get; set; }
    public String Img { get; set; }
    public String Address { get; set; }
    public float Score { get; set; }
    public String WebSite { get; set; }
    public String Days { get; set; }
}