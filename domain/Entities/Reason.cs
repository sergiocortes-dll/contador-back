namespace domain.Entities;

public class Reason
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    
    public int CounterId { get; set; }
    public Counter Counter { get; set; }
}