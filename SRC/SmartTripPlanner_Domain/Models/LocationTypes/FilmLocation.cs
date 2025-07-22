using System.ComponentModel.DataAnnotations.Schema;

public class FilmLocation : Location
{
    public int FilmId { get; set; }
    public string SceneDescription { get; set; }
    [ForeignKey("FilmId")]
    public virtual Film Film { get; set; } = new Film();
    
}