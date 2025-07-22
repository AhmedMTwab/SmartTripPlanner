using System;


public class Film
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<FilmLocation> FilmLocations { get; set; } = new List<FilmLocation>();
    public virtual ICollection<Cinema> Cinemas { get; set; } = new List<Cinema>();

}
