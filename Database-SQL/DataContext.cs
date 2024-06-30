using System.Data;
using Dapper;
using Npgsql;

namespace Database_SQL
{
    public class DataContext
    {
        private readonly DbSettings _dbSettings = new();

        public async Task Init()
        {
            Console.WriteLine("# Start SQL Init");
            await InitDatabase();
            await InitTables();
            Console.WriteLine("# SQL Init finished!");
        }

        private async Task InitDatabase()
        {
            Console.WriteLine("InitDatabase");
            var connectionString = $"Host={_dbSettings.Server}; Database=postgres; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
            using var connection = new NpgsqlConnection(connectionString);

            if (await DoesDatabaseExist(connection))
                await DropDatabase(connection);

            await CreateDatabase(connection);
        }

        private async Task<bool> DoesDatabaseExist(IDbConnection connection)
        {
            var sqlDbCount = $"SELECT COUNT(*) FROM pg_database WHERE datname = '{_dbSettings.Database}';";
            var dbCount = await connection.ExecuteScalarAsync<int>(sqlDbCount);
            return dbCount != 0;
        }

        private async Task CreateDatabase(IDbConnection connection)
        {
            var sql = $"CREATE DATABASE \"{_dbSettings.Database}\"";
            await connection.ExecuteAsync(sql);
            Console.WriteLine("Database created!");
        }

        private async Task DropDatabase(IDbConnection connection)
        {
            var sql = $"DROP DATABASE \"{_dbSettings.Database}\"";
            await connection.ExecuteAsync(sql);
            Console.WriteLine("Database dropped!");
        }

        private async Task InitTables()
        {
            Console.Write("InitTables..");
            await new TableInitializer().InitTables();
            Console.WriteLine(".finished!");
        }
    }
}
