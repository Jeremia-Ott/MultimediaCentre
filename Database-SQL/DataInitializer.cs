using Database_SQL.Model.SQL;

namespace Database_SQL
{
    public class DataInitializer
    {
        private readonly DbRepository dbRepository;
        private readonly List<Manhwa> manhwas = [];
        private readonly List<Movie> movies = [];
        private readonly List<Series> series = [];
        private readonly List<Animemovie> animemovies = [];
        private readonly List<Animeseries> animeseries = [];

        public DataInitializer()
        {
            dbRepository = new DbRepository();
        }

        public async Task InitData()
        {
            await InitAnimeSeasons();

            await InitManhwaManga();
            await InitMovie();
            await InitSeries();
            await InitAnimemovie();
            await InitAnimeseries();

            await InitConnection();
        }

        private async Task InitAnimeSeasons()
        {
            var animeSeasons = new List<AnimeSeason>();
            for (int i = 0; i < 40; i++)
            {
                var year = Convert.ToInt16(2000 + i);
                animeSeasons.AddRange([
                    new AnimeSeason{ Year = year, Type = AnimeSeasonType.Winter },
                    new AnimeSeason{ Year = year, Type = AnimeSeasonType.Spring },
                    new AnimeSeason{ Year = year, Type = AnimeSeasonType.Summer },
                    new AnimeSeason{ Year = year, Type = AnimeSeasonType.Fall },]);

            }
            await dbRepository.InsertAnimeSeasonsAsync(animeSeasons);
        }

        private async Task InitManhwaManga()
        {
            var seed = new Manhwa
            {
                Rating = Rating.A,
                ChapterCount = 147,
                ChapterWatched = 147,
                Description = "Machine Learning :D",
                WatchStatus = WatchStatus.Finished,
            };
            seed.Names.Add(new MediaName { Core = "Seed" });
            seed.Languages.Add(new Language { Value = LanguageValue.English });
            seed.EmotionalRatings.Add(new EmotionalRating { Value = "Anspannung" });
            manhwas.Add(seed);

            var soloLeveling = new Manhwa
            {
                Rating = Rating.None,
                ChapterCount = 200,
                WatchStatus = WatchStatus.NotStarted,
            };
            soloLeveling.Names.Add(new MediaName { Core = "Solo Leveling" });
            soloLeveling.Languages.Add(new Language { Value = LanguageValue.English });
            soloLeveling.Languages.Add(new Language { Value = LanguageValue.German });
            manhwas.Add(soloLeveling);

            await dbRepository.InsertManhwaAsync(manhwas);
        }

        private async Task InitMovie()
        {
            var badmanReturns = new Movie
            {
                Rating = Rating.A,
                Description = "Ich bin Badman!",
                WatchStatus = WatchStatus.Finished,
                LengthInMin = 126,
                ReleaseDate = new DateTime(1992, 1, 1),
            };
            badmanReturns.Names.Add(new MediaName
            {
                Core = "Badman Returns",
                Language = LanguageValue.English,
                Type = NameType.Original
            });
            badmanReturns.Names.Add(new MediaName
            {
                Core = "Batmans Rückkehr",
                Language = LanguageValue.German
            });
            badmanReturns.Languages.Add(new Language
            {
                Value = LanguageValue.English,
                Type = LanguageType.Dub
            });
            badmanReturns.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Dub
            });
            badmanReturns.Languages.Add(new Language
            {
                Value = LanguageValue.English,
                Type = LanguageType.Sub
            });
            badmanReturns.EmotionalRatings.Add(new EmotionalRating { Value = "Anspannung" });
            movies.Add(badmanReturns);

