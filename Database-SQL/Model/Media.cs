using Newtonsoft.Json;

namespace Database_SQL.Model.SQL;

public class Media
{
    public int? Id { get; set; }
    public List<MediaName> Names { get; } = [];
    public MediaType Type { get; set; }
    public List<Connection> Connections { get; } = [];
    public List<Language> Languages { get; } = [];
    public Rating Rating { get; set; }
    public List<EmotionalRating> EmotionalRatings { get; } = [];
    public string? RatingContext { get; set; }
    public string? Description { get; set; }
    public WatchStatus WatchStatus { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

public enum MediaType
{
    Animeseries = 0,
    Animemovie = 1,
    Series = 2,
    Movie = 3,
    Manhwa = 4,
}

public enum Rating
{
    None = 0,
    Z = 1,
    S = 2,
    A = 3,
    B = 4,
    C = 5,
}

public enum WatchStatus
{
    NotStarted = 0,
    Started = 1,
    Finished = 2,
}
