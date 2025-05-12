using Bogus;
using Bogus.Extensions;
using Shared.Models;

namespace Shared.Fakers;

public class AnimeseriesFaker : MediaFaker<Animeseries>
{
    public AnimeseriesFaker() : base()
    {
        RuleFor(x => x.EpisodeCount, f => f.Random.Int(11, 25).OrNull(f));
        RuleFor(t => t.EpisodeWatched, RandomEpisodeWatchedBasedOnEpisodeCount);
        RuleFor(x => x.AnimeSeason, f => f.PickRandom<AnimeSeasonType>());
    }

    private int? RandomEpisodeWatchedBasedOnEpisodeCount(Faker f, Animeseries animeseries)
    {
        if (animeseries.EpisodeCount is not null)
        {
            if (animeseries.Status is MediaStatus.NotStarted) return null;
            if (animeseries.Status is MediaStatus.Started) return f.Random.Int(1, animeseries.EpisodeCount.Value - 1);
            if (animeseries.Status is MediaStatus.Finished) return animeseries.EpisodeCount;
        }

        return null;
    }
}
