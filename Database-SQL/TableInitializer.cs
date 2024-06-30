using Dapper;
using System.Data;

namespace Database_SQL;

public class TableInitializer
{
    private readonly IDbConnection connection;

    public TableInitializer()
    {
        connection = new DbSettings().CreateConnection();
    }

    public async Task InitTables()
    {
        await InitMedia();
        await InitMediaName();
        await InitConnection();
        await InitLanguage();
        await InitEmotionalRating();
        await InitMovie();
        await InitSeries();
        await InitAnimemovie();
        await InitAnimeseries();
        await InitAnimeSeason();
    }

    private async Task InitMedia()
    {
        var sql = """
            CREATE TABLE IF NOT EXISTS Media (
                Id INT GENERATED ALWAYS AS IDENTITY,
                Type INT2 NOT NULL,
                Rating INT2,
                RatingContext VARCHAR(255),
                Description VARCHAR,
                WatchStatus INT2 NOT NULL,
                PRIMARY KEY(Id)
            );
            """;
        await connection.ExecuteAsync(sql);
    }

    private async Task InitMediaName()
    {
        var sql = """
            CREATE TABLE IF NOT EXISTS MediaName (
                Id INT GENERATED ALWAYS AS IDENTITY,
                MediaId INT NOT NULL,
                Core VARCHAR(100) NOT NULL,
                Sub VARCHAR(50),
                Language INT2 NOT NULL,
                Type INT2 NOT NULL,
                PRIMARY KEY(Id),
                CONSTRAINT Fk_MediaName
                  FOREIGN KEY(MediaId) 
                    REFERENCES Media(Id)
                    ON DELETE CASCADE
            );
            """;
        await connection.ExecuteAsync(sql);
    }

    private async Task InitConnection()
    {
        var sql = """
            CREATE TABLE IF NOT EXISTS Connection (
                Id INT GENERATED ALWAYS AS IDENTITY,
                ReferenceId INT NOT NULL,
                FromMediaId INT NOT NULL,
                ToMediaId INT NOT NULL,
                Type INT2 NOT NULL,
                Description VARCHAR,
                PRIMARY KEY(Id),
                UNIQUE(ReferenceId, FromMediaId, ToMediaId),
                CONSTRAINT Fk_Connection_From
                  FOREIGN KEY(FromMediaId)
                    REFERENCES Media(Id)
                    ON DELETE CASCADE,
                CONSTRAINT Fk_Connection_To
                  FOREIGN KEY(ToMediaId)
                    REFERENCES Media(Id)
                    ON DELETE CASCADE
                );
            """;
        await connection.ExecuteAsync(sql);
    }

    private async Task InitLanguage()
    {
        var sql = """
            CREATE TABLE IF NOT EXISTS Language (
                Id INT GENERATED ALWAYS AS IDENTITY,
                MediaId INT NOT NULL,
                Language INT2 NOT NULL,
                Type INT2 NOT NULL,
                PRIMARY KEY(Id),
                UNIQUE(MediaId, Language, Type),
                CONSTRAINT Fk_Language
                  FOREIGN KEY(MediaId) 
                    REFERENCES Media(Id)
                    ON DELETE CASCADE
            );
            """;
        await connection.ExecuteAsync(sql);
    }

    private async Task InitEmotionalRating()
    {
        var sql = """
            CREATE TABLE IF NOT EXISTS EmotionalRating (
                Id INT GENERATED ALWAYS AS IDENTITY,
                MediaId INT NOT NULL,
                Value VARCHAR(20) NOT NULL,
                PRIMARY KEY(Id),
                CONSTRAINT Fk_EmotionalRating
                  FOREIGN KEY(MediaId)
                    REFERENCES Media(Id)
                    ON DELETE CASCADE
            );
            """;
        await connection.ExecuteAsync(sql);
    }

    private async Task InitManhwaManga()
    {
        var sql = """
            CREATE TABLE IF NOT EXISTS ManhwaManga (
                MediaId INT NOT NULL,
                ChapterCount INT2,
                ChapterWatched INT2,
                ReleaseWeekday INT2 NOT NULL,
                PRIMARY KEY(MediaId),
                CONSTRAINT Fk_ManhwaManga
                  FOREIGN KEY(MediaId)
                    REFERENCES Media(Id)
                    ON DELETE CASCADE
            );
            """;
        await connection.ExecuteAsync(sql);
    }

