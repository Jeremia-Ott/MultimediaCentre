using Shared;

namespace Database_SQL;

public class SQLDatabaseQuery : IDatabaseQuery
{
    private readonly DbRepository dbRepository;

    public SQLDatabaseQuery()
    {
        dbRepository = new DbRepository();
    }

    public Task CreateMedia()
    {
        throw new NotImplementedException();
    }

    public Task ReadOneMedia()
    {
        throw new NotImplementedException();
    }

    public Task ReadAllMedia()
    {
        throw new NotImplementedException();
    }

    Task IDatabaseQuery.UpdateMedia()
    {
        throw new NotImplementedException();
    }

    public Task DeleteMedia()
    {
        throw new NotImplementedException();
    }

    public Task CreateRelation()
    {
        throw new NotImplementedException();
    }

    public Task ReadRelationById()
    {
        throw new NotImplementedException();
    }

    public Task ReadFamileTree()
    {
        throw new NotImplementedException();
    }

    public Task DeleteRelation()
    {
        throw new NotImplementedException();
    }

    //public async Task ExecuteAllQueriesAsync()
    //{
    //    await GetAllMedia();
    //    await GetMediaWithDetailsById();
    //}

    //private async Task GetAllMedia()
    //{
    //    var medias = await dbRepository.SelectAllMediaAsync(0, 5);

    //    Console.WriteLine("## GetAllMedia()");
    //    foreach (var media in medias)
    //    {
    //        Console.WriteLine(media);
    //    }
    //}

    //private async Task GetMediaWithDetailsById()
    //{
    //    //var media = await dbRepository.GetMediaWithDetailsByIdAsync(1);
    //}

    //private async Task GetMediaByEmotionalRating()
    //{

    //}

    //private async Task GetMediaFilteredByName()
    //{

    //}

    //private async Task GetMediaWithFilter()  // Filters: Rating, Name(like), AnimeSeason, Language, MediaType
    //{

    //}

    //private async Task GetMediaFilteredByStatus()    // Watched Status
    //{

    //}

    //private async Task GetAllConnectedMediaByMediaId()
    //{

    //}

    //private async Task AddMedia()
    //{

    //}

    //private async Task UpdateMedia()
    //{

    //}

    //private async Task UpdateMediaWatchStatus()
    //{

    //}
}
