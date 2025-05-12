namespace Shared.Models;

public class Animemovie : Media
{
    public int? LengthInMin { get; set; }
    public DateTime? DiskRelease { get; set; }
    public AnimeSeasonType AnimeSeason { get; set; }
}
