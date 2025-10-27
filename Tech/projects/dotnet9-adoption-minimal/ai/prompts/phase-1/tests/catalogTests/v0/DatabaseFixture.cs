using System;
using System.Data.Entity;
using System.Linq;
using MvcMusicStore.Models;

namespace MvcMusicStore.Tests.TestInfrastructure.Fixtures
{
    /// <summary>
    /// xUnit collection fixture that provides a shared test database for all integration tests.
    /// Creates and seeds the database once per test run, then provides fresh DbContext instances
    /// to each test to avoid change tracker conflicts.
    /// </summary>
    public class DatabaseFixture : IDisposable
    {
        private readonly string _connectionString;
        private readonly object _lock = new object();
        private bool _databaseInitialized;

        public DatabaseFixture()
        {
            // Use a unique test database name to avoid conflicts
            var testDbName = $"MvcMusicStoreTests_{Guid.NewGuid():N}";
            _connectionString = $"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog={testDbName};Integrated Security=SSPI;";
            
            InitializeDatabase();
        }

        /// <summary>
        /// Creates a fresh DbContext instance for use in tests.
        /// Each test should create its own context to avoid EF change tracker issues.
        /// </summary>
        public MusicStoreEntities CreateDbContext()
        {
            return new MusicStoreEntities();
        }

        /// <summary>
        /// Gets the ID of the first album in the seeded test data.
        /// Useful for tests that need a valid album ID without caring which specific album.
        /// </summary>
        public int GetFirstAlbumId()
        {
            using (var context = CreateDbContext())
            {
                return context.Albums.First().AlbumId;
            }
        }

        private void InitializeDatabase()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateDbContext())
                    {
                        // Force database creation and seeding
                        Database.SetInitializer(new DropCreateDatabaseAlways<MusicStoreEntities>());
                        context.Database.Initialize(force: true);
                        
                        // Seed with minimal test data
                        SeedTestData(context);
                        
                        _databaseInitialized = true;
                    }
                }
            }
        }

        private void SeedTestData(MusicStoreEntities context)
        {
            // Create minimal but sufficient test data for shopping cart tests
            var genres = new[]
            {
                new Genre { Name = "Rock", Description = "Rock Music" },
                new Genre { Name = "Jazz", Description = "Jazz Music" },
                new Genre { Name = "Classical", Description = "Classical Music" }
            };

            foreach (var genre in genres)
            {
                context.Genres.Add(genre);
            }
            context.SaveChanges();

            var artists = new[]
            {
                new Artist { Name = "Test Artist 1" },
                new Artist { Name = "Test Artist 2" },
                new Artist { Name = "Test Artist 3" }
            };

            foreach (var artist in artists)
            {
                context.Artists.Add(artist);
            }
            context.SaveChanges();

            var albums = new[]
            {
                new Album 
                { 
                    Title = "Test Album 1", 
                    Genre = genres[0], 
                    Artist = artists[0], 
                    Price = 8.99M,
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album 
                { 
                    Title = "Test Album 2", 
                    Genre = genres[1], 
                    Artist = artists[1], 
                    Price = 9.99M,
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album 
                { 
                    Title = "Test Album 3", 
                    Genre = genres[2], 
                    Artist = artists[2], 
                    Price = 10.99M,
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album 
                { 
                    Title = "Test Album 4", 
                    Genre = genres[0], 
                    Artist = artists[0], 
                    Price = 7.99M,
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album 
                { 
                    Title = "Test Album 5", 
                    Genre = genres[1], 
                    Artist = artists[1], 
                    Price = 11.99M,
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                }
            };

            foreach (var album in albums)
            {
                context.Albums.Add(album);
            }
            context.SaveChanges();
        }

        public void Dispose()
        {
            // Clean up: Drop the test database
            using (var context = CreateDbContext())
            {
                context.Database.Delete();
            }
        }
    }
}