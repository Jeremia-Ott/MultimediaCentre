namespace Database_SQL.Model.SQL;

public class MediaName
{
    public int? Id { get; set; }
    public int? MediaId { get; set; }
    public string Core { get; set; }
    public string? Sub { get; set; }
    public LanguageValue Language { get; set; }
    public NameType Type { get; set; }
}

public enum NameType
{
    None = 0,
    Original = 1,
    Synonym = 2,
}
