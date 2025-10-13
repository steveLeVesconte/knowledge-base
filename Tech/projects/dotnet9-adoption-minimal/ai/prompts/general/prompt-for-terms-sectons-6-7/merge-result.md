# .NET Framework to .NET 9 Migration Project

## Project Overview

**Migration Path**: .NET Framework 4.6.1 MVC Music Store → Modern .NET 9 Application

**Dual Purpose**:

- Learn concepts related to AZ-204 certification
- Create portfolio project demonstrating legacy application modernization

**Target Outcomes**:

- Complete migration methodology others can follow
- Measurable performance improvements
- Modern Azure cloud-native deployment
- Comprehensive documentation and lessons learned

**Important Risks**:

- Legacy project may have initial browser compatibility issues related to jQuery/Ajax functionality - test for this early in Phase 1
- Phase 4 will involve simultaneous breaking changes across multiple systems (EF, Identity, OWIN, project structure)

---

## Migration Phases

### Phase 0: Planning

**Branching Strategy**: phase-0-planning - one branch

- choose project for upgrade
- decide on Project Practices
    - investigate scope and tasks
    - make project-outline with ordered sequence of phases and tasks (this document)
    - branching strategy
        - granularity
        - merge pattern
    - repository policy and settings
        - merge policy for main
    - repository documentation decisions:
        - initial README.md
        - CONTRIBUTING.md
        - use a PROJECT-LOG.md

**Completion Criteria**:

- [ ]  Initial project chosen
- [ ]  project-outline (this document) complete, reviewed and committed
- [ ]  GitHub repository created, named, with policy decisions
- [ ]  CONTRIBUTING.md - completed, reviewed and committed
- [ ]  PROJECT-LOG.md with template for daily updates - completed, reviewed and committed
- [ ]  Initial README.md with project vision completed

### Phase 1: Foundation & Local Baselines

**Branching Strategy**: `phase-1-foundation` with sub-branches:

- `phase-1a-local-setup` - Environment setup and validation
- `phase-1b-testing-framework` - Test coverage expansion
- `phase-1c-baselines` - Performance baseline capture

**Version**: `v1.0.0`

**AZ-204 Skills**: Azure Application Insights (local telemetry)

**Completion Criteria**:

- [ ]  All tests pass locally
- [ ]  Performance baselines documented
- [ ]  App runs identically to original
- [ ]  Pre-migration checklist complete

**Tasks**:

- Ensure stable compilation and build process
- End-to-end smoke testing - all pages for all user types - be alert for browser incompatibility issues that may impact Ajax functionality
- Dependency inventory - versions and dependencies
- **Document ASP.NET Identity 2.2.2 implementation** (Admin/Visitor roles)
- **Document OWIN pipeline** (cookie auth only - OAuth providers commented out)
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

### Phase 2: Azure Migration & Deployment

**Branching Strategy**: `phase-2-azure-migration` with sub-branches:

- `phase-2a-database-migration` - LocalDB to Azure SQL Database migration
- `phase-2b-app-service-setup` - Azure App Service configuration
- `phase-2c-deployment-pipeline` - CI/CD pipeline creation

**Version**: `v2.0.0`

**AZ-204 Skills**: Azure App Service, Azure SQL Database, GitHub Actions

**Completion Criteria**:

- [ ]  App runs identically in Azure
- [ ]  Database migration successful with data integrity
- [ ]  Automated CI/CD pipeline functional
- [ ]  Azure performance baselines captured

**Tasks**:

- **LocalDB → Azure SQL Database migration with schema and data migration**
    - Create Azure SQL Database instances (Identity + Music Store)
    - Export LocalDB schema and data
    - Handle Entity Framework Code First migrations
    - Update connection strings for Azure SQL Database
    - Configure Azure SQL Database firewall rules
- **Azure App Service configuration**
    - Machine key configuration for consistent cookie encryption
    - Distributed session state configuration
    - HTTPS enforcement setup
- **Secret management**
    - Move connection strings to Azure App Service Configuration
    - Set up Azure Key Vault integration
- **Infrastructure as Code (Bicep) implementation**
    - Azure SQL Database provisioning
    - Azure App Service provisioning
    - Networking and security configuration
- **CI/CD pipeline creation**
    - GitHub Actions workflow for Azure deployment
    - Automated deployment scripts
    - Environment configuration management

### Phase 3: Azure Validation & Baselines

**Branching Strategy**: `phase-3-azure-validation` with sub-branches:

- `phase-3a-functional-testing` - Complete Azure smoke testing
- `phase-3b-performance-testing` - Azure performance benchmarking
- `phase-3c-load-testing` - Capacity and resilience testing

