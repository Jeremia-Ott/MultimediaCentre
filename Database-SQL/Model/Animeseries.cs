namespace Database_SQL.Model.SQL;

public class Animeseries : Media
{
    public Animeseries()
    {
        Type = MediaType.Animeseries;
    }

    public int? MediaId { get; set; }
    public short? EpisodeCount { get; set; }
    public short? EpisodeWatched { get; set; }
    public List<AnimeSeason> AnimeSeasons { get; } = [];
    public Weekday ReleaseWeekday { get; set; }
    public short? DubDelay { get; set; }
    public List<DiskRelease> DiskReleases { get; } = [];
}
