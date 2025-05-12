using Shared.Fakers;
using Shared.Models;

namespace Shared;

public class DataGenerater
{
    public static List<Media> GenerateMedien(int count)
    {
        var random = new Random(23);
        var seriesFaker = new SeriesFaker().UseSeed(random.Next());
        var movieFaker = new MovieFaker().UseSeed(random.Next());
        var manhwaFaker = new ManhwaFaker().UseSeed(random.Next());
        var animemovieFaker = new AnimemovieFaker().UseSeed(random.Next());
        var animeseriesFaker = new AnimeseriesFaker().UseSeed(random.Next());

        var countInProzent = count / 100;
        var rest = count % 100;
        var medien = new List<Media>();
        medien.AddRange(seriesFaker.Generate(countInProzent * 10));
        medien.AddRange(movieFaker.Generate(countInProzent * 10));
        medien.AddRange(manhwaFaker.Generate(countInProzent * 25));
        medien.AddRange(animemovieFaker.Generate(countInProzent * 15));
        medien.AddRange(animeseriesFaker.Generate((countInProzent * 40) + rest));

        return medien;
    }

    public static List<Connection> GenerateConnections(List<Media> medien)
    {
        var random = new Random(32);
        var connections = new List<Connection>();

        while (medien.Count > 0)
        {
            var medienCount = medien.Count;
            var amountOfConnectedMedien = random.Next(1, 16);
            if (amountOfConnectedMedien >= medienCount) amountOfConnectedMedien = medienCount - 1;

            var connectedMedien = medien.Slice(0, amountOfConnectedMedien);
            var connectionFaker = new ConnectionFaker(connectedMedien).UseSeed(random.Next());
            connections.AddRange(connectionFaker.Generate(amountOfConnectedMedien - 1));
            medien.RemoveRange(0, amountOfConnectedMedien);
        }

        return connections;
    }
}