**Version**: `v3.0.0`

**AZ-204 Skills**: Azure Monitor, Application Insights, Load Testing

**Completion Criteria**:

- [ ]  All functionality verified in Azure
- [ ]  Environment performance delta analysis documented
- [ ]  Baseline load test results established
- [ ]  Production readiness checklist complete

**Tasks**:

- **End-to-end Azure smoke testing**
    - All pages for all user types in Azure environment
    - ASP.NET Identity flows (registration, login, roles) - LOCAL ONLY
    - Shopping cart functionality validation
    - Admin interface operations
    - Database connectivity validation and performance
- **Azure performance baseline capture**
    - Same metrics as Phase 1 but in Azure environment
    - Cold start performance measurement
    - Azure SQL Database vs LocalDB performance comparison
    - Network latency impact assessment
- **Load testing establishment**
    - Azure App Service concurrent user capacity baselines
    - Concurrency handling in Azure
    - Database connection pool behavior
    - Session state performance under load
- **Environment performance delta analysis**
    - Local vs Azure performance comparison
    - Identify cloud-native optimizations needed
    - Document any Azure-specific behaviors or limitations

### ### Phase 4: Platform Migration (.NET Framework → .NET 9)

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

## Phase 5: Modern Authentication & External Identity Providers

**Branch Strategy**: `phase-5-modern-auth` with sub-branches:

- `phase-5a-external-providers` - External authentication provider integration
- `phase-5b-identity-enhancement` - Enhanced identity patterns
- `phase-5c-security-hardening` - Security modernization

**Version**: `v5.0.0` _(major feature - external authentication)_

**AZ-204 Skills**: Microsoft Identity Platform integration, OAuth 2.0, Azure Key Vault

**Completion Criteria**:

- [ ]  Microsoft Identity Platform authentication functional in production
- [ ]  Google OAuth 2.0 authentication functional in production
- [ ]  Account linking between local and external accounts working
- [ ]  Security audit passed
- [ ]  External authentication performance benchmarks captured

**Prerequisites**: Platform migration complete, .NET 9 stable

**Tasks**:

- **External Authentication Provider Integration** (ASP.NET Core Identity)
    - Microsoft Identity Platform (primary external provider)
    - Google OAuth 2.0 (secondary external provider)
    - External authentication middleware configuration
    - Authentication scheme registration
- **OAuth 2.0 Client Registration**
    - Microsoft Identity Platform app registration in Azure Portal
    - Google Cloud Console OAuth 2.0 client setup
    - OAuth callback endpoint configuration
    - Client secrets management using Azure Key Vault
- **Account Linking Implementation**
    - Associate external logins with existing local accounts
    - Multiple external login association (same user, multiple providers)
    - External login UI/UX implementation
- **OAuth 2.0 Security Implementation**
    - PKCE (Proof Key for Code Exchange) for authorization code flow
    - OAuth state parameter validation (CSRF protection)
    - Anti-forgery token integration
    - Secure cookie attributes configuration
- **Enhanced Identity Patterns**
    - Claims-based authorization refinement
    - JWT bearer token authentication (for future API endpoints)
    - Cookie authentication security hardening
- **Azure Environment Configuration**
    - OAuth callback URLs for Azure App Service
    - Client secrets stored in Azure Key Vault
    - App Service authentication settings configuration
- **Testing & Validation**
    - External authentication flow integration testing
    - Provider sandbox environment testing (development credentials)
    - Account linking scenario testing
    - Production external authentication validation
    - Performance monitoring for external provider latency

**External Authentication Performance Metrics**:

- Microsoft Identity Platform authentication response times
- Google OAuth 2.0 authentication response times
- External provider API latency impact
- Account linking operation performance
- External authentication success/failure rates

# Phase 6: Observability & Instrumentation

**Branch Strategy**: `phase-6-observability` with sub-branches:

- `phase-6a-telemetry` - OpenTelemetry instrumentation
- `phase-6b-apm-setup` - Application Performance Monitoring configuration
- `phase-6c-dashboards` - Telemetry visualization and alerting

**Version**: `v5.1.0`

**AZ-204 Skills**: Azure Monitor, Log Analytics, Application Insights, OpenTelemetry

**Completion Criteria**:

- [ ]  OpenTelemetry instrumentation operational with distributed tracing
- [ ]  Application Performance Monitoring (APM) dashboards configured
- [ ]  Business telemetry for e-commerce workflows captured
- [ ]  **[OPTIONAL]** SLIs (Service Level Indicators) defined and measured
- [ ]  Correlation ID propagation implemented across application layers
- [ ]  **[OPTIONAL]** Alert rules configured for critical metrics

