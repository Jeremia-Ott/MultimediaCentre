using Bogus;
using Shared.Models;

namespace Shared.Fakers;

public class ConnectionFaker : Faker<Connection>
{
    private List<Connection> _allPossibleConnections = [];

    public ConnectionFaker(List<Media> medienToConnect)
    {
        var notIterateMedia = medienToConnect.ToList();
        foreach (var fromMedia in medienToConnect)
        {
            notIterateMedia.Remove(fromMedia);
            foreach (var toMedia in notIterateMedia)
            {
                _allPossibleConnections.Add(new Connection() { FromMedia = fromMedia, ToMedia = toMedia });
            }
        }

        Rules((f, connection) =>
        {
            connection = f.PickRandom(_allPossibleConnections);
            _allPossibleConnections.Remove(connection);

            if (f.Random.Bool())
            {
                (connection.ToMedia, connection.FromMedia) = (connection.FromMedia, connection.ToMedia);
            }

            connection.FromMedia.Connections.Add(connection);
            connection.ToMedia.Connections.Add(connection);
        });
    }
}
