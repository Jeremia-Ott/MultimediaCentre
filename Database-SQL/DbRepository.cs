using Dapper;
using Database_SQL.Model.SQL;
using System.Security.Cryptography;

namespace Database_SQL;

public class DbRepository
{
    private readonly DbSettings dbSettings;

    public DbRepository()
    {
        dbSettings = new DbSettings();
    }

    #region Insert

    public async Task InsertAnimeSeasonsAsync(List<AnimeSeason> animeSeasons)
    {
        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO AnimeSeason (Year, Type) VALUES (@Year, @Type)";
        await connection.ExecuteAsync(sql, animeSeasons);
    }

    private async Task InsertMediaAsync(Media media)
    {
        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO Media (Type, Rating, RatingContext, Description, WatchStatus) " +
            "VALUES (@Type, @Rating, @RatingContext, @Description, @WatchStatus) " +
            "RETURNING Id";
        media.Id = await connection.ExecuteScalarAsync<int>(sql, media);

        foreach (var name in media.Names)
        {
            name.MediaId = media.Id;
            await InsertMediaNameAsync(name);
        }

        foreach (var language in media.Languages)
        {
            language.MediaId = media.Id;
            await InsertLanguageAsync(language);
        }

        foreach (var emotionalRating in media.EmotionalRatings)
        {
            emotionalRating.MediaId = media.Id;
            await InsertEmotionalRatingAsync(emotionalRating);
        }
    }

    private async Task InsertMediaNameAsync(MediaName name)
    {
        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO MediaName (MediaId, Core, Sub, Language, Type) " +
            "VALUES (@MediaId, @Core, @Sub, @Language, @Type)";
        await connection.ExecuteAsync(sql, name);
    }

    private async Task InsertLanguageAsync(Language language)
    {
        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO Language (MediaId, Language, Type) " +
            "VALUES (@MediaId, @Value, @Type)";
        await connection.ExecuteAsync(sql, language);
    }

    private async Task InsertEmotionalRatingAsync(EmotionalRating emotionalRating)
    {
        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO EmotionalRating (MediaId, Value) " +
            "VALUES (@MediaId, @Value)";
        await connection.ExecuteAsync(sql, emotionalRating);
    }

    public async Task InsertManhwaAsync(List<Manhwa> manhwas)
    {
        foreach (var manhwa in manhwas)
        {
            await InsertMediaAsync(manhwa);
            manhwa.MediaId = manhwa.Id;
        }

        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO ManhwaManga (MediaId, ChapterCount, ChapterWatched, ReleaseWeekday) " +
            "VALUES (@MediaId, @ChapterCount, @ChapterWatched, @ReleaseWeekday)";
        await connection.ExecuteAsync(sql, manhwas);
    }

    public async Task InsertMoviesAsync(List<Movie> movies)
    {
        foreach (var movie in movies)
        {
            await InsertMediaAsync(movie);
            movie.MediaId = movie.Id;
        }

        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO Movie (MediaId, LengthInMin, ReleaseDate) " +
            "VALUES (@MediaId, @LengthInMin, @ReleaseDate)";
        await connection.ExecuteAsync(sql, movies);
    }

    public async Task InsertSeriesAsync(List<Series> series)
    {
        foreach (var oneSeries in series)
        {
            await InsertMediaAsync(oneSeries);
            oneSeries.MediaId = oneSeries.Id;

            await InsertSeriesAsync(oneSeries);

            foreach (var season in oneSeries.Seasons)
            {
                season.MediaId = oneSeries.Id;
                await InsertSeasonAsync(season);
            }
        }
    }

    private async Task InsertSeriesAsync(Series series)
    {
        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO Series (MediaId) " +
            "VALUES (@MediaId)";
        await connection.ExecuteAsync(sql, series);
    }

    private async Task InsertSeasonAsync(Season season)
    {
        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO Season (MediaId, Nr, EpisodeCount, EpisodeWatched) " +
            "VALUES (@MediaId, @Nr, @EpisodeCount, @EpisodeWatched)";
        await connection.ExecuteAsync(sql, season);
    }

    public async Task InsertAnimemoviesAsync(List<Animemovie> animemovies)
    {
        foreach (var animemovie in animemovies)
        {
            await InsertMediaAsync(animemovie);
            animemovie.MediaId = animemovie.Id;
            if (animemovie.AnimeSeason != null)
            {
                animemovie.AnimeSeason.MediaId = animemovie.Id;
                animemovie.AnimeSeason.Id = await SelectAnimeSeasonIdAsync(animemovie.AnimeSeason);
            }

            await InsertAnimemovieAsync(animemovie);
        }
    }