    private async Task InitMovie()
    {
        var sql = """
            CREATE TABLE IF NOT EXISTS Movie (
                MediaId INT NOT NULL,
                LenghInMin INT2,
                ReleaseDate DATE,
                PRIMARY KEY(MediaId),
                CONSTRAINT Fk_Movie
                  FOREIGN KEY(MediaId)
                    REFERENCES Media(Id)
                    ON DELETE CASCADE
            );
            """;
        await connection.ExecuteAsync(sql);
    }

    private async Task InitSeries()
    {
        var sql = """
            CREATE TABLE IF NOT EXISTS Series (
                MediaId INT NOT NULL,
                PRIMARY KEY(MediaId),
                CONSTRAINT Fk_Series
                  FOREIGN KEY(MediaId)
                    REFERENCES Media(Id)
                    ON DELETE CASCADE
            );

            CREATE TABLE IF NOT EXISTS Season (
                MediaId INT NOT NULL,
                Nr INT2 NOT NULL,
                EpisodeCount INT2,
                EpisodeWatched INT2,
                PRIMARY KEY(MediaId),
                CONSTRAINT Fk_Season
                  FOREIGN KEY(MediaId) 
                    REFERENCES Series(MediaId)
                    ON DELETE CASCADE
            );
            """;
        await connection.ExecuteAsync(sql);
    }

    private async Task InitAnimemovie()
    {
        var sql = """
            CREATE TABLE IF NOT EXISTS Animemovie (
                MediaId INT NOT NULL,
                LenghInMin INT2,
                KinoRelease DATE,
                DiskRelease DATE,
                PRIMARY KEY(MediaId),
                CONSTRAINT Fk_Animemovie
                  FOREIGN KEY(MediaId)
                    REFERENCES Media(Id)
                    ON DELETE CASCADE
            );
            """;
        await connection.ExecuteAsync(sql);
    }

    private async Task InitAnimeseries()
    {
        var sql = """
            CREATE TABLE IF NOT EXISTS Animeseries (
                MediaId INT NOT NULL,
                EpisodeCount INT2,
                EpisodeWatched INT2,
                ReleaseWeekday INT2 NOT NULL,
                DubDelay INT2,
                PRIMARY KEY(MediaId),
                CONSTRAINT Fk_Animeseries
                  FOREIGN KEY(MediaId)
                    REFERENCES Media(Id)
                    ON DELETE CASCADE
            );

            CREATE TABLE IF NOT EXISTS DiskRelease (
                Id INT GENERATED ALWAYS AS IDENTITY,
                MediaId INT NOT NULL,
                ReleaseDate DATE NOT NULL,
                PRIMARY KEY(Id),
                CONSTRAINT Fk_DiskRelease
                  FOREIGN KEY(MediaId)
                    REFERENCES Animeseries(MediaId)
                    ON DELETE CASCADE
            );
            """;
        await connection.ExecuteAsync(sql);
    }

    private async Task InitAnimeSeason()
    {
        var sql = """
            CREATE TABLE IF NOT EXISTS AnimeSeason (
                Id INT GENERATED ALWAYS AS IDENTITY,
                Year INT2 NOT NULL,
                Type INT2 NOT NULL,
                PRIMARY KEY(Id)
            );

            CREATE TABLE IF NOT EXISTS Animemovie_AnimeSeason (
                MediaId INT NOT NULL,
                AnimeSeasonId INT NOT NULL,
                PRIMARY KEY(MediaId, AnimeSeasonId),
                CONSTRAINT Fk_Animemovie_AnimeSeason_MediaId
                  FOREIGN KEY(MediaId)
                    REFERENCES Animemovie(MediaId)
                    ON DELETE CASCADE,
                CONSTRAINT Fk_Animemovie_AnimeSeason_Id
                  FOREIGN KEY(AnimeSeasonId)
                    REFERENCES AnimeSeason(Id)
                    ON DELETE CASCADE
            );
            
            CREATE TABLE IF NOT EXISTS Animeseries_AnimeSeason (
                MediaId INT NOT NULL,
                AnimeSeasonId INT NOT NULL,
                PRIMARY KEY(MediaId, AnimeSeasonId),
                CONSTRAINT Fk_Animeseries_AnimeSeason_MediaId
                  FOREIGN KEY(MediaId)
                    REFERENCES Animeseries(MediaId)
                    ON DELETE CASCADE,
                CONSTRAINT Fk_Animeseries_AnimeSeason_Id
                  FOREIGN KEY(AnimeSeasonId)
                    REFERENCES AnimeSeason(Id)
                    ON DELETE CASCADE
            );
            """;
        await connection.ExecuteAsync(sql);
    }
}
