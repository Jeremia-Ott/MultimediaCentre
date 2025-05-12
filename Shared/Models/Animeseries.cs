namespace Shared.Models;

public class Animeseries : Media
{
    public int? EpisodeCount { get; set; }
    public int? EpisodeWatched { get; set; }
    public AnimeSeasonType AnimeSeason { get; set; }
}
