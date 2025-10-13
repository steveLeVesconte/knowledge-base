# Phase 1: Foundation & Local Baselines

## Overview

Phase 1 establishes a stable, well-understood baseline of the existing .NET Framework 4.6.1 MVC Music Store application before any migration work begins. This phase is critical for de-risking the entire migration project by documenting current behavior, expanding test coverage, and capturing performance metrics that will serve as comparison points throughout all subsequent phases.

**Duration**: Estimated 2-3 weeks  
**Branch**: `phase-1-foundation`  
**Version**: `v1.0.0`  
**Status**: In Progress

## Objectives

1. **Validate Stability**: Ensure the application builds and runs reliably in its current state
2. **Expand Test Coverage**: Protect existing functionality with comprehensive automated tests
3. **Document Current State**: Create detailed documentation of architecture, dependencies, and authentication
4. **Capture Baselines**: Establish performance metrics for comparison in future phases
5. **De-risk Phase 4**: Identify potential issues early, especially browser compatibility and authentication complexity

## Why Phase 1 Matters

Phase 4 will involve simultaneous breaking changes across multiple systems (EF, Identity, OWIN, project structure). The comprehensive testing and documentation created in Phase 1 will:

- Provide clear regression detection when things break
- Document authentication flows that must be preserved through migration
- Establish performance expectations to validate improvements
- Create a "known good" state to compare against

## Sub-Phases

### Phase 1a: Local Setup & Environment Validation

**Branch**: `phase-1a-local-setup`

Verify the application works reliably and document its current state.

**Key Deliverables**:

- Development environment setup guide
- Complete dependency inventory
- Smoke test checklist (manual testing)
- Current architecture documentation
- ASP.NET Identity 2.2.2 and OWIN pipeline documentation

**Critical Risk**: Test for browser compatibility issues with jQuery/Ajax functionality early.

### Phase 1b: Testing Framework Expansion

**Branch**: `phase-1b-testing-framework`

Build comprehensive automated test coverage to protect against regressions.

**Key Deliverables**:

- Migration from MSTest to xUnit
- Unit tests for business logic (Album, Artist, Genre management)
- Integration tests for authentication flows
- Integration tests for shopping cart operations
- Integration tests for admin interface
- Test coverage report and gap analysis

**Goal**: Establish safety net for Phase 4 platform migration.

### Phase 1c: Performance Baseline Capture

**Branch**: `phase-1c-baselines`

Instrument the application and capture detailed performance metrics.

**Key Deliverables**:

- Application Insights local instrumentation
- Performance baselines for all key metrics
- Repeatable baseline test scenarios
- Performance comparison template for future phases

**Metrics Captured**:

- Page response times (all user flows)
- Database query performance
- Memory footprint and startup time
- Authentication operation performance
- Shopping cart operation performance
- Admin interface response times

## Documentation Checklist

### Phase 1a Documents

- [ ]  environment-setup.md
- [ ]  dependency-inventory.md
- [ ]  current-architecture.md
- [ ]  authentication-flows.md
- [ ]  smoke-test-checklist.md

### Phase 1b Documents

- [ ]  testing-strategy.md
- [ ]  test-coverage-report.md

### Phase 1c Documents

- [ ]  application-insights-setup.md
- [ ]  performance-baselines.md
- [ ]  baseline-test-scenarios.md
- [ ]  performance-comparison-template.md

### Phase Completion

- [ ]  phase-1-retrospective.md
- [ ]  PROJECT-LOG.md updated with phase summary

## Completion Criteria

Phase 1 is complete when:

- [ ]  All tests pass locally (unit + integration)
- [ ]  Performance baselines documented with actual measurements
- [ ]  Pre-migration checklist complete
- [ ]  All documentation artifacts created and reviewed
- [ ]  No critical browser compatibility issues found
- [ ]  Authentication flows fully documented and tested
- [ ]  Phase 1 retrospective completed
- [ ]  Tag `v1.0.0` created

## AZ-204 Skills Demonstrated

- Azure Application Insights (local telemetry and instrumentation)
- Performance monitoring and baseline establishment
- Test-driven development practices
- Documentation of cloud-readiness assessment

## Getting Started

1. Review the [project outline](Tech/projects/dotnet9-adoption-minimal/ai/prompts/phase-1/plan/project-outline.md) for full context
2. Check out branch `phase-1a-local-setup` to begin work
3. Follow the work plan provided by the lead developer
4. Use the templates in `docs/templates/` for consistent documentation
5. Update PROJECT-LOG.md daily with progress

## Important Notes

**For Developers**:

- Document as you go - don't defer documentation to the end
- Capture actual performance numbers - estimates are not baselines
- Test authentication thoroughly - Identity migration in Phase 4 is complex
- Flag browser compatibility issues immediately
- Ask questions early rather than making assumptions

**Critical Dependencies**:

- ASP.NET Identity 2.2.2 (existing user base must be preserved)
- OWIN cookie authentication (no OAuth currently active)
- Entity Framework 6.2.0 with Code First migrations
- Session-based shopping cart (must migrate to distributed state in Phase 7)

## Next Phase

Upon completion of Phase 1, work proceeds to **Phase 2: Azure Migration & Deployment**, which migrates the application to Azure App Service and Azure SQL Database while maintaining identical functionality.


Doc Structure
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

**Last Updated**: [Current Date]  
**Phase Owner**: [Developer Name]  
**Status**: In Progress