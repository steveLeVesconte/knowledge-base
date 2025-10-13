## Phase 4: Platform Migration (.NET Framework → .NET 9)

**Branching Strategy**: `phase-4-platform-migration` with sub-branches:

- `phase-4a-dotnet9-upgrade` - Target framework migration
- `phase-4b-ef-core-migration` - Entity Framework 6 to EF Core
- `phase-4c-identity-migration` - ASP.NET Identity to Core Identity
- `phase-4d-owin-to-core` - OWIN to ASP.NET Core middleware
- `phase-4e-bootstrap-upgrade` - Bootstrap 3.4.1 to Bootstrap 5.3 (parity only)
- `phase-4f-ui-integration` - View layer integration and repair

**Version**: `v4.0.0` _(breaking change - platform migration)_

**AZ-204 Skills**: .NET modernization, EF Core, ASP.NET Core

**Completion Criteria**:

- [ ] 100% functional parity with .NET Framework version - including UI
- [ ] All tests pass in .NET 9
- [ ] All EOL dependencies eliminated (Bootstrap 3.4.1 → 5.3)
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
- **ASP.NET Identity → Core Identity migration**
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
- **Bootstrap 3.4.1 → Bootstrap 5.3 migration (UI parity only)**
    - **Decision Rationale**: Bootstrap 3.4.1 reached EOL in July 2019 and has known CVEs (CVE-2024-6484, CVE-2024-6485). Upgrading eliminates all EOL dependencies, demonstrates complete modernization, and provides learning experience with CSS framework migrations. The 2-3 day effort is justified by portfolio completeness and professional standards.
    - **Scope**: Functional parity only - no UI/UX improvements, no layout redesigns, no feature additions
    - **Update framework references**
        - Change CDN links from Bootstrap 3.4.1 to Bootstrap 5.3.x
        - Remove jQuery dependency from Bootstrap (keep minimal jQuery only if needed for custom Ajax)
        - Update any npm/package.json references
    - **Systematic class name updates**
        - Utility class renames: `.ml-*` → `.ms-*`, `.mr-*` → `.me-*`, `.pl-*` → `.ps-*`, `.pr-*` → `.pe-*`
        - Text alignment: `.text-left` → `.text-start`, `.text-right` → `.text-end`
        - Float classes: `.float-left` → `.float-start`, `.float-right` → `.float-end`
        - Border utilities: `.border-left` → `.border-start`, `.border-right` → `.border-end`
        - Use find/replace with careful verification for automated updates
    - **Form markup modernization**
        - Remove `.form-group` wrapper classes (no longer needed)
        - Update form controls to use Bootstrap 5 patterns
        - Add `.form-check` and `.form-check-input` to checkboxes/radios
        - Verify form validation styling still works
        - Test registration, login, and checkout forms thoroughly
    - **Component updates**
        - Navbar: Update to Bootstrap 5 navbar structure if needed
        - Buttons: Verify button classes work (most should be compatible)
        - Tables: Check table styling classes
        - Alerts/badges: Update to new class patterns if used
        - Modals: Verify modal markup if any exist
    - **JavaScript refactoring**
        - Remove Bootstrap 3 jQuery plugin dependencies
        - Use Bootstrap 5 vanilla JS API for components (tooltips, modals, etc.)
        - Preserve custom jQuery for Ajax shopping cart if simpler than rewriting
        - Test all interactive features (add to cart, remove from cart, etc.)
    - **Grid system verification**
        - Test responsive breakpoints (xs, sm, md, lg, xl)
        - Verify gutter spacing looks correct
        - Check that layouts remain consistent across screen sizes
    - **Systematic testing checklist**
        - Home page renders without console errors
        - Store catalog displays correctly
        - Album detail pages maintain layout
        - Shopping cart UI functions identically
        - Checkout flow works
        - Login/register pages render correctly
        - Admin interface (StoreManager) works
        - All forms submit successfully
        - Responsive behavior verified on mobile/tablet/desktop
    - **Visual parity verification**
        - Compare side-by-side with Phase 3 screenshots/baseline
        - Ensure no unintended visual changes
        - Document any unavoidable minor differences (e.g., default spacing changes)
    - **Migration documentation**
        - Document all breaking changes encountered
        - Record solutions for common Bootstrap 3→5 issues
        - Create troubleshooting guide for view-layer problems
        - Capture before/after for migration playbook
- **View layer integration and systematic repair**
    - **Smoke test all pages post-migration** (run migrated app, test every page type)
    - Document every broken view in a checklist (rendering errors vs functional breaks)
    - Fix Razor syntax changes (Tag Helpers, `@Html` helper signature changes)
    - Restore form submissions that broke during migration
    - Verify authentication-related views work (login/register/logout)
    - Ensure shopping cart UI still functions
    - Fix admin interface views (CRUD operations)
    - **Principle**: "Fix, don't improve" - restore original functionality only
    - Run complete smoke test suite to verify all repairs
- Enhanced test coverage for migration validation

**Bootstrap 5 Migration - Success Criteria**:

- [ ] All Bootstrap 3.4.1 CVEs eliminated from security scans
- [ ] Zero Bootstrap-related console errors on any page
- [ ] All pages render with visual parity to Phase 3 baseline
- [ ] All interactive features work identically to before
- [ ] Forms submit and validate correctly
- [ ] Shopping cart functionality preserved
- [ ] Admin interface fully functional
- [ ] Responsive behavior maintained across all breakpoints
- [ ] No jQuery errors (after refactoring Bootstrap JS dependencies)
- [ ] Migration steps documented for replication

**Bootstrap 5 Migration - Estimated Effort**:

- Update references: 30 minutes
- Automated class renames: 2-3 hours
- Form markup updates: 3-4 hours
- Component fixes: 2-3 hours
- JavaScript refactoring: 4-6 hours
- Systematic testing: 3-4 hours
- Bug fixes and polish: 2-3 hours
- **Total**: 18-25 hours (2.5-3 workdays)

**Why Bootstrap 5 in Phase 4**:

1. **Eliminates EOL Software**: Bootstrap 3.4.1 has known security vulnerabilities and is unsupported
2. **Portfolio Completeness**: Demonstrates full-stack modernization, not just backend migration
3. **Optimal Timing**: Views require updates anyway due to Razor syntax changes in .NET Core
4. **Learning Value**: Provides hands-on experience with CSS framework migration and breaking changes
5. **Professional Standards**: Shows ability to eliminate technical debt and deliver production-ready code
6. **Interview Narrative**: Creates comprehensive "complete modernization" story for career discussions

**Migration Note**: Phase 4 involves simultaneous breaking changes across multiple systems (EF, Identity, OWIN, Bootstrap, project structure). This is intentional - all platform-level changes happen together, followed by systematic repair. The Bootstrap upgrade adds minimal incremental complexity since view files require updates regardless, and eliminates the need for a separate UI modernization phase later.