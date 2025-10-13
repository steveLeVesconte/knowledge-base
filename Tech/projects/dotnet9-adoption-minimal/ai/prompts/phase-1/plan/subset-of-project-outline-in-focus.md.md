### Phase 1: Foundation & Local Baselines

  

**Branching Strategy**: `phase-1-foundation` with sub-branches:

  

- `phase-1a-local-setup` - Environment setup and validation

- `phase-1b-testing-framework` - Test coverage expansion

- `phase-1c-baselines` - Performance baseline capture

  

**Version**: `v1.0.0`

  

**AZ-204 Skills**: Azure Application Insights (local telemetry)

  

**Completion Criteria**:

  

- [ ] All tests pass locally

- [ ] Performance baselines documented

- [ ] Pre-migration checklist complete

  

**Tasks**:

  

- Ensure stable compilation and build process

- End-to-end smoke testing - all pages for all user types - be alert for browser incompatibility issues that may impact Ajax functionality

- Dependency inventory - versions and dependencies

- **Document ASP.NET Identity 2.2.2 implementation** (Admin/Visitor roles)

- **Document OWIN pipeline** (cookie auth only - comment: OAuth providers exist in codebase but are commented out)

- **Test ASP.NET Identity flows** (registration, login, roles) - LOCAL ONLY

- **Validate shopping cart session behavior**

- **Ensure admin interface functionality** (StoreManagerController operations)

- Change unit test tool to xUnit

- Expand unit test coverage (currently minimal - only three tests)

- Add integration tests for authentication flows

- Add unit tests for core business logic (Album/Artist/Genre management)

- Attempt to add unit tests that may be useful in phase 4 when many things will be broken at once

- Investigate adding JavaScript unit tests that may be useful if the client side code is broken in phase 4

- Add Application Insights instrumentation for local development

- **Capture comprehensive performance baselines**

  

**Local Performance Baselines**:

  

- Page response times (home, catalog, product detail, checkout flow)

- Database query performance (especially complex joins, searches)

- Runtime memory footprint

- Application warm-up time

- ASP.NET Identity operation performance

- Shopping cart operations performance

- Admin interface response times

- Search functionality performance