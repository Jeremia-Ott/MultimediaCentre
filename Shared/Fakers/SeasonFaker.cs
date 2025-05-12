using Bogus;
using Bogus.Extensions;
using Shared.Models;

namespace Shared.Fakers;

public class SeasonFaker : Faker<Season>
{
    private int _number = 1;
    private readonly MediaStatus _status;

    public SeasonFaker(MediaStatus status) : base()
    {
        _status = status;
        RuleFor(x => x.Nr, f => _number++);
        RuleFor(x => x.EpisodeCount, f => f.Random.Int(11, 25).OrNull(f));
        RuleFor(t => t.EpisodeWatched, RandomEpisodeWatchedBasedOnEpisodeCount);
    }

    private int? RandomEpisodeWatchedBasedOnEpisodeCount(Faker f, Season season)
    {
        if (season.EpisodeCount is not null)
        {
            if (_status is MediaStatus.NotStarted) return null;
            if (_status is MediaStatus.Started) return f.Random.Int(1, season.EpisodeCount.Value - 1);
            if (_status is MediaStatus.Finished) return season.EpisodeCount;
        }

        return null;
    }
}
