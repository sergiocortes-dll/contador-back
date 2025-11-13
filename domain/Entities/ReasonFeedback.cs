namespace domain.Entities;

public class ReasonFeedback
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
}