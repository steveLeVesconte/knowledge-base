using System;
using System.Linq;
using FluentAssertions;
using MvcMusicStore.Models;
using MvcMusicStore.Tests.TestInfrastructure.Fakes;
using MvcMusicStore.Tests.TestInfrastructure.Fixtures;

using Xunit;

namespace MvcMusicStore.Tests.Integration.Business
{
    [Collection("Database")]
    public class ShoppingCartIntegrationTests : DatabaseIntegrationTestBase, IDisposable
    {
        private readonly MusicStoreEntities _dbContext;
        private readonly string _testCartId;

        public ShoppingCartIntegrationTests(DatabaseFixture fixture) : base(fixture)
        {
            _dbContext = Fixture.CreateDbContext();
            _testCartId = Guid.NewGuid().ToString();
        }

        [Fact]
        public void GetCart_WithValidHttpContext_ReturnsShoppingCartInstance()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);

            // Act
            var cart = ShoppingCart.GetCart(httpContext);

            // Assert
            cart.Should().NotBeNull();
        }

        [Fact]
        public void AddToCart_NewAlbum_CreatesNewCartItem()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);
            var albumId = _dbContext.Albums.First().AlbumId;

            // Act
            cart.AddToCart(_dbContext.Albums.First(a => a.AlbumId == albumId));

            // Assert - Use fresh context to verify persisted state
            var cartItem = WithFreshContext(db => 
                db.Carts.SingleOrDefault(c => c.CartId == _testCartId && c.AlbumId == albumId));
            
            cartItem.Should().NotBeNull();
            cartItem.Count.Should().Be(1);
            cartItem.AlbumId.Should().Be(albumId);
            cartItem.DateCreated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(5));
        }

        [Fact]
        public void AddToCart_ExistingAlbum_IncrementsCount()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);
            var album = _dbContext.Albums.First();
            
            cart.AddToCart(album);

            // Act
            cart.AddToCart(album);

            // Assert
            var cartItem = WithFreshContext(db => 
                db.Carts.Single(c => c.CartId == _testCartId && c.AlbumId == album.AlbumId));
            
            cartItem.Count.Should().Be(2);
        }

        [Fact]
        public void RemoveFromCart_ItemWithCountGreaterThanOne_DecrementsCount()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);
            var album = _dbContext.Albums.First();
            
            cart.AddToCart(album);
            cart.AddToCart(album);
            
            var recordId = WithFreshContext(db => 
                db.Carts.Single(c => c.CartId == _testCartId).RecordId);

            // Act
            var itemCount = cart.RemoveFromCart(recordId);

            // Assert
            itemCount.Should().Be(1);
            
            WithFreshContext(db =>
            {
                var cartItem = db.Carts.Single(c => c.RecordId == recordId);
                cartItem.Count.Should().Be(1);
            });
        }

        [Fact]
        public void RemoveFromCart_ItemWithCountOne_RemovesItemFromCart()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);
            var album = _dbContext.Albums.First();
            
            cart.AddToCart(album);
            
            var recordId = WithFreshContext(db => 
                db.Carts.Single(c => c.CartId == _testCartId).RecordId);

            // Act
            var itemCount = cart.RemoveFromCart(recordId);

            // Assert
            itemCount.Should().Be(0);
            
            var cartItem = WithFreshContext(db => 
                db.Carts.SingleOrDefault(c => c.RecordId == recordId));
            
            cartItem.Should().BeNull();
        }

        [Fact]
        public void EmptyCart_WithMultipleItems_RemovesAllItemsFromCart()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);
            var albums = _dbContext.Albums.Take(3).ToList();
            
            foreach (var album in albums)
            {
                cart.AddToCart(album);
            }

            // Act
            cart.EmptyCart();

            // Assert
            var remainingItems = WithFreshContext(db => 
                db.Carts.Where(c => c.CartId == _testCartId).ToList());
            
            remainingItems.Should().BeEmpty();
        }

        [Fact]
        public void GetCartItems_WithMultipleItems_ReturnsAllCartItems()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);
            var albums = _dbContext.Albums.Take(3).ToList();
            
            foreach (var album in albums)
            {
                cart.AddToCart(album);
            }

            // Act
            var cartItems = cart.GetCartItems();

            // Assert
            cartItems.Should().HaveCount(3);
            cartItems.Should().OnlyContain(item => item.CartId == _testCartId);
        }

        [Fact]
        public void GetCount_WithMultipleItemsAndQuantities_ReturnsTotalItemCount()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);
            var albums = _dbContext.Albums.Take(2).ToList();
            
            cart.AddToCart(albums[0]);
            cart.AddToCart(albums[0]);
            cart.AddToCart(albums[1]);
            cart.AddToCart(albums[1]);
            cart.AddToCart(albums[1]);

            // Act
            var count = cart.GetCount();

            // Assert
            count.Should().Be(5);
        }

        [Fact]
        public void GetCount_WithEmptyCart_ReturnsZero()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);

            // Act
            var count = cart.GetCount();

            // Assert
            count.Should().Be(0);
        }

        [Fact]
        public void GetTotal_WithMultipleItems_ReturnsCorrectTotal()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);
            var albums = _dbContext.Albums.Take(2).ToList();
            
            cart.AddToCart(albums[0]);
            cart.AddToCart(albums[0]);
            cart.AddToCart(albums[1]);

            var expectedTotal = (albums[0].Price * 2) + albums[1].Price;

            // Act
            var total = cart.GetTotal();

            // Assert
            total.Should().Be(expectedTotal);
        }

        [Fact]
        public void GetTotal_WithEmptyCart_ReturnsZero()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);

            // Act
            var total = cart.GetTotal();

            // Assert
            total.Should().Be(0);
        }

        [Fact]
        public void MigrateCart_WithAnonymousCart_AssociatesCartWithUsername()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);
            var album = _dbContext.Albums.First();
            var newUsername = "test.user@example.com";
            
            cart.AddToCart(album);

            // Act
            cart.MigrateCart(newUsername);

            // Assert
            var migratedItems = WithFreshContext(db => 
                db.Carts.Where(c => c.CartId == newUsername).ToList());
            
            migratedItems.Should().HaveCount(1);
            migratedItems.First().AlbumId.Should().Be(album.AlbumId);
            
            var oldCartItems = WithFreshContext(db => 
                db.Carts.Where(c => c.CartId == _testCartId).ToList());
            
            oldCartItems.Should().BeEmpty();
        }

        public void Dispose()
        {
            // Clean up test data
            var testCartItems = _dbContext.Carts.Where(c => c.CartId == _testCartId).ToList();
            _dbContext.Carts.RemoveRange(testCartItems);
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }
    }
}