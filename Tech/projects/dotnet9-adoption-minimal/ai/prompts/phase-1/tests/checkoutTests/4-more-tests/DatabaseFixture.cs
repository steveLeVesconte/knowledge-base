// TestInfrastructure/Fixtures/DatabaseFixture.cs
using System;
using System.Data.Entity;
using MvcMusicStore.Models;

namespace MvcMusicStore.Tests.TestInfrastructure.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        public MusicStoreEntities DbContext { get; private set; }

        public DatabaseFixture()
        {
            // Use unique database name to avoid conflicts between test runs
            Database.SetInitializer(new DatabaseInitializer());
            DbContext = new MusicStoreEntities();
            DbContext.Database.Initialize(force: true);
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }

        private class DatabaseInitializer : DropCreateDatabaseAlways<MusicStoreEntities>
        {
            protected override void Seed(MusicStoreEntities context)
            {
                // Minimal seed data for integration tests
                var rockGenre = new Genre { GenreId = 1, Name = "Rock" };
                var jazzGenre = new Genre { GenreId = 2, Name = "Jazz" };
                context.Genres.Add(rockGenre);
                context.Genres.Add(jazzGenre);

                var acdc = new Artist { ArtistId = 1, Name = "AC/DC" };
                var milesdavis = new Artist { ArtistId = 2, Name = "Miles Davis" };
                context.Artists.Add(acdc);
                context.Artists.Add(milesdavis);

                context.Albums.Add(new Album
                {
                    AlbumId = 1,
                    Title = "For Those About To Rock",
                    GenreId = 1,
                    ArtistId = 1,
                    Price = 8.99M,
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                });

                context.Albums.Add(new Album
                {
                    AlbumId = 2,
                    Title = "Let There Be Rock",
                    GenreId = 1,
                    ArtistId = 1,
                    Price = 9.99M,
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                });

                context.Albums.Add(new Album
                {
                    AlbumId = 3,
                    Title = "Kind of Blue",
                    GenreId = 2,
                    ArtistId = 2,
                    Price = 10.99M,
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                });

                context.SaveChanges();
            }
        }
    }
}