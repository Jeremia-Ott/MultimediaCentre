using Bogus.Extensions;
using Shared.Models;

namespace Shared.Fakers;

public class AnimemovieFaker : MediaFaker<Animemovie>
{
    public AnimemovieFaker() : base()
    {
        RuleFor(x => x.LengthInMin, f => f.Random.Int(60, 180).OrNull(f));
        RuleFor(t => t.DiskRelease, f => f.Date.Between(new DateTime(1990, 1, 1), new DateTime(2024, 12, 31)).OrNull(f));
        RuleFor(x => x.AnimeSeason, f => f.PickRandom<AnimeSeasonType>());
    }
}
