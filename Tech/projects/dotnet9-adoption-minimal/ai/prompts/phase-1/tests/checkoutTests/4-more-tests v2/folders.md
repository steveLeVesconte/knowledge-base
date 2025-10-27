
MvcMusicStore.Tests/
├── Integration/
│   ├── Business/
│   │   ├── ShoppingCartIntegrationTests.cs
│   │   ├── CheckoutIntegrationTests.cs
│   │   └── CatalogIntegrationTests.cs
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