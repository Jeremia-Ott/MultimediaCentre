namespace Database_SQL.Model.SQL;

public class Connection
{
    public int? Id { get; set; }
    public int? ReferenceId { get; set; }
    public int? FromMediaId { get; set; }
    public int? ToMediaId { get; set; }
    public ConnectionType Type { get; set; }
    public string? Description { get; set; }
}

public enum ConnectionType
{
    None = 0,
    SpinOff = 1,
    Sequel = 2,
    Adaption = 3,
}
