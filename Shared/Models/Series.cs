namespace Shared.Models;

public class Series : Media
{
    public List<Season> Seasons { get; } = [];
}