            var badmanDK = new Movie
            {
                Rating = Rating.S,
                RatingContext = "Einfach ein Banger!",
                Description = "Ich bin Badman!",
                WatchStatus = WatchStatus.Finished,
                LengthInMin = 152,
                ReleaseDate = new DateTime(2008, 1, 1),
            };
            badmanDK.Names.Add(new MediaName
            {
                Core = "The Dark Knight",
                Language = LanguageValue.English,
                Type = NameType.Original
            });
            badmanDK.Names.Add(new MediaName
            {
                Core = "Batman",
                Sub = "The Dark Knight",
                Language = LanguageValue.German
            });
            badmanDK.Languages.Add(new Language
            {
                Value = LanguageValue.English,
                Type = LanguageType.Dub
            });
            badmanDK.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Dub
            });
            badmanDK.Languages.Add(new Language
            {
                Value = LanguageValue.English,
                Type = LanguageType.Sub
            });
            badmanDK.EmotionalRatings.Add(new EmotionalRating { Value = "Anspannung" });
            movies.Add(badmanDK);

            var badmanDKR = new Movie
            {
                Rating = Rating.A,
                Description = "Ich bin Badman!",
                WatchStatus = WatchStatus.Finished,
                LengthInMin = 164,
                ReleaseDate = new DateTime(2012, 1, 1),
            };
            badmanDKR.Names.Add(new MediaName
            {
                Core = "The Dark Knight Rises",
                Language = LanguageValue.English,
                Type = NameType.Original
            });
            badmanDKR.Names.Add(new MediaName
            {
                Core = "Batman",
                Sub = "The Dark Knight Rises",
                Language = LanguageValue.German
            });
            badmanDKR.Languages.Add(new Language
            {
                Value = LanguageValue.English,
                Type = LanguageType.Dub
            });
            badmanDKR.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Dub
            });
            badmanDKR.Languages.Add(new Language
            {
                Value = LanguageValue.English,
                Type = LanguageType.Sub
            });
            badmanDKR.EmotionalRatings.Add(new EmotionalRating { Value = "Anspannung" });
            movies.Add(badmanDKR);

            await dbRepository.InsertMoviesAsync(movies);
        }

        private async Task InitSeries()
        {
            var worrierNun = new Series
            {
                Rating = Rating.S,
                WatchStatus = WatchStatus.Finished,
            };
            worrierNun.Names.Add(new MediaName
            {
                Core = "Warrior Nun",
                Language = LanguageValue.English,
                Type = NameType.Original
            });
            worrierNun.Languages.Add(new Language
            {
                Value = LanguageValue.English,
                Type = LanguageType.Dub
            });
            worrierNun.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Dub
            });
            worrierNun.EmotionalRatings.Add(new EmotionalRating { Value = "Anspannung" });
            worrierNun.Seasons.Add(new Season
            {
                Nr = 1,
                EpisodeCount = 10,
                EpisodeWatched = 10,
            });
            worrierNun.Seasons.Add(new Season
            {
                Nr = 2,
                EpisodeCount = 8,
                EpisodeWatched = 8,
            });
            series.Add(worrierNun);

            var sherlock = new Series
            {
                Rating = Rating.S,
                WatchStatus = WatchStatus.Finished,
            };
            sherlock.Names.Add(new MediaName
            {
                Core = "Sherlock",
                Language = LanguageValue.English,
                Type = NameType.Original
            });
            sherlock.Languages.Add(new Language
            {
                Value = LanguageValue.English,
                Type = LanguageType.Dub
            });
            sherlock.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Dub
            });
            sherlock.EmotionalRatings.Add(new EmotionalRating { Value = "Anspannung" });
            sherlock.Seasons.Add(new Season
            {
                Nr = 1,
                EpisodeCount = 3,
                EpisodeWatched = 3,
            });
            sherlock.Seasons.Add(new Season
            {
                Nr = 2,
                EpisodeCount = 3,
                EpisodeWatched = 3,
            });
            sherlock.Seasons.Add(new Season
            {
                Nr = 3,
                EpisodeCount = 3,
                EpisodeWatched = 3,
            });
            sherlock.Seasons.Add(new Season
            {
                Nr = 4,
                EpisodeCount = 3,
                EpisodeWatched = 3,
            });
            series.Add(sherlock);

            await dbRepository.InsertSeriesAsync(series);
        }

        private async Task InitAnimemovie()
        {
            var pancreas = new Animemovie
            {
                Rating = Rating.A,
                WatchStatus = WatchStatus.Finished,
                LengthInMin = 108,
                AnimeSeason = new AnimeSeason { Type = AnimeSeasonType.Summer, Year = 2018 }
            };
            pancreas.Names.Add(new MediaName
            {
                Core = "Kimi no Suizou wo Tabetai",
                Language = LanguageValue.Japanese,
                Type = NameType.Original
            });
            pancreas.Names.Add(new MediaName
            {
                Core = "I Want to Eat Your Pancreas",
                Language = LanguageValue.German
            });
            pancreas.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Dub
            });
            pancreas.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Sub
            });
            pancreas.EmotionalRatings.Add(new EmotionalRating { Value = "Resonanze" });
            animemovies.Add(pancreas);

            var yourName = new Animemovie
            {
                Rating = Rating.S,
                RatingContext = "S wenn man andere Enden gewohnt ist!",
                WatchStatus = WatchStatus.Finished,
                LengthInMin = 108,
                AnimeSeason = new AnimeSeason { Type = AnimeSeasonType.Summer, Year = 2016 }
            };
            yourName.Names.Add(new MediaName
            {
                Core = "Kimi no Na wa.",
                Language = LanguageValue.Japanese,
                Type = NameType.Original
            });
            yourName.Names.Add(new MediaName
            {
                Core = "Your name.",
                Sub = "Gestern, heute und für immer",
                Language = LanguageValue.German
            });
            yourName.Names.Add(new MediaName
            {
                Core = "Your name.",
                Language = LanguageValue.English
            });
            yourName.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Dub
            });
            yourName.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Sub
            });
            yourName.EmotionalRatings.Add(new EmotionalRating { Value = "Traurigkeit" });
            animemovies.Add(yourName);

            await dbRepository.InsertAnimemoviesAsync(animemovies);
        }

        private async Task InitAnimeseries()
        {
            var soloLeveling = new Animeseries
            {
                Rating = Rating.A,
                EpisodeCount = 12,
                EpisodeWatched = 12,
                WatchStatus = WatchStatus.Finished,
            };
            soloLeveling.Names.Add(new MediaName
            {
                Core = "Ore dake Level Up na Ken",
                Language = LanguageValue.Japanese,
                Type = NameType.Original
            });
            soloLeveling.Names.Add(new MediaName
            {
                Core = "Solo Leveling",
                Language = LanguageValue.English,
            });
            soloLeveling.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Dub
            });
            soloLeveling.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Sub
            });
            soloLeveling.EmotionalRatings.Add(new EmotionalRating { Value = "Hype" });
            soloLeveling.AnimeSeasons.Add(new AnimeSeason
            {
                Year = 2024,
                Type = AnimeSeasonType.Winter,
            });
            animeseries.Add(soloLeveling);

            var Lustrous = new Animeseries
            {
                Rating = Rating.Z,
                RatingContext = "Einfach Peak!",
                EpisodeCount = 12,
                EpisodeWatched = 12,
                WatchStatus = WatchStatus.Finished,
            };
            Lustrous.Names.Add(new MediaName
            {
                Core = "Houseki no Kuni",
                Language = LanguageValue.Japanese,
                Type = NameType.Original,
            });
            Lustrous.Names.Add(new MediaName
            {
                Core = "Land of the Lustrous",
                Language = LanguageValue.English,
            });
            Lustrous.Names.Add(new MediaName
            {
                Core = "Das Land der Juwelen",
                Language = LanguageValue.English,
            });
            Lustrous.Names.Add(new MediaName
            {
                Core = "Das Land der Juwelen",
                Type = NameType.Synonym,
            });
            Lustrous.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Dub
            });
            Lustrous.Languages.Add(new Language
            {
                Value = LanguageValue.German,
                Type = LanguageType.Sub
            });
            Lustrous.EmotionalRatings.Add(new EmotionalRating { Value = "Destroyed" });
            Lustrous.AnimeSeasons.Add(new AnimeSeason
            {
                Year = 2017,
                Type = AnimeSeasonType.Fall,
            });
            animeseries.Add(Lustrous);

            await dbRepository.InsertAnimeseriesAsync(animeseries);
        }

        private async Task InitConnection()
        {
            var referenceId = await dbRepository.SelectNextReferenceIdAsync();

            var connections = new List<Connection>
            {
                new() {
                    ReferenceId = referenceId,
                    FromMediaId = movies[0].Id,
                    ToMediaId = movies[1].Id,
                    Type = ConnectionType.Sequel,
                },
                new() {
                    ReferenceId = referenceId,
                    FromMediaId = movies[1].Id,
                    ToMediaId = movies[2].Id,
                    Type = ConnectionType.Sequel,
                },
                new() {
                    ReferenceId = ++referenceId,
                    FromMediaId = manhwas[1].Id,
                    ToMediaId = animeseries[0].Id,
                    Type = ConnectionType.Adaption,
                },
            };

            await dbRepository.InsertConnectionsAsync(connections);
        }
    }
}