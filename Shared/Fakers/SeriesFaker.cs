using Bogus;
using Shared.Models;

namespace Shared.Fakers;

public class SeriesFaker : MediaFaker<Series>
{
    public SeriesFaker() : base()
    {
        RuleFor(x => x.Seasons, RandomSeasons);
    }

    private List<Season> RandomSeasons(Faker f, Series series)
    {
        var seasonFaker = new SeasonFaker(series.Status)
            .UseSeed(f.Random.Int());

        return seasonFaker.Generate(f.Random.Int(1, 6));
    }
}
