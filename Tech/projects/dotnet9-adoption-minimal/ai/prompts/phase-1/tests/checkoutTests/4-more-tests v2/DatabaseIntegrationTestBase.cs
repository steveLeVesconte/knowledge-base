using System;
using MvcMusicStore.Models;

namespace MvcMusicStore.Tests.TestInfrastructure.Fixtures
{
    /// <summary>
    /// Base class for integration tests that require database access.
    /// Provides helper methods for the fresh context pattern to avoid EF change tracker issues.
    /// </summary>
    /// <remarks>
    /// The ShoppingCart class uses its own internal MusicStoreEntities instance, which is separate
    /// from the fixture's DbContext. This causes EF change tracker caching issues where assertions
    /// might read cached entities instead of actual persisted data. The helper methods in this class
    /// ensure that verification queries use a fresh DbContext to read the true database state.
    /// </remarks>
    public abstract class DatabaseIntegrationTestBase
    {
        protected readonly DatabaseFixture Fixture;

        protected DatabaseIntegrationTestBase(DatabaseFixture fixture)
        {
            Fixture = fixture;
        }

        /// <summary>
        /// Executes a query with a fresh DbContext and returns the result.
        /// Use this when verifying database state after mutations performed by the system under test.
        /// </summary>
        /// <typeparam name="T">The return type of the query</typeparam>
        /// <param name="query">A function that executes the query against the provided context</param>
        /// <returns>The result of the query</returns>
        /// <example>
        /// var cartItem = WithFreshContext(db => 
        ///     db.Carts.SingleOrDefault(c => c.CartId == _testCartId));
        /// </example>
        protected T WithFreshContext<T>(Func<MusicStoreEntities, T> query)
        {
            using (var context = Fixture.CreateDbContext())
            {
                return query(context);
            }
        }

        /// <summary>
        /// Executes an action with a fresh DbContext (for assertions without return values).
        /// Use this when verifying database state after mutations performed by the system under test.
        /// </summary>
        /// <param name="action">An action to execute against the provided context</param>
        /// <example>
        /// WithFreshContext(db =>
        /// {
        ///     var cartItem = db.Carts.Single(c => c.RecordId == recordId);
        ///     cartItem.Count.Should().Be(1);
        /// });
        /// </example>
        protected void WithFreshContext(Action<MusicStoreEntities> action)
        {
            using (var context = Fixture.CreateDbContext())
            {
                action(context);
            }
        }
    }
}