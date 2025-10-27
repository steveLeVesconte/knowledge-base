# Create Integration Tests for Shopping Cart

## Primary Focus (what TO do)

Create Integration Tests for ShoppingCart in a way that is compatible with sharing reusable test infrastructure with other planned integration tests.

Specifications:

- Use shared infrastructure such as: -- Collection Fixtures (For Multiple Test Classes) employing minimal seed data robust enough to serve for all planned integration tests. -- Use shared fakes: (more if needed) -- TestHttpContext.cs -- TestSessionState.cs -- TestUser.cs -- Use shared helper methods for fresh context pattern

## Test Assertion Pattern (CRITICAL)

**Entity Framework Context Isolation:**

- The ShoppingCart class uses its own internal MusicStoreEntities instance
- The test fixture provides a separate MusicStoreEntities instance (_dbContext)
- These are DIFFERENT contexts, causing EF change tracker caching issues
- **REQUIRED PATTERN:** All assertions that verify database state after ShoppingCart mutations MUST use a fresh DbContext via helper methods

**Helper Method Pattern:** Create reusable helper methods in a base class or test infrastructure to enforce the fresh context pattern:

```csharp
// Helper method for queries that return a single result
protected T WithFreshContext<T>(Func<MusicStoreEntities, T> query)
{
    using (var context = _fixture.CreateDbContext())
    {
        return query(context);
    }
}

// Helper method for queries that don't return a value (assertions only)
protected void WithFreshContext(Action<MusicStoreEntities> action)
{
    using (var context = _fixture.CreateDbContext())
    {
        action(context);
    }
}

// Usage examples:
var cartItem = WithFreshContext(db => 
    db.Carts.SingleOrDefault(c => c.CartId == _testCartId && c.AlbumId == albumId));

WithFreshContext(db =>
{
    var item = db.Carts.Single(c => c.RecordId == recordId);
    item.Count.Should().Be(expectedCount);
});
```

**When to use fresh context helpers:**

- After calling any ShoppingCart method that modifies data (AddToCart, RemoveFromCart, EmptyCart, CreateOrder)
- When verifying database state changes (inserts, updates, deletes)
- Use the appropriate helper method overload based on whether you need a return value

**When fixture context is OK:**

- Reading setup/seed data in Arrange phase (before SUT modifications)
- Tests that only call ShoppingCart query methods (GetCartItems, GetCount, GetTotal) - these use ShoppingCart's internal context

## Boundaries (what NOT to do):

- Do not go to extremes as in DOD standards.
- Do not exceed the normal good practice expected in a regional bank
- **Do not use fixture DbContext to verify state after ShoppingCart modifications**
- Do not use verbose `using (var verifyContext = new MusicStoreEntities()) { }` blocks - use helper methods instead

## Success Criteria (done when):

- ~12 integration tests for ShoppingCart appear professional for the audience of hiring managers
- All integration tests pass and verify actual persisted state (not cached entities)
- Fresh DbContext pattern consistently applied via helper methods where ShoppingCart modifies data
- Helper methods reduce boilerplate and make tests more readable
- The shared infrastructure (including helpers) lays a foundation for more planned integration tests

## Context Priority:

PRIMARY:

- app.config_of_MvcMusicStore.Tests
- folders.md
- Global.asax.cs
- models.md
- MusicStoreEntities.cs
- packages.config_of_MvcMusicStore
- packages.config_of_MvcMusicStore.Tests
- PROJECT-LOG-excerpt.md
- ShoppingCartController.cs
- Startup.cs
- Web.config_of_MvcMusicStore

SECONDARY:

- Code with professional standards expected in a regional bank
- Integration test best practices for Entity Framework 6
- DRY principle (Don't Repeat Yourself) through helper methods

## Output Format:

C# xUnit tests and related infrastructure code compatible with .NET Framework 4.8

## Example Test Structure:

```csharp
[Fact]
public void AddToCart_NewAlbum_CreatesNewCartItem()
{
    // Arrange
    var httpContext = new TestHttpContext(_testCartId);
    var cart = ShoppingCart.GetCart(httpContext);
    var albumId = _dbContext.Albums.First().AlbumId;  // OK - just reading seed data

    // Act
    cart.AddToCart(_dbContext.Albums.First(a => a.AlbumId == albumId));

    // Assert - Use helper method for fresh context
    var cartItem = WithFreshContext(db => 
        db.Carts.SingleOrDefault(c => c.CartId == _testCartId && c.AlbumId == albumId));
    
    cartItem.Should().NotBeNull();
    cartItem.Count.Should().Be(1);
}

[Fact]
public void RemoveFromCart_ItemWithCountGreaterThanOne_DecrementsCount()
{
    // Arrange
    var httpContext = new TestHttpContext(_testCartId);
    var cart = ShoppingCart.GetCart(httpContext);
    var albumId = _fixture.GetFirstAlbumId();
    var album = _dbContext.Albums.Single(a => a.AlbumId == albumId);
    
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
```

## Implementation Notes:

- Place helper methods in a base test class or directly in the test class
- Consider whether helper methods should be in DatabaseFixture, a base test class, or each test class (choose based on reusability needs)
- Helper methods should accept the fixture's `CreateDbContext()` method to maintain consistency
- Use generic type parameters to support various return types while maintaining type safety

Now: Generate code for the ShoppingCart integration tests and shared testing infrastructure using the helper method pattern for fresh context operations.