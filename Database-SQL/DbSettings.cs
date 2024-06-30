using Npgsql;
using System.Data;

namespace Database_SQL;

public class DbSettings
{
    public string Server { get; } = "localhost:5432";
    public string UserId { get; } = "postgres";
    public string Password { get; } = "12345678";
    public string Database { get; } = "MultimediaCentre";

    public IDbConnection CreateConnection()
    {
        var connectionString = $"Host={Server}; Database={Database}; Username={UserId}; Password={Password};";
        return new NpgsqlConnection(connectionString);
    }
}