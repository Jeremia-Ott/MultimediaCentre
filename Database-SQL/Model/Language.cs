namespace Database_SQL.Model.SQL;

public class Language
{
    public int? Id { get; set; }
    public int? MediaId { get; set; }
    public LanguageValue Value { get; set; }
    public LanguageType Type { get; set; }
}

public enum LanguageValue
{
    None = 0,
    German = 1,
    Japanese = 2,
    English = 3,
}

public enum LanguageType
{
    None = 0,
    Sub = 1,
    Dub = 2,
}
