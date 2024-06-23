using System.Data;
using Dapper;
using Npgsql;

namespace Database_SQL
{
    public class DataContext
    {
        private readonly DbSettings _dbSettings = new();

        public IDbConnection CreateConnection()
        {
            var connectionString = $"Host={_dbSettings.Server}; Database={_dbSettings.Database}; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
            return new NpgsqlConnection(connectionString);
        }

        public async Task Init()
        {
            await InitDatabase();
            await InitTables();
        }

        private async Task InitDatabase()
        {
            Console.WriteLine("InitDatabase");
            var connectionString = $"Host={_dbSettings.Server}; Database=postgres; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
            using var connection = new NpgsqlConnection(connectionString);

            if (await DoesDatabaseExist(connection)) return;
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
        }

        private async Task InitTables()
        {
            using var connection = CreateConnection();
            await new TableInitializer(connection).InitTables();
        }
    }
}
