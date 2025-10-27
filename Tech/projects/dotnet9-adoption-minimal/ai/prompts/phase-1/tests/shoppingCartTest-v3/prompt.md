# Create Integration Tests for Shopping Cart

## Primary Focus (what TO do)

Create Integration Tests for ShoppingCart in a way that is compatible with sharing reusable test infrastructure with other planned integration tests.

Specifications:

- Use shared infrastructure such as:
  - Collection Fixtures (For Multiple Test Classes) employing minimal seed data robust enough to serve for all planned integration tests
  - Use shared fakes:
    - TestHttpContext.cs
    - TestSessionState.cs
    - TestUser.cs
  - **Base test class with shared helper methods for fresh context pattern** (DatabaseIntegrationTestBase.cs)

## Test Assertion Pattern (CRITICAL)

**Entity Framework Context Isolation:**

- The ShoppingCart class uses its own internal MusicStoreEntities instance
- The test fixture provides a separate MusicStoreEntities instance (_dbContext)
- These are DIFFERENT contexts, causing EF change tracker caching issues
- **REQUIRED PATTERN:** All assertions that verify database state after ShoppingCart mutations MUST use a fresh DbContext via helper methods

**Base Class Pattern:** Create an abstract base class (DatabaseIntegrationTestBase) in the Fixtures folder that provides reusable helper methods:

```csharp
// Location: TestInfrastructure/Fixtures/DatabaseIntegrationTestBase.cs
namespace MvcMusicStore.Tests.TestInfrastructure.Fixtures
{
    /// <summary>
    /// Base class for integration tests that require database access.
    /// Provides helper methods for the fresh context pattern to avoid EF change tracker issues.
    /// </summary>
    public abstract class DatabaseIntegrationTestBase
    {
        protected readonly DatabaseFixture Fixture;

        protected DatabaseIntegrationTestBase(DatabaseFixture fixture)
        {
            Fixture = fixture;
        }

        /// <summary>
        /// Executes a query with a fresh DbContext and returns the result.
        /// Use this when verifying database state after mutations.
        /// </summary>
        protected T WithFreshContext<T>(Func<MusicStoreEntities, T> query)
        {
            using (var context = Fixture.CreateDbContext())
            {
                return query(context);
            }
        }

        /// <summary>
        /// Executes an action with a fresh DbContext (for assertions without return values).
        /// Use this when verifying database state after mutations.
        /// </summary>
        protected void WithFreshContext(Action<MusicStoreEntities> action)
        {
            using (var context = Fixture.CreateDbContext())
            {
                action(context);
            }
        }
    }
}
```

**Usage in Test Classes:**

```csharp
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
    
    // Tests automatically have access to WithFreshContext helper methods
}
```

**When to use fresh context helpers:**

- After calling any ShoppingCart method that modifies data (AddToCart, RemoveFromCart, EmptyCart, CreateOrder)
- When verifying database state changes (inserts, updates, deletes)
- Use the appropriate helper method overload based on whether you need a return value

**When fixture context is OK:**

- Reading setup/seed data in Arrange phase (before SUT modifications)
- Tests that only call ShoppingCart query methods (GetCartItems, GetCount, GetTotal) - these use ShoppingCart's internal context

## Boundaries (what NOT to do):

- Do not go to extremes as in DOD standards
- Do not exceed the normal good practice expected in a regional bank
- **Do not use fixture DbContext to verify state after ShoppingCart modifications**
- Do not use verbose `using (var verifyContext = new MusicStoreEntities()) { }` blocks - use helper methods from base class instead
- Do not duplicate helper methods in each test class - inherit from DatabaseIntegrationTestBase

## Success Criteria (done when):

- ~12 integration tests for ShoppingCart appear professional for the audience of hiring managers
- All integration tests pass and verify actual persisted state (not cached entities)
- Fresh DbContext pattern consistently applied via helper methods inherited from base class
- DatabaseIntegrationTestBase created and properly documented
- Helper methods reduce boilerplate and make tests more readable
- The shared infrastructure (including base class) lays a foundation for more planned integration tests
- Test classes inherit from DatabaseIntegrationTestBase, not duplicate helper code

## Test Infrastructure File Structure:

```
MvcMusicStore.Tests/
└── TestInfrastructure/
    ├── Fixtures/
    │   ├── DatabaseFixture.cs           (creates test DB, seeds data)
    │   ├── DatabaseCollection.cs        (xUnit collection definition)
    │   └── DatabaseIntegrationTestBase.cs  (base class with helper methods)
    └── Fakes/
        ├── TestHttpContext.cs
        ├── TestSessionState.cs
        └── TestUser.cs
```

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
- DRY principle (Don't Repeat Yourself) through base class inheritance

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

    // Assert - Use inherited helper method for fresh context
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
    var albumId = Fixture.GetFirstAlbumId();  // Use inherited Fixture property
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

- Create DatabaseIntegrationTestBase in TestInfrastructure/Fixtures folder
- All integration test classes should inherit from DatabaseIntegrationTestBase
- Helper methods are protected and inherited, not duplicated
- Use `Fixture` property (from base class) instead of `_fixture` field
- Document the base class with XML comments explaining the EF context isolation issue