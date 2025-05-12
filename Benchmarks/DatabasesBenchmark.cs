using BenchmarkDotNet.Attributes;
using Shared;

namespace Benchmarks;

public class DatabasesBenchmark<T> where T : IDatabaseQuery, new()
{
    private readonly IDatabaseQuery _query;

    public DatabasesBenchmark()
    {
        _query = new T();
    }

    [Benchmark]
    public Task CreateMedia() => _query.CreateMedia();

    [Benchmark]
    public Task ReadOneMedia() => _query.ReadOneMedia();

    [Benchmark]
    public Task ReadAllMedia() => _query.ReadAllMedia();

    [Benchmark]
    public Task UpdateMedia() => _query.UpdateMedia();

    [Benchmark]
    public Task DeleteMedia() => _query.DeleteMedia();

    [Benchmark]
    public Task CreateRelation() => _query.CreateRelation();

    [Benchmark]
    public Task ReadRelationById() => _query.ReadRelationById();

    [Benchmark]
    public Task ReadFamileTree() => _query.ReadFamileTree();

    [Benchmark]
    public Task DeleteRelation() => _query.DeleteRelation();
}
