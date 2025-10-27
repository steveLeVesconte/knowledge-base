
MvcMusicStore.Tests/
├── Business/
│   ├── ShoppingCartIntegrationTests.cs  (integration - safety net)
│   ├── ShoppingCartTests.cs             (unit - fast feedback)
│   ├── CheckoutIntegrationTests.cs
│   ├── CheckoutTests.cs
│   ├── CatalogIntegrationTests.cs
│   └── CatalogTests.cs
├── Controllers/
│   ├── ShoppingCartControllerTests.cs
│   ├── CheckoutControllerTests.cs
│   └── StoreManagerControllerTests.cs
└── Integration/
│   └──AuthenticationFlowTests.cs
└── Shared/
    └── DatabaseFixture.cs