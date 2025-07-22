using System.ComponentModel.DataAnnotations.Schema;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime OpeningHours { get; set; }
    public DateTime ClosingHours { get; set; }
    public string? ContactInfo { get; set; }
    public string? Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? BookingUrl { get; set; }
    public int LocationTypeId { get; set; }
    [ForeignKey("LocationTypeId")]
    public virtual LocationTypes LocationType { get; set; } = new LocationTypes();
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}