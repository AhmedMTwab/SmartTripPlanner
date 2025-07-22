using System;


public class LocationTypes
{
    public int Id { get; set; }
    public string TypeName { get; set; }
    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
