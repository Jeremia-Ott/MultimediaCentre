// See https://aka.ms/new-console-template for more information
using Database_SQL;

Console.WriteLine("Hello, World!");
var dataContext = new DataContext();
await dataContext.Init();
