using Xunit;

namespace MvcMusicStore.Tests.TestInfrastructure.Fixtures
{
    /// <summary>
    /// xUnit collection definition for database integration tests.
    /// All test classes marked with [Collection("Database")] will share the same DatabaseFixture instance,
    /// ensuring the test database is created once and reused across all integration tests.
    /// </summary>
    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class is intentionally empty.
        // It serves only as a marker for xUnit's collection fixture feature.
    }
}