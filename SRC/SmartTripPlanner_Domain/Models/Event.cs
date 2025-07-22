using System.ComponentModel.DataAnnotations.Schema;

public class Event
{
    public int Id
    {
        get; set;
    }
    public int Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LocationId { get; set; }
    public string? Description { get; set; }
    public bool IsBooked { get; set; }
    public int TripId { get; set; }
    [ForeignKey("LocationId")]
    public virtual Location Location { get; set; }=new Location();
    [ForeignKey("TripId")]
    public virtual Trip? Trip { get; set; }=new Trip();
    
}