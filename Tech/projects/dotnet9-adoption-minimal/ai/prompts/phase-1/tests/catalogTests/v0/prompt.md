# Create Integration Tests for Checkout

## Primary Focus (what TO do)

Create Integration Tests for Catalog in a way that is compatible with sharing reusable test infrastructure with other planned integration tests.  Unfortunately, there is no "Catalog" model or business object and all the functions are in the controllers.  So, the Catalog integration tests will be "Controller Integration Tests".


Specifications:

- Use shared infrastructure such as:
  - Collection Fixtures (For Multiple Test Classes) employing minimal seed data robust enough to serve for all planned integration tests
  - Use shared fakes:
    - TestHttpContext.cs
    - TestSessionState.cs
    - TestUser.cs
  - **Base test class with shared helper methods for fresh context pattern** (DatabaseIntegrationTestBase.cs)

## Test Assertion Pattern (CRITICAL)

**Entity Framework Context Isolation (if applicable)**




**Base Class Pattern:** Use the abstract base class (DatabaseIntegrationTestBase) in the Fixtures folder that provides reusable helper methods:

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



## Boundaries (what NOT to do):

- Do not go to extremes as in DOD standards
- Do not exceed the normal good practice expected in a regional bank


## Success Criteria (done when):

- CatalogIntegrationTests.cs has the appropriate  integration tests for Catalog functions that appear professional for the audience of hiring managers
- All integration tests pass and verify actual persisted state (not cached entities)

- Helper methods reduce boilerplate and make tests more readable (if applicable)
- The shared infrastructure (including base class) lays a foundation for more planned integration tests (if applicable)
- Test classes inherit from DatabaseIntegrationTestBase, not duplicate helper code (if applicable)
- maintain compatibility with ShoppingCartIntegrationTests.cs - don't break it or suggest fix 

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
- the purpose of the tests is to provide safety while modifying the business classes to accept constructor injection so that unit tests can be used.

- StoreManagerController.cs
- HomeController.cs
- StoreController.cs
- DatabaseFixture.cs c
- DatabaseCollection.cs
- DatabaseIntegrationTestBase.cs
- Global.asax.cs
- models.md
- MusicStoreEntities.cs
- packages.config_of_MvcMusicStore.Tests 
- SampleData.cs 
- Startup.cs 
- TestHttpContext.cs 
- TestSessionState.cs 
- TestUser.cs 


SECONDARY:
- ShoppingCartIntegrationTests.cs
- CheckoutIntegrationTests.cs
- ShoppingCart.cs 
- PROJECT-LOG-excerpt.md
- Code with professional standards expected in a regional bank
- Integration test best practices for Entity Framework 6
- DRY principle (Don't Repeat Yourself) through base class inheritance

## Output Format:

C# xUnit tests and related infrastructure code compatible with .NET Framework 4.8

## Example Test Structure:

```csharp


[Collection("Database")]
public class HomeControllerIntegrationTests : DatabaseIntegrationTestBase
{
    [Fact]
    public void Index_ReturnsTopSellingAlbums()
    {
        // Arrange
        var controller = new HomeController();
        
        // Act
        var result = controller.Index() as ViewResult;
        var albums = result.Model as List<Album>;
        
        // Assert
        albums.Should().NotBeNull();
        albums.Should().HaveCountLessOrEqualTo(5);
    }
}

```

## Implementation Notes:


- All integration test classes should inherit from DatabaseIntegrationTestBase
- Helper methods are protected and inherited, not duplicated
- Use `Fixture` property (from base class) instead of `_fixture` field (if applicable)


## Folders:
MvcMusicStore.Tests/
├── Integration/
│   ├── Business/
│   │   ├── ShoppingCartIntegrationTests.cs
│   │   ├── CheckoutIntegrationTests.cs
│   │   └── CatalogIntegrationTests.cs  (controller Integration Tests)
│   ├── Controllers/
│   │   └── (if needed - usually controllers are unit tested)
│   └── Flows/
│       └── AuthenticationFlowTests.cs
├── Unit/ (reserved for future)
│   ├── Business/
│   │   ├── ShoppingCartTests.cs
│   │   ├── CheckoutTests.cs
│   │   └── CatalogTests.cs
│   └── Controllers/
│       ├── ShoppingCartControllerTests.cs
│       ├── CheckoutControllerTests.cs
│       └── StoreManagerControllerTests.cs
└── TestInfrastructure/
    ├── Fixtures/
    │   ├── DatabaseFixture.cs
    │   └── DatabaseCollection.cs
    ├── Fakes/
    │   ├── TestHttpContext.cs
    │   ├── TestSessionState.cs
    │   └── TestUser.cs
    └── Builders/  ← For Unit tests (reserved for future)
        └── (empty for now)