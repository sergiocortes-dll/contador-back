namespace domain.Entities;

public class Counter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CreatedBy { get; set; }
    
    public ICollection<Reason> Reasons { get; set; } = new List<Reason>();

}