namespace Database_SQL.Model.SQL;

public class Movie : Media
{
    public Movie()
    {
        Type = MediaType.Movie;
    }

    public int? MediaId { get; set; }
    public short? LengthInMin { get; set; }
    public DateTime? ReleaseDate { get; set; }
}
