namespace Shared.Models;

public abstract class Media
{
    public required string Name { get; set; }
    public List<Connection> Connections { get; } = [];
    public Rating Rating { get; set; }
    public string? Description { get; set; }
    public MediaStatus Status { get; set; }
}

public enum MediaStatus
{
    NotStarted = 0,
    Started = 1,
    Finished = 2,
}