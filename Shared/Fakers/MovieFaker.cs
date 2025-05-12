using Bogus.Extensions;
using Shared.Models;

namespace Shared.Fakers;

public class MovieFaker : MediaFaker<Movie>
{
    public MovieFaker() : base()
    {
        RuleFor(x => x.LengthInMin, f => f.Random.Int(60, 180).OrNull(f));
        RuleFor(t => t.ReleaseDate, f => f.Date.Between(new DateTime(1990, 1, 1), new DateTime(2024, 12, 31)).OrNull(f));
    }
}
