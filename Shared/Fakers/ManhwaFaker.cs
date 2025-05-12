using Bogus;
using Bogus.Extensions;
using Shared.Models;

namespace Shared.Fakers;

public class ManhwaFaker : MediaFaker<Manhwa>
{
    public ManhwaFaker() : base()
    {
        RuleFor(x => x.ChapterCount, f => f.Random.Int(11, 25).OrNull(f));
        RuleFor(t => t.ChapterWatched, RandomChapterWatchedBasedOnChapterCount);
        RuleFor(x => x.ReleaseWeekday, f => f.PickRandom<Weekday>());
    }

    private int? RandomChapterWatchedBasedOnChapterCount(Faker f, Manhwa manhwa)
    {
        if (manhwa.ChapterCount is not null)
        {
            if (manhwa.Status is MediaStatus.NotStarted) return null;
            if (manhwa.Status is MediaStatus.Started) return f.Random.Int(1, manhwa.ChapterCount.Value - 1);
            if (manhwa.Status is MediaStatus.Finished) return manhwa.ChapterCount;
        }

        return null;
    }
}
