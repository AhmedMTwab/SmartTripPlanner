using System;


public class Cinema : Location
{
    public int? SeatingCapacity { get; set; }
    public string? ScreenType { get; set; }
    public virtual ICollection<Film> Movies { get; set; } = new List<Film>();
    
}
