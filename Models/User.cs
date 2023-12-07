namespace FinalProjectWH.Models
{
public class User
{
    public int UserId { get; set; }
    public string Gamertag { get; set; }
    public ICollection<Progress> Progress { get; set; }
}
}