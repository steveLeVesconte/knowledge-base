# Create Integration Tests for Shopping Cart

## Primary Focus (what TO do)
Create Integration Tests for ShoppingCart in a way that is compatible with sharing reusable test infrastructure with other planned integration tests.

Specifications:
- Use shared infrastructure such as:
  -- Collection Fixtures (For Multiple Test Classes) employing minimal seed data robust enough to serve for all planned integration tests.
  -- Use shared fakes: (more if needed)
     -- TestHttpContext.cs
     -- TestSessionState.cs
     -- TestUser.cs

## Test Assertion Pattern (CRITICAL)
**Entity Framework Context Isolation:**
- The ShoppingCart class uses its own internal MusicStoreEntities instance
- The test fixture provides a separate MusicStoreEntities instance (_dbContext)
- These are DIFFERENT contexts, causing EF change tracker caching issues
- **REQUIRED PATTERN:** All assertions that verify database state after ShoppingCart mutations MUST use a fresh DbContext:
```csharp
// CORRECT - verifies actual persisted state
using (var verifyContext = new MusicStoreEntities())
{
    var item = verifyContext.Carts.Single(c => c.RecordId == recordId);
    item.Count.Should().Be(expectedCount);
}

// INCORRECT - reads stale cached data
var item = _dbContext.Carts.Single(c => c.RecordId == recordId);
item.Count.Should().Be(expectedCount);
```

**When to use fresh context:**
- After calling any ShoppingCart method that modifies data (AddToCart, RemoveFromCart, EmptyCart, CreateOrder)
- When verifying database state changes (inserts, updates, deletes)

**When fixture context is OK:**
- Reading setup/seed data in Arrange phase (before SUT modifications)
- Tests that only call ShoppingCart query methods (GetCartItems, GetCount, GetTotal) - these use ShoppingCart's internal context

## Boundaries (what NOT to do):
- Do not go to extremes as in DOD standards.  
- Do not exceed the normal good practice expected in a regional bank
- **Do not use fixture DbContext to verify state after ShoppingCart modifications**

## Success Criteria (done when):
- ~12 integration tests for ShoppingCart appear professional for the audience of hiring managers
- All integration tests pass and verify actual persisted state (not cached entities)
- Fresh DbContext pattern consistently applied where ShoppingCart modifies data
- The shared infrastructure lays a foundation for more planned integration tests

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

    // Assert - MUST use fresh context after mutation
    using (var verifyContext = new MusicStoreEntities())
    {
        var cartItem = verifyContext.Carts.SingleOrDefault(c => 
            c.CartId == _testCartId && c.AlbumId == albumId);
        
        cartItem.Should().NotBeNull();
        cartItem.Count.Should().Be(1);
    }
}
```

Now: Generate code for the ShoppingCart integration tests and shared testing infrastructure.