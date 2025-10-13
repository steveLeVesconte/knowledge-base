# Phase 1: Foundation & Local Baselines - Work Plan

## Overview
Phase 1 establishes a stable baseline before any migration work begins. Think of this as "measure twice, cut once" - we're documenting what we have, ensuring it works reliably, and capturing performance metrics that we'll compare against throughout the migration.

## Work Breakdown by Sub-Phase

### **Phase 1a: Local Setup & Environment Validation**
**Branch**: `phase-1a-local-setup`

**Tasks**:
1. Clone repository and verify build succeeds on clean machine
2. Document local development environment requirements (SDK versions, tooling)
3. Create smoke test checklist for manual testing
4. Execute smoke tests for all user roles (anonymous, authenticated user, admin)
5. Document current dependency versions
6. Create pre-migration system architecture diagram

**Expected Artifacts**:
- `docs/phase-1/environment-setup.md` - Development environment requirements
- `docs/phase-1/dependency-inventory.md` - Complete package list with versions
- `docs/phase-1/smoke-test-checklist.md` - Manual test scenarios
- `docs/phase-1/current-architecture.md` - System diagram and component descriptions
- `docs/phase-1/authentication-flows.md` - Document ASP.NET Identity 2.2.2 and OWIN implementation

**Project Log Entry Template**:
```markdown
## [Date] - Phase 1a: Local Setup
### Completed
- Built project successfully on [machine/OS]
- Verified all [X] smoke test scenarios pass
- Documented [X] dependencies

### Issues Found
- [Describe any browser compatibility issues with jQuery/Ajax]
- [Note any build warnings or deprecated packages]

### Next Steps
- Begin Phase 1b testing framework work
```

---

### **Phase 1b: Testing Framework Expansion**
**Branch**: `phase-1b-testing-framework`

**Tasks**:
1. Convert existing unit tests from MSTest to xUnit
2. Add unit tests for business logic (Album, Artist, Genre CRUD)
3. Create integration tests for authentication flows (register, login, role assignment)
4. Add integration tests for shopping cart operations
5. Add integration tests for StoreManager controller operations
6. Investigate JavaScript test framework options (if Ajax issues found in Phase 1a)
7. Document test coverage gaps for Phase 4 preparation

**Expected Artifacts**:
- `docs/phase-1/testing-strategy.md` - Approach, frameworks chosen, coverage goals
- `docs/phase-1/test-coverage-report.md` - Initial coverage baseline and gaps
- `tests/MvcMusicStore.Tests.Unit/` - xUnit test project
- `tests/MvcMusicStore.Tests.Integration/` - Integration test project

**Project Log Entry Template**:
```markdown
## [Date] - Phase 1b: Testing Framework
### Completed
- Converted [X] tests from MSTest to xUnit
- Added [X] new unit tests (coverage: [Y]%)
- Created [X] integration tests for auth flows

### Challenges
- [Describe any difficulties testing legacy code]
- [Note areas difficult to test without refactoring]

### Coverage Metrics
- Unit test coverage: [X]%
- Integration test coverage: [X] scenarios

### Next Steps
- Begin Phase 1c baseline capture
```

---

### **Phase 1c: Performance Baseline Capture**
**Branch**: `phase-1c-baselines`

**Tasks**:
1. Add Application Insights SDK to project (local telemetry only)
2. Instrument key operations with custom telemetry
3. Execute standardized load scenarios and capture metrics
4. Document baseline performance for all metrics listed in project outline
5. Create baseline comparison template for future phases

**Expected Artifacts**:
- `docs/phase-1/performance-baselines.md` - All baseline metrics with methodology
- `docs/phase-1/application-insights-setup.md` - Configuration and instrumentation guide
- `docs/phase-1/baseline-test-scenarios.md` - Repeatable test procedures
- `docs/phase-1/performance-comparison-template.md` - Template for future phase comparisons

**Project Log Entry Template**:
```markdown
## [Date] - Phase 1c: Performance Baselines
### Completed
- Instrumented [X] operations with Application Insights
- Captured baseline for [X] metrics
- Average page response time: [X]ms
- Database query performance: [X]ms (complex queries)

### Baseline Metrics Summary
- Home page: [X]ms
- Catalog page: [X]ms
- Product detail: [X]ms
- Cart operations: [X]ms
- Admin operations: [X]ms
- Memory footprint: [X]MB
- Application startup: [X]s

### Next Steps
- Review all Phase 1 artifacts
- Prepare Phase 1 completion checklist
```

---

## Documentation Structure

```
docs/
├── phase-1/
│   ├── README.md                          # Phase 1 overview and index
│   ├── environment-setup.md               # Dev environment requirements
│   ├── dependency-inventory.md            # Package versions
│   ├── current-architecture.md            # System diagrams
│   ├── authentication-flows.md            # Identity/OWIN documentation
│   ├── smoke-test-checklist.md            # Manual test scenarios
│   ├── testing-strategy.md                # Test approach and frameworks
│   ├── test-coverage-report.md            # Coverage baseline
│   ├── application-insights-setup.md      # Instrumentation guide
│   ├── performance-baselines.md           # All performance metrics
│   ├── baseline-test-scenarios.md         # Repeatable tests
│   ├── performance-comparison-template.md # Template for future phases
│   └── phase-1-retrospective.md           # Lessons learned (at completion)
└── templates/
    ├── smoke-test-template.md             # Reusable test checklist format
    └── performance-baseline-template.md   # Reusable metrics capture format
```

---

## Document Templates

### **Smoke Test Checklist Template** (`docs/templates/smoke-test-template.md`)
```markdown
# Smoke Test Checklist - [Environment]
Date: [Date]
Tester: [Name]
Build Version: [Version]

## Anonymous User Flows
- [ ] Home page loads
- [ ] Browse catalog by genre
- [ ] View album details
- [ ] Search for albums
- [ ] Add album to cart
- [ ] View cart
- [ ] Attempt checkout (should redirect to login)

## Authenticated User Flows
- [ ] Register new account
- [ ] Login with credentials
- [ ] Browse catalog
- [ ] Add to cart
- [ ] Complete checkout process
- [ ] View order confirmation
- [ ] Logout

## Admin User Flows
- [ ] Login as admin
- [ ] Access Store Manager
- [ ] Create new album
- [ ] Edit existing album
- [ ] Delete album
- [ ] Manage genres
- [ ] Manage artists

## Browser Compatibility
- [ ] Chrome [version]: All scenarios pass
- [ ] Firefox [version]: All scenarios pass
- [ ] Edge [version]: All scenarios pass
- [ ] Safari [version]: All scenarios pass (if Mac available)

## Issues Found
[List any failures or unexpected behavior]
```

### **Performance Baseline Template** (`docs/templates/performance-baseline-template.md`)
```markdown
# Performance Baseline - [Phase/Environment]
Date: [Date]
Environment: [Local/Azure/etc]
Configuration: [Hardware specs, app settings]

## Test Methodology
- Tool: [Application Insights/Custom/etc]
- Duration: [Time period]
- Load: [Concurrent users/requests]
- Warm-up: [Yes/No, duration]

## Page Response Times (ms)
| Page | p50 | p95 | p99 | Avg |
|------|-----|-----|-----|-----|
| Home | | | | |
| Catalog (Genre) | | | | |
| Album Detail | | | | |
| Search Results | | | | |
| Cart | | | | |
| Checkout | | | | |
| Admin Dashboard | | | | |

## Database Performance (ms)
| Operation | p50 | p95 | p99 | Avg |
|-----------|-----|-----|-----|-----|
| Album query (single) | | | | |
| Album query (list) | | | | |
| Complex join (catalog) | | | | |
| Search query | | | | |
| Cart operations | | | | |

## Application Metrics
- Application startup time: [X]s
- Memory footprint (idle): [X]MB
- Memory footprint (under load): [X]MB
- Peak memory usage: [X]MB

## Authentication Operations (ms)
| Operation | p50 | p95 | p99 | Avg |
|-----------|-----|-----|-----|-----|
| Registration | | | | |
| Login | | | | |
| Logout | | | | |
| Role check | | | | |

## Notes
[Any observations about performance characteristics]
```

---

## Phase 1 Completion Checklist

Before merging `phase-1-foundation` to `main`:

- [ ] All sub-branches merged to `phase-1-foundation`
- [ ] All tests pass (unit + integration)
- [ ] All documentation artifacts created and reviewed
- [ ] Performance baselines captured and documented
- [ ] `docs/phase-1/phase-1-retrospective.md` completed
- [ ] PROJECT-LOG.md updated with phase summary
- [ ] Tag created: `v1.0.0`
- [ ] Ready to begin Phase 2

---

## Key Reminders

**For the Junior Developer**:
1. **Don't skip the smoke tests** - finding browser issues now saves pain in Phase 4
2. **Document as you go** - don't wait until the end to write docs
3. **Capture actual numbers** - baselines are useless without real metrics
4. **Test authentication thoroughly** - Identity migration in Phase 4 is complex
5. **Ask questions early** - if something seems wrong, flag it now

**Critical Success Factors**:
- Stable, repeatable build process
- Comprehensive test coverage protecting existing functionality
- Accurate performance baselines for comparison
- Complete understanding of current authentication implementation

This plan provides structure without bureaucracy - focus on artifacts that will actually be useful in later phases.