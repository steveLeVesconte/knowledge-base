using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using MvcMusicStore.Controllers;
using MvcMusicStore.Models;
using MvcMusicStore.Tests.TestInfrastructure.Fixtures;
using Xunit;

namespace MvcMusicStore.Tests.Integration.Business
{
    /// <summary>
    /// Integration tests for catalog browsing functionality in StoreController and HomeController.
    /// Tests verify that controllers correctly interact with the database to retrieve and display
    /// albums, genres, and catalog data.
    /// </summary>
    [Collection("Database")]
    public class CatalogIntegrationTests : DatabaseIntegrationTestBase
    {
        public CatalogIntegrationTests(DatabaseFixture fixture) : base(fixture)
        {
        }

        #region StoreController.Index Tests

        [Fact]
        public void StoreIndex_ReturnsAllGenres()
        {
            // Arrange
            var controller = new StoreController();

            // Act
            var result = controller.Index() as ViewResult;
            var genres = result.Model as List<Genre>;

            // Assert
            result.Should().NotBeNull();
            genres.Should().NotBeNull();
            genres.Should().HaveCount(3, "the test database seeds 3 genres");
            genres.Select(g => g.Name).Should().Contain(new[] { "Rock", "Jazz", "Classical" });
        }

        [Fact]
        public void StoreIndex_ReturnsViewResult()
        {
            // Arrange
            var controller = new StoreController();

            // Act
            var result = controller.Index();

            // Assert
            result.Should().BeOfType<ViewResult>();
        }

        #endregion

        #region StoreController.Browse Tests

        [Fact]
        public void StoreBrowse_WithValidGenre_ReturnsGenreWithAlbums()
        {
            // Arrange
            var controller = new StoreController();
            var genreName = "Rock";

            // Act
            var result = controller.Browse(genreName) as ViewResult;
            var genre = result.Model as Genre;

            // Assert
            result.Should().NotBeNull();
            genre.Should().NotBeNull();
            genre.Name.Should().Be("Rock");
            genre.Albums.Should().NotBeNull();
            genre.Albums.Should().HaveCountGreaterThan(0, "Rock genre should have albums");
        }

        [Fact]
        public void StoreBrowse_WithRockGenre_ReturnsCorrectAlbums()
        {
            // Arrange
            var controller = new StoreController();

            // Act
            var result = controller.Browse("Rock") as ViewResult;
            var genre = result.Model as Genre;

            // Assert
            genre.Albums.Should().Contain(a => a.Title == "Test Album 1");
            genre.Albums.Should().Contain(a => a.Title == "Test Album 4");
            genre.Albums.Should().OnlyContain(a => a.Genre.Name == "Rock");
        }

        [Fact]
        public void StoreBrowse_WithJazzGenre_ReturnsJazzAlbumsOnly()
        {
            // Arrange
            var controller = new StoreController();

            // Act
            var result = controller.Browse("Jazz") as ViewResult;
            var genre = result.Model as Genre;

            // Assert
            genre.Name.Should().Be("Jazz");
            genre.Albums.Should().OnlyContain(a => a.Genre.Name == "Jazz");
            genre.Albums.Should().Contain(a => a.Title == "Test Album 2");
        }

        [Fact]
        public void StoreBrowse_WithClassicalGenre_ReturnsClassicalAlbumsOnly()
        {
            // Arrange
            var controller = new StoreController();

            // Act
            var result = controller.Browse("Classical") as ViewResult;
            var genre = result.Model as Genre;

            // Assert
            genre.Name.Should().Be("Classical");
            genre.Albums.Should().OnlyContain(a => a.Genre.Name == "Classical");
            genre.Albums.Should().Contain(a => a.Title == "Test Album 3");
        }

        #endregion

        #region StoreController.Details Tests

        [Fact]
        public void StoreDetails_WithValidAlbumId_ReturnsAlbumDetails()
        {
            // Arrange
            var controller = new StoreController();
            var albumId = Fixture.GetFirstAlbumId();

            // Act
            var result = controller.Details(albumId) as ViewResult;
            var album = result.Model as Album;

            // Assert
            result.Should().NotBeNull();
            album.Should().NotBeNull();
            album.AlbumId.Should().Be(albumId);
            album.Title.Should().NotBeNullOrEmpty();
            album.Price.Should().BeGreaterThan(0);
        }

        [Fact]
        public void StoreDetails_ReturnsAlbumWithArtistAndGenre()
        {
            // Arrange
            var controller = new StoreController();
            var albumId = Fixture.GetFirstAlbumId();

            // Act
            var result = controller.Details(albumId) as ViewResult;
            var album = result.Model as Album;

            // Assert
            album.Artist.Should().NotBeNull();
            album.Artist.Name.Should().NotBeNullOrEmpty();
            album.Genre.Should().NotBeNull();
            album.Genre.Name.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void StoreDetails_VerifiesAlbumHasRequiredProperties()
        {
            // Arrange
            var controller = new StoreController();
            var albumId = Fixture.GetFirstAlbumId();

            // Act
            var result = controller.Details(albumId) as ViewResult;
            var album = result.Model as Album;

            // Assert
            album.Title.Should().NotBeNullOrEmpty();
            album.Price.Should().BeInRange(0.01M, 100M);
            album.AlbumArtUrl.Should().NotBeNullOrEmpty();
            album.GenreId.Should().BeGreaterThan(0);
            album.ArtistId.Should().BeGreaterThan(0);
        }

        #endregion

        #region StoreController.GenreMenu Tests

        [Fact]
        public void StoreGenreMenu_ReturnsPartialViewResult()
        {
            // Arrange
            var controller = new StoreController();

            // Act
            var result = controller.GenreMenu();

            // Assert
            result.Should().BeOfType<PartialViewResult>();
        }

        [Fact]
        public void StoreGenreMenu_ReturnsAllGenres()
        {
            // Arrange
            var controller = new StoreController();

            // Act
            var result = controller.GenreMenu() as PartialViewResult;
            var genres = result.Model as List<Genre>;

            // Assert
            genres.Should().NotBeNull();
            genres.Should().HaveCount(3);
            genres.Select(g => g.Name).Should().Contain(new[] { "Rock", "Jazz", "Classical" });
        }

        #endregion

        #region HomeController.Index Tests

        [Fact]
        public void HomeIndex_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void HomeIndex_ReturnsTopSellingAlbums()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;
            var albums = result.Model as List<Album>;

            // Assert
            albums.Should().NotBeNull();
            albums.Should().HaveCountLessOrEqualTo(5, "Index should return at most 5 albums");
        }

        [Fact]
        public void HomeIndex_ReturnsAlbumsWithCompleteData()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;
            var albums = result.Model as List<Album>;

            // Assert
            albums.Should().NotBeNull();
            if (albums.Any())
            {
                albums.Should().OnlyContain(a => a.Title != null);
                albums.Should().OnlyContain(a => a.Price > 0);
                albums.Should().OnlyContain(a => a.AlbumArtUrl != null);
            }
        }

        [Fact]
        public void HomeIndex_ExecutesSuccessfullyWithNoOrderHistory()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;
            var albums = result.Model as List<Album>;

            // Assert
            albums.Should().NotBeNull();
            // In a fresh test database with no orders, albums will be returned
            // but won't have any order details. This test verifies the query executes
            // successfully even with empty order history.
            albums.Count.Should().BeGreaterThanOrEqualTo(0);
        }





        #endregion

        #region Database State Verification Tests

        [Fact]
        public void DatabaseFixture_HasSeededGenres()
        {
            // Arrange & Act
            var genreCount = WithFreshContext(db => db.Genres.Count());

            // Assert
            genreCount.Should().Be(3, "test database should have 3 seeded genres");
        }

        [Fact]
        public void DatabaseFixture_HasSeededArtists()
        {
            // Arrange & Act
            var artistCount = WithFreshContext(db => db.Artists.Count());

            // Assert
            artistCount.Should().Be(3, "test database should have 3 seeded artists");
        }

        [Fact]
        public void DatabaseFixture_HasSeededAlbums()
        {
            // Arrange & Act
            var albumCount = WithFreshContext(db => db.Albums.Count());

            // Assert
            albumCount.Should().Be(5, "test database should have 5 seeded albums");
        }

        [Fact]
        public void DatabaseFixture_AlbumsHaveValidRelationships()
        {
            // Arrange & Act
            WithFreshContext(db =>
            {
                var albums = db.Albums.ToList();

                // Assert
                albums.Should().OnlyContain(a => a.GenreId > 0, "all albums should have a valid GenreId");
                albums.Should().OnlyContain(a => a.ArtistId > 0, "all albums should have a valid ArtistId");
                albums.Should().OnlyContain(a => a.Price > 0, "all albums should have a valid price");
            });
        }

        [Fact]
        public void DatabaseFixture_GenresHaveAlbums()
        {
            // Arrange & Act
            WithFreshContext(db =>
            {
                var genres = db.Genres.ToList();

                // Assert - each seeded genre should have at least one album
                foreach (var genre in genres)
                {
                    var albumCount = db.Albums.Count(a => a.GenreId == genre.GenreId);
                    albumCount.Should().BeGreaterThan(0, $"{genre.Name} genre should have albums");
                }
            });
        }

        #endregion
    }
}