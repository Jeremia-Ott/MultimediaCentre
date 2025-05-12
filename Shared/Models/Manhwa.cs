namespace Shared.Models;

public class Manhwa : Media
{
    public int? ChapterCount { get; set; }
    public int? ChapterWatched { get; set; }
    public Weekday ReleaseWeekday { get; set; }
}