**Tasks**:

- **OpenTelemetry instrumentation implementation** ✅ CORE
    - Traces: Distributed tracing across HTTP requests, database calls, external services
    - Metrics: Custom metrics for business and technical indicators
    - Logs: Structured logging with semantic context
    - Correlation ID propagation for request tracking
- **Structured logging enhancement** ✅ CORE
    - Semantic logging patterns (leveraging .NET's `ILogger<T>`)
    - Log level standardization (Debug, Information, Warning, Error, Critical)
    - Contextual properties (user ID, session ID, correlation ID)
    - Structured log aggregation in Azure Log Analytics
- **Application Performance Monitoring (APM) configuration** ✅ CORE
    - Request/response telemetry collection
    - Dependency tracking (SQL, Redis, external IdPs)
    - Exception tracking and error rate monitoring
    - Custom event tracking for business operations
- **Readiness and liveness probe endpoints** ✅ CORE
    - Health check endpoints for application dependencies (database, cache, external services)
    - **[DELAYABLE to Phase 9]** Startup probes for application initialization validation (Kubernetes-specific)
    - Dependency health indicators (deep vs. shallow checks)
- **Business telemetry instrumentation** ✅ CORE
    - Conversion funnel metrics (browse → cart → checkout → purchase)
    - Cart abandonment tracking and analysis
    - Album search and catalog browsing patterns
    - User registration and authentication flow metrics
    - Admin operations audit logging
- **Identity provider (IdP) integration telemetry** ✅ CORE
    - External authentication latency tracking (Microsoft, Google)
    - Authentication success/failure rates by provider
    - Token acquisition and refresh performance
    - IdP availability monitoring
- **Service Level Indicators (SLIs) definition** 🔶 OPTIONAL (Enterprise concern)
    - Request success rate (availability)
    - Request duration (latency percentiles: p50, p95, p99)
    - Error budget calculation framework
    - **Note**: Useful for learning monitoring concepts, but can defer if time-constrained
- **Telemetry visualization dashboards** ✅ CORE
    - Real-time application health dashboard
    - Performance trend analysis (historical comparisons)
    - Business metrics dashboard (conversion rates, user activity)
    - **[OPTIONAL]** Infrastructure metrics (App Service, Azure SQL Database, Redis) - can use Azure portal defaults initially
- **Alerting and notification rules** 🔶 OPTIONAL (Can start with manual monitoring)
    - Threshold-based alerts (error rates, response times, dependency failures)
    - **[DELAYABLE]** Anomaly detection for business metrics (advanced feature)
    - Alert action groups (email, SMS, webhook)
    - **Note**: Can manually check dashboards initially; add alerts when moving toward production

**Observability Metrics Captured**:

- Request throughput (requests/second) ✅
- Response time percentiles (p50, p95, p99) ✅
- Error rates by endpoint and exception type ✅
- Dependency call duration (database, cache, external IdP) ✅
- Business conversion rates (cart-to-purchase, browse-to-cart) ✅
- Authentication operation performance by provider ✅
- Cache hit ratios and eviction rates ✅

---

# Phase 7: Horizontal Scalability Patterns

**Branch Strategy**: `phase-7-scalability` with sub-branches:

- `phase-7a-distributed-cache` - Redis implementation and cache patterns
- `phase-7b-session-state` - Distributed session state management
- `phase-7c-async-io` - Asynchronous I/O pattern optimization
- `phase-7d-resilience` - **[OPTIONAL]** Resilience patterns for external dependencies

**Version**: `v5.2.0`

**AZ-204 Skills**: Azure Cache for Redis, Performance optimization, Resilience patterns

**Completion Criteria**:

- [ ]  Distributed cache operational with measurable performance gains
- [ ]  Distributed session state functional for shopping cart workflows
- [ ]  Asynchronous I/O patterns adopted across data access layer
- [ ]  **[OPTIONAL]** Circuit breaker pattern implemented for external IdP calls
- [ ]  Performance and load testing validates horizontal scalability
- [ ]  Connection pool optimization documented and configured

**Tasks**:

- **Distributed cache implementation (Azure Cache for Redis)** ✅ CORE
    - Azure Cache for Redis provisioning and configuration
    - **[OPTIONAL]** Connection multiplexing configuration (StackExchange.Redis) - defaults work for small scale
    - Cache-aside pattern for catalog data (albums, artists, genres)
    - **[DELAYABLE]** Cache warming strategies for frequently accessed data - validate need with metrics first
    - Cache expiration policies (absolute, sliding, time-based)
    - Cache invalidation patterns for data mutations
- **Distributed session state management** ✅ CORE
    - Out-of-process session state with Redis backend
    - Session state serialization optimization
    - Shopping cart state migration to distributed session
    - Session affinity considerations and stateless design
    - Session timeout and sliding expiration configuration
- **Connection pool optimization** ✅ CORE
    - Database connection pool tuning (min/max pool size)
    - Connection lifetime and resilience configuration
    - Redis connection pool management
    - Connection pool monitoring and telemetry
- **Asynchronous I/O pattern adoption** ✅ CORE
    - Async/await throughout MVC controllers
    - Asynchronous database operations (EF Core async methods)
    - Asynchronous cache operations
    - Asynchronous external HTTP calls (HttpClient for IdP)
    - Thread pool exhaustion prevention
- **Token cache management** ✅ CORE
    - Authentication token caching strategy
    - Refresh token persistence and rotation
    - Token cache invalidation on user sign-out
    - Distributed token cache for multi-instance scenarios
- **Resilience patterns for external dependencies** 🔶 OPTIONAL (Production hardening)
    - **[OPTIONAL]** Circuit breaker pattern for IdP authentication calls (Polly library)
    - **[OPTIONAL]** Retry policies with exponential backoff (Polly library)
    - **[OPTIONAL]** Timeout policies for external HTTP calls
    - **[OPTIONAL]** Fallback strategies for degraded external service scenarios
    - **Note**: Start with basic timeout configuration; add Polly patterns if experiencing IdP reliability issues
- **Performance testing and load testing** ✅ CORE (but can simplify)
    - Load testing tool selection (Azure Load Testing, JMeter, k6)
    - Baseline load tests (concurrent users, requests/second)
    - **[OPTIONAL]** Stress testing to identify breaking points - useful but not critical for portfolio
    - **[OPTIONAL]** Soak testing for sustained load scenarios (memory leaks, connection exhaustion) - enterprise concern
    - Performance regression testing against Phase 3 baselines
- **Horizontal scalability validation** ✅ CORE
    - Multi-instance deployment testing (scale-out to 2+ instances)
    - Session state consistency across instances
    - Cache consistency validation
    - Load balancer behavior verification
    - **[DELAYABLE to Phase 9]** Auto-scaling rule configuration and testing - relevant when containerized

**Scalability Metrics Captured**:

- Cache hit ratio and miss rate by cache key pattern ✅
- Session state operation latency (read/write) ✅
- Database connection pool utilization (active, idle connections) ✅
- Asynchronous operation throughput improvements ✅
- **[OPTIONAL]** Circuit breaker state transitions (closed, open, half-open) - only if implementing circuit breakers
- Request handling capacity (max concurrent users) ✅
- Response time degradation under load ✅
- Resource utilization per instance (CPU, memory, network) ✅
- **[OPTIONAL]** Time to scale (scale-out duration when auto-scaling triggers) - defer to Phase 9

**Load Testing Scenarios**:

- **Steady-state load**: 100 concurrent users, 30-minute duration ✅ CORE
- **[OPTIONAL]** Spike test: Rapid increase from 50 to 500 users - demonstrates scalability but not essential
- **[OPTIONAL]** Stress test: Gradual increase until response time SLI breach - useful for capacity planning
- **[OPTIONAL]** Soak test: 50 concurrent users, 4-hour duration - finds memory leaks but time-intensive
- **Shopping cart workflow**: Realistic user journey (browse → cart → checkout) ✅ CORE
- **Admin operations**: Catalog management under concurrent load ✅ CORE

### Phase 8: Architecture Evolution

**Branch Strategy**: `phase-8-microservices` with sub-branches:

- `phase-8a-service-extraction` - First microservice extraction
- `phase-8b-api-gateway` - API Gateway implementation
- `phase-8c-event-driven` - Event-driven patterns

**Version**: `v6.0.0` _(breaking change - architecture)_

**AZ-204 Skills**: Microservices, Azure Service Bus, API Management

**Tasks**:

- Extract first microservice (user management/authentication)
- API Gateway patterns
- Service-to-service communication
- Event-driven architecture introduction
- Service mesh considerations
- **OAuth token propagation** between services
- **Payment processing** security considerations (if implemented)

### Phase 9: Cloud Native Transformation

**Branch Strategy**: `phase-9-cloud-native` with sub-branches:

- `phase-9a-containerization` - Docker implementation
- `phase-9b-kubernetes` - Kubernetes deployment
- `phase-9c-cloud-storage` - Cloud-native storage patterns

**Version**: `v7.0.0` _(breaking change - deployment model)_

**AZ-204 Skills**: Azure Container Registry, AKS, Azure Container Apps

**Tasks**:

- Containerization (Docker)
- Kubernetes deployment patterns
- Configuration management (Azure Key Vault)
- Secrets management modernization
- Cloud-native storage patterns
- **OAuth secrets in Kubernetes**
- **Image/asset migration** strategies (album artwork)

### Phase 10: DevOps Excellence

**Branch Strategy**: `phase-10-devops` with sub-branches:

- `phase-10a-advanced-pipelines` - Multi-environment pipelines
- `phase-10b-quality-gates` - Automated quality assurance
- `phase-10c-security-scanning` - Security automation

**Version**: `v7.1.0`

**AZ-204 Skills**: GitHub Actions, Azure DevOps, Security practices

**Tasks**:

- Advanced GitHub Actions workflows
- Multi-environment promotion pipelines
- Automated quality gates
- Security scanning integration
- Compliance and audit automation
- **OAuth security scanning**
- **Frontend tooling modernization** assessment

---

## Documentation Strategy

### **Required Documentation by Phase**

```
docs/
├── architecture-decisions/         # ADRs for each major decision
│   ├── 001-database-migration.md
│   ├── 002-authentication-strategy.md
│   └── 003-oauth-provider-selection.md
├── migration-journal/             # Daily/weekly progress notes
│   ├── phase-1-journal.md
│   ├── phase-4-challenges.md
│   └── oauth-implementation-notes.md
├── performance-benchmarks/        # Before/after metrics
│   ├── baseline-measurements.md
│   ├── azure-vs-local-comparison.md
│   └── dotnet9-performance-gains.md
├── troubleshooting-guide/         # Problems encountered and solutions
│   ├── ef-core-migration-issues.md
│   ├── oauth-redirect-problems.md
│   └── azure-deployment-gotchas.md
└── lessons-learned/              # Retrospectives after each phase
    ├── phase-4-retrospective.md
    ├── oauth-lessons-learned.md
    └── final-project-retrospective.md
```

## Branch Strategy Implementation

### **Main Development Pattern**

```bash
# Phase work pattern
git checkout main
git checkout -b phase-4-platform-migration
git checkout -b phase-4a-dotnet9-upgrade

# Work on specific problem with frequent commits
git add . && git commit -m "feat: upgrade project file to .NET 9"
git add . && git commit -m "fix: resolve package compatibility issues"

# Merge sub-branch back
git checkout phase-4-platform-migration
git merge phase-4a-dotnet9-upgrade

# Continue with next sub-branch
git checkout -b phase-4b-ef-core-migration
# ... work and merge

# Final phase merge
git checkout main
git merge phase-4-platform-migration --no-ff  # Preserve branch history
git tag v4.0.0 -m "Platform migration to .NET 9 complete"
```

## Success Metrics

### **Phase-Specific Measurable Outcomes**

|Phase|Performance Metrics|Quality Metrics|
|---|---|---|
|**Phase 1**|Local baseline times|Test coverage %|
|**Phase 3**|Azure vs local comparison|Uptime %|
|**Phase 4**|.NET 9 performance gains|Migration success %|
|**Phase 5**|OAuth response times|Security scan results|
|**Phase 6**|Monitoring coverage|MTTR improvements|
|**Phase 7**|Cache hit ratios|Scalability metrics|

### **Overall Project Success Criteria**

- [ ] Complete functional parity maintained throughout
- [ ] Measurable performance improvements documented
- [ ] Zero data loss during migrations
- [ ] All security audits passed
- [ ] Comprehensive migration guide produced
- [ ] AZ-204 skills demonstrated and documented

## Migration-Specific Considerations

### **Authentication Migration Complexity**

- ASP.NET Identity 2.2.2 with existing user base
- OWIN cookie authentication pipeline (OAuth commented out)
- Role-based authorization (Admin/Visitor roles)
- Email-based authentication system

### **Entity Framework Migration Challenges**

- EF 6.2.0 → EF Core with existing data
- ASP.NET Identity schema migration
- Music store schema (Albums, Artists, Genres)
- Code First migrations preservation
- LocalDB connection string modernization

### **E-commerce Specific Requirements**

- Shopping cart session state management
- User workflow preservation (browse → cart → checkout)
- Admin interface for catalog management
- Image handling for album artwork
- Search functionality performance

### **Legacy Dependencies to Address**

- jQuery 3.3.1 → Modern JavaScript patterns
- Bootstrap 3.4.1 → Bootstrap 5+
- Modernizr 2.8.3 → Assess continued necessity
- OWIN middleware → ASP.NET Core middleware
- Web.config → appsettings.json configuration