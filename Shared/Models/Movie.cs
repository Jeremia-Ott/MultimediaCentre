namespace Shared.Models;

public class Movie : Media
{
    public int? LengthInMin { get; set; }
    public DateTime? ReleaseDate { get; set; }
}
