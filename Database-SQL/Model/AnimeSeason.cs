namespace Database_SQL.Model.SQL;

public class AnimeSeason
{
    public int? Id { get; set; }
    public int? MediaId { get; set; }
    public short Year { get; set; }
    public AnimeSeasonType Type { get; set; }
}

public enum AnimeSeasonType
{
    Spring = 0,
    Summer = 1,
    Fall = 2,
    Winter = 3,
}
