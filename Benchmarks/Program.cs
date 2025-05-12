using BenchmarkDotNet.Running;
using Benchmarks;
using Database_NoSQL;
using Database_SQL;

var summarySQL = BenchmarkRunner.Run<DatabasesBenchmark<SQLDatabaseQuery>>();
var summaryNoSQL = BenchmarkRunner.Run<DatabasesBenchmark<NoSQLDatabaseQuery>>();
var summaryHybrid = BenchmarkRunner.Run<DatabasesBenchmark<HybridDatabaseQuery>>();