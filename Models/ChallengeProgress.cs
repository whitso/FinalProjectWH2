namespace FinalProjectWH.Models
{
public class Progress
{
    public int ProgressId { get; set; }
    public int UserId { get; set; }
    public int ChallengeId { get; set; }
    public bool IsCompleted { get; set; }
    public User User { get; set; }
    public Challenge Challenge { get; set; }
}
}