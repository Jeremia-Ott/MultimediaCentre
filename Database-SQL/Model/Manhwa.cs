namespace Database_SQL.Model.SQL;

public class Manhwa : Media
{
    public Manhwa()
    {
        Type = MediaType.Manhwa;
    }

    public int? MediaId { get; set; }
    public short? ChapterCount { get; set; }
    public short? ChapterWatched { get; set; }
    public Weekday ReleaseWeekday { get; set; }
}