    private async Task InsertAnimemovieAsync(Animemovie animemovie)
    {
        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO Animemovie (MediaId, LengthInMin, CinemaRelease, DiskRelease, " +
            "AnimeSeasonId) " +
            "VALUES (@MediaId, @LengthInMin, @CinemaRelease, @DiskRelease, @AnimeSeasonId)";
        var customAnimemovie = new
        {
            animemovie.MediaId,
            animemovie.LengthInMin,
            animemovie.CinemaRelease,
            animemovie.DiskRelease,
            AnimeSeasonId = animemovie.AnimeSeason?.Id
        };
        await connection.ExecuteAsync(sql, customAnimemovie);
    }

    private async Task<int> SelectAnimeSeasonIdAsync(AnimeSeason animeSeason)
    {
        using var connection = dbSettings.CreateConnection();
        var selectId = "SELECT Id FROM AnimeSeason " +
            "WHERE Year = @Year and Type = @Type " +
            "LIMIT 1";
        return await connection.ExecuteScalarAsync<int>(selectId, animeSeason);
    }

    public async Task InsertAnimeseriesAsync(List<Animeseries> animeseries)
    {
        foreach (var oneAnimeseries in animeseries)
        {
            await InsertMediaAsync(oneAnimeseries);
            oneAnimeseries.MediaId = oneAnimeseries.Id;

            await InsertAnimeseriesAsync(oneAnimeseries);
            foreach(var diskRelease in oneAnimeseries.DiskReleases)
            {
                diskRelease.MediaId = oneAnimeseries.Id;
                await InsertDiskReleaseAsync(diskRelease);
            }

            foreach(var animeSeason in oneAnimeseries.AnimeSeasons)
            {
                animeSeason.MediaId = oneAnimeseries.Id;
                await InsertAnimeSeasonSeriesAsync(animeSeason);
            }
        }
    }

    private async Task InsertAnimeSeasonSeriesAsync(AnimeSeason animeSeason)
    {
        using var connection = dbSettings.CreateConnection();
        var selectId = "SELECT Id FROM AnimeSeason " +
            "WHERE Year = @Year and Type = @Type " +
            "LIMIT 1";
        var animeSeasonId = await connection.ExecuteScalarAsync<int>(selectId, animeSeason);

        var insertAnimeSeason =
            "INSERT INTO Animeseries_AnimeSeason (MediaId, AnimeSeasonId) " +
            "VALUES (@MediaId, @AnimeSeasonId)";
        await connection.ExecuteAsync(
            insertAnimeSeason, new { animeSeason.MediaId, AnimeSeasonId = animeSeasonId });
    }

    private async Task InsertAnimeseriesAsync(Animeseries animeseries)
    {
        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO Animeseries (MediaId, EpisodeCount, EpisodeWatched, ReleaseWeekday, " +
            "DubDelay) " +
            "VALUES (@MediaId, @EpisodeCount, @EpisodeWatched, @ReleaseWeekday, @DubDelay)";
        await connection.ExecuteAsync(sql, animeseries);
    }

    private async Task InsertDiskReleaseAsync(DiskRelease diskRelease)
    {
        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO DiskRelease (MediaId, ChapterCount, ChapterWatched, ReleaseWeekday) " +
            "VALUES (@MediaId, @ChapterCount, @ChapterWatched, @ReleaseWeekday)";
        await connection.ExecuteAsync(sql, diskRelease);
    }

    public async Task InsertConnectionsAsync(List<Connection> connections)
    {
        using var connection = dbSettings.CreateConnection();
        var sql = "INSERT INTO Connection (ReferenceId, FromMediaId, ToMediaId, Type, Description) " +
            "VALUES (@ReferenceId, @FromMediaId, @ToMediaId, @Type, @Description)";
        await connection.ExecuteAsync(sql, connections);
    }

    #endregion

    #region Select

    public async Task<int> SelectNextReferenceIdAsync()
    {
        using var connection = dbSettings.CreateConnection();

        var next = 0;
        var count = await connection.ExecuteScalarAsync<int>("SELECT COUNT(ReferenceId) FROM Connection");
        if (count == 0) return next;

        next = await connection.ExecuteScalarAsync<int>("SELECT MAX(ReferenceId) FROM Connection");
        return ++next;
    }

    public async Task<IEnumerable<Media>> SelectAllMediaAsync(int From, int Take)
    {
        if (From < 0 || Take <= 0)
        {
            throw new ArgumentException("Invalid paging parameters");
        }

        using var connection = dbSettings.CreateConnection();
        return await connection.QueryAsync<Media>(
            "SELECT * FROM Media OFFSET @From LIMIT @Take",
            new { From, Take });
    }

    #endregion
}
