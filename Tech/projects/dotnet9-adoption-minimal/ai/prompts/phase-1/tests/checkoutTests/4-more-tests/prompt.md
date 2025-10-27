# Create Integration Tests for Checkout

## Primary Focus (what TO do)

Create Integration Tests for Checkout in a way that is compatible with sharing reusable test infrastructure with other planned integration tests.


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

- After calling any method that modifies data 
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

- CheckoutIntegrationTests.cs has ~5  integration tests for Checkout that appear professional for the audience of hiring managers
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
- the purpose of the tests is to provide safety while modifying the business classes to accept constructor injection so that unit tests can be used.
- Proposed total list of test for Checkout:
- CheckoutIntegrationTests.cs:
├─ CreateOrder_WithEmptyCart_CreatesOrderWithZeroTotal (included in example)
├─ CreateOrder_WithSingleItem_CreatesOrderDetailWithCorrectData
├─ CreateOrder_WithMultipleQuantityOfSameItem_CreatesCorrectOrderDetail
├─ CreateOrder_WithMultipleDifferentItems_CreatesMultipleOrderDetails (included in example)
├─ CreateOrder_AfterCompletion_EmptiesShoppingCart
└─ CreateOrder_AssociatesOrderDetailsWithCorrectOrder (optional)


- DatabaseFixture.cs
- folders.md
- Global.asax.cs
- models.md
- MusicStoreEntities.cs
- packages.config_of_MvcMusicStore.Tests
- PROJECT-LOG-excerpt.md
- prompt.md
- SampleData.cs
- ShoppingCart.cs
- Startup.cs
- TestHttpContext.cs
- TestSessionState.cs
- TestUser.cs


SECONDARY:

- Code with professional standards expected in a regional bank
- Integration test best practices for Entity Framework 6
- DRY principle (Don't Repeat Yourself) through base class inheritance

## Output Format:

C# xUnit tests and related infrastructure code compatible with .NET Framework 4.8

## Example Test Structure:

```csharp
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
    public class CheckoutIntegrationTests : IDisposable
    {
        private readonly MusicStoreEntities _dbContext;
        private readonly string _testCartId;

        public CheckoutIntegrationTests(DatabaseFixture fixture)
        {
            _dbContext = fixture.DbContext;
            _testCartId = Guid.NewGuid().ToString();
        }

        public void Dispose()
        {
            // Clean up test cart items after each test
            var cartItems = _dbContext.Carts.Where(c => c.CartId == _testCartId).ToList();
            foreach (var item in cartItems)
            {
                _dbContext.Carts.Remove(item);
            }
            _dbContext.SaveChanges();
        }
        [Fact]
        public void CreateOrder_WithEmptyCart_CreatesOrderWithZeroTotal()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);
            var order = new Order
            {
                Username = "test@example.com",
                OrderDate = DateTime.Now,
                FirstName = "Test",
                LastName = "User",
                Address = "123 Main St",
                City = "Seattle",
                State = "WA",
                PostalCode = "98101",
                Country = "USA",
                Phone = "555-1212",
                Email = "test@example.com"
            };

            // Add order to DB (CreateOrder expects order.OrderId to exist)
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            // Act
            var orderId = cart.CreateOrder(order);

            // Assert
            orderId.Should().Be(order.OrderId);

            using (var verifyContext = new MusicStoreEntities())
            {
                var savedOrder = verifyContext.Orders.Single(o => o.OrderId == orderId);
                savedOrder.Total.Should().Be(0);

                var orderDetails = verifyContext.OrderDetails.Where(od => od.OrderId == orderId).ToList();
                orderDetails.Should().BeEmpty();
            };

            // Verify cart was emptied
            cart.GetCartItems().Should().BeEmpty();
        }

        [Fact]
        public void CreateOrder_WithMultipleDifferentItems_CreatesMultipleOrderDetails()
        {
            // Arrange
            var httpContext = new TestHttpContext(_testCartId);
            var cart = ShoppingCart.GetCart(httpContext);
            var albums = _dbContext.Albums.Take(3).ToList();

            cart.AddToCart(albums[0]);
            cart.AddToCart(albums[0]);  // qty 2
            cart.AddToCart(albums[1]);  // qty 1
            cart.AddToCart(albums[2]);
            cart.AddToCart(albums[2]);
            cart.AddToCart(albums[2]);  // qty 3

            var order = new Order {
                Username = "test@example.com",
                OrderDate = DateTime.Now,
                FirstName = "Test",
                LastName = "User",
                Address = "123 Main St",
                City = "Seattle",
                State = "WA",
                PostalCode = "98101",
                Country = "USA",
                Phone = "555-1212",
                Email = "test@example.com"
            };
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            // Act
            var orderId = cart.CreateOrder(order);

            // Assert
            using (var verifyContext = new MusicStoreEntities())
            {
                var orderDetails = verifyContext.OrderDetails
                    .Where(od => od.OrderId == orderId)
                    .OrderBy(od => od.AlbumId)
                    .ToList();

                orderDetails.Should().HaveCount(3);

                orderDetails[0].AlbumId.Should().Be(albums[0].AlbumId);
                orderDetails[0].Quantity.Should().Be(2);
                orderDetails[0].UnitPrice.Should().Be(albums[0].Price);

                orderDetails[1].AlbumId.Should().Be(albums[1].AlbumId);
                orderDetails[1].Quantity.Should().Be(1);
                orderDetails[1].UnitPrice.Should().Be(albums[1].Price);

                orderDetails[2].AlbumId.Should().Be(albums[2].AlbumId);
                orderDetails[2].Quantity.Should().Be(3);
                orderDetails[2].UnitPrice.Should().Be(albums[2].Price);

                // Note: Order.Total not tested - see KNOWN_LIMITATIONS.md
            };

            cart.GetCartItems().Should().BeEmpty();
        }
    }
}
```

## Implementation Notes:

- Create DatabaseIntegrationTestBase in TestInfrastructure/Fixtures folder
- All integration test classes should inherit from DatabaseIntegrationTestBase
- Helper methods are protected and inherited, not duplicated
- Use `Fixture` property (from base class) instead of `_fixture` field
- Document the base class with XML comments explaining the EF context isolation issue