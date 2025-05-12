// See https://aka.ms/new-console-template for more information
using Database_SQL;

var dataContext = new DataContext();
await dataContext.InitAsync();
//await new SQLDatabaseQuery().ExecuteAllQueriesAsync();
