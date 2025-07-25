public class Trip
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Destination { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}