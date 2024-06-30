
namespace Database_SQL.Model.SQL;

public class Animemovie : Media
{
    public Animemovie()
    {
        Type = MediaType.Animemovie;
    }

    public int? MediaId { get; set; }
    public short? LengthInMin { get; set; }
    public AnimeSeason? AnimeSeason { get; set; }
    public DateTime? CinemaRelease { get; set; }
    public DateTime? DiskRelease { get; set; }
}
