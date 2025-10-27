# Create Integration Tests for Authentication Flow

## Primary Focus (what TO do)

Create Integration Tests for Authentication flow in a way that is compatible with sharing reusable test infrastructure with other completed integration tests.   The main purpose of these integration tests is to provide safety as I modify classes adding constructor overloads with constructor injection to facilitate unit testing.

Note, the business logic may be mostly in controllers, so these may turn out to be mostly controller integration tests.


Specifications:

between 4 and 10 integration tests focusing on Authentication flow.

- Use shared infrastructure such as:
  - Collection Fixtures (For Multiple Test Classes) employing minimal seed data robust enough to serve for all planned integration tests
  - Use shared fakes:
    - TestHttpContext.cs
    - TestSessionState.cs
    - TestUser.cs
  - **Base test class with shared helper methods for fresh context pattern** (DatabaseIntegrationTestBase.cs)

## Test Assertion Pattern (CRITICAL)

**Entity Framework Context Isolation:**



## Boundaries (what NOT to do):

- Do not go to extremes as in DOD standards
- Do not exceed the normal good practice expected in a regional bank


## Success Criteria (done when):

- ~4-10 integration tests for Integration Flow appear professional for the audience of hiring managers
- All integration tests pass and verify actual persisted state (not cached entities)
- Fresh DbContext pattern consistently applied via helper methods inherited from base class  (when applicable)

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


## Implementation Notes:

- DatabaseIntegrationTestBase (if applicable)
- Helper methods are protected and inherited, not duplicated
