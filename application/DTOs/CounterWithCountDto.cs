namespace application.DTOs;

public class CounterWithCountDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CreatedBy { get; set; }
    public int Count { get; set; }
}