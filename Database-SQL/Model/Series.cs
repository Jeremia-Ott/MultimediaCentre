namespace Database_SQL.Model.SQL;

public class Series : Media
{
    public Series()
    {
        Type = MediaType.Series;
    }

    public int? MediaId { get; set; }
    public List<Season> Seasons { get; } = [];
}
