### Phase 4: Platform Migration (.NET Framework → .NET 9)

**Branching Strategy**: `phase-4-platform-migration` with sub-branches:

- `phase-4a-dotnet9-upgrade` - Target framework migration 
- `phase-4b-ef-core-migration` - Entity Framework 6 to EF Core  
- `phase-4c-identity-migration` - ASP.NET Identity to Core Identity  
- `phase-4d-owin-to-core` - OWIN to ASP.NET Core middleware 
- `phase-4e-ui-compatibility` - **Focus on functional parity** - make everything work the same

**Version**: `v4.0.0` _(breaking change - platform migration)_

**AZ-204 Skills**: .NET modernization, EF Core, ASP.NET Core

**Completion Criteria**:

- [ ] 100% functional parity with .NET Framework version - including UI
- [ ] All tests pass in .NET 9
- [ ] Performance regression analysis complete
- [ ] Migration playbook documented for others to follow

**Tasks**:

- **.NET Framework 4.6.1 → .NET 9**
    - SDK-style project format conversion
    - Target Framework Moniker (TFM) update to `net9.0`
    - Package reference migration (packages.config → PackageReference)
    - Breaking change remediation and API surface compatibility
    - Namespace consolidation (System.Web → Microsoft.AspNetCore.*)
- **Entity Framework 6 → EF Core**
    - Migration history preservation
    - Identity schema compatibility
    - Data seeding strategy (genres, sample albums, roles)
    - Provider-specific connection string updates (System.Data.SqlClient → Microsoft.Data.SqlClient)
- **ASP.NET Identity → Core Identity migration** (local accounts only)
    - ASP.NET Identity table schema preservation
    - Cookie authentication interoperability
    - Password hashing compatibility
- **OWIN → Core middleware pipeline conversion**
    - Application startup configuration (Program.cs/Startup.cs refactoring)
    - Middleware pipeline ordering
    - Cookie authentication middleware configuration
- **Session state migration** (shopping cart functionality)
    - Distributed session state configuration
    - Session middleware configuration
    - Shopping cart state preservation
- **Configuration system migration** (Web.config → appsettings.json + environment variables)
    - Hierarchical configuration implementation
    - Environment-specific configuration management
    - User secrets for development environment
- **Dependency injection implementation** (app currently has no DI container)
    - Service registration for application services
    - Service lifetime management (Singleton, Scoped, Transient)
    - Controller and dependency resolution
- Enhanced test coverage for migration validation