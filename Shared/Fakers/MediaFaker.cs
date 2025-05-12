using Bogus;
using Bogus.Extensions;
using Shared.Models;

namespace Shared.Fakers;

public class MediaFaker<T> : Faker<T> where T : Media
{
    private int _number = 0;

    public MediaFaker()
    {
        RuleFor(x => x.Name, RandomWord);
        RuleFor(x => x.Description, f => f.Random.Words(f.Random.Int(10, 50)).OrNull(f));
        RuleFor(x => x.Status, f => f.PickRandom<MediaStatus>());
        RuleFor(x => x.Rating, RandomRatingBasedOnStatus);
    }

    private string RandomWord(Faker f)
    {
        return f.Random.Word() + _number++;
    }

    private Rating RandomRatingBasedOnStatus(Faker f, Media media)
    {
        if (media.Status is MediaStatus.Finished) return f.PickRandom<Rating>();

        return Rating.None;
    }
}
