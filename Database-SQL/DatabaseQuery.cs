using Newtonsoft.Json;

namespace Database_SQL;

public class DatabaseQuery
{
    private readonly DbRepository dbRepository;

    public DatabaseQuery()
    {
        dbRepository = new DbRepository();
    }

    public async Task ExecuteAllQueriesAsync()
    {
        await GetAllMedia();
        await GetMediaWithDetailsById();
    }

    private async Task GetAllMedia()
    {
        var medias = await dbRepository.SelectAllMediaAsync(0, 5);

        Console.WriteLine("## GetAllMedia()");
        foreach (var media in medias)
        {
            Console.WriteLine(media);
        }
    }

    private async Task GetMediaWithDetailsById()
    {
        //var media = await dbRepository.GetMediaWithDetailsByIdAsync(1);
    }

    private async Task GetMediaByEmotionalRating()
    {

    }

    private async Task GetMediaFilteredByName()
    {

    }

    private async Task GetMediaWithFilter()  // Filters: Rating, Name(like), AnimeSeason, Language, MediaType
    {

    }

    private async Task GetMediaFilteredByStatus()    // Watched Status
    {

    }

    private async Task GetAllConnectedMediaByMediaId()
    {

    }

    private async Task AddMedia()
    {

    }

    private async Task UpdateMedia()
    {

    }

    private async Task UpdateMediaWatchStatus()
    {

    }
}
