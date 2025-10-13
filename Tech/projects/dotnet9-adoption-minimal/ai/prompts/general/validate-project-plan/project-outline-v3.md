# .NET Framework to .NET 9 Migration Project

## Project Overview

**Migration Story**: .NET Framework 4.6.1 MVC Music Store → Modern .NET 9 Application

**Dual Purpose**:

- Learn concepts related to AZ-204 certification
- Create portfolio project demonstrating legacy application modernization

**Target Outcomes**:

- Complete migration methodology others can follow
- Measurable performance improvements
- Modern Azure cloud-native deployment
- Comprehensive documentation and lessons learned

Important Risk:
- Legacy Project may have initial browser compatibility issues related to Ajax - test for this early on  (recent change)

---

## Migration Phases

### Phase 1: Foundation & Local Baselines

**Branch Strategy**: `phase-1-foundation` with sub-branches:

- `phase-1a-local-setup` - Environment setup and validation
- `phase-1b-testing-framework` - Test coverage expansion
- `phase-1c-baselines` - Performance baseline capture

**Version**: `v1.0.0`

**AZ-204 Skills**: Azure Application Insights (local telemetry)

**Completion Criteria**:

- [ ] All tests pass locally
- [ ] Performance baselines documented
- [ ] App runs identically to original
- [ ] Migration readiness checklist complete

**Tasks**:

- Ensure stable compilation and build process
- Comprehensive smoke testing - all pages for all user types
- Inventory tech stack - versions and dependencies
- **Document ASP.NET Identity 2.2.2 implementation** (Admin/Visitor roles)
- **Document OWIN pipeline** (cookie auth only - OAuth providers commented out)
- **Test ASP.NET Identity flows** (registration, login, roles) - LOCAL ONLY
- **Validate shopping cart session behavior**
- **Ensure admin interface functionality** (StoreManagerController operations)
- change unit test tool to xunit  (recent change)
- Expand unit test coverage  (currently minimal - only one test)
- Add integration tests for authentication flows
- Add unit tests for core business logic (Album/Artist/Genre management)
- Add Application Insights instrumentation for local development  (recent change) (moved down below unit testing)
- **Capture comprehensive performance baselines**

**Local Performance Baselines**:

- Page load times (home, catalog, product detail, checkout flow)
- Database query performance (especially complex joins, searches)
- Memory usage patterns
- Application startup time
- ASP.NET Identity operation performance
- Shopping cart operations performance
- Admin interface response times
- Search functionality performance

### Phase 2: Azure Migration & Deployment

**Branch Strategy**: `phase-2-azure-migration` with sub-branches:

- `phase-2a-database-migration` - LocalDB to Azure SQL migration
- `phase-2b-app-service-setup` - Azure App Service configuration
- `phase-2c-deployment-pipeline` - CI/CD pipeline creation

**Version**: `v2.0.0`

**AZ-204 Skills**: Azure App Service, Azure SQL Database, GitHub Actions

**Completion Criteria**:

- [ ] App runs identically in Azure
- [ ] Database migration successful with data integrity
- [ ] Automated deployment pipeline functional
- [ ] Azure performance baselines captured

**Tasks**:

- **LocalDB → Azure SQL Database migration**
    - Create Azure SQL Database instances (Identity + Music Store)
    - Export LocalDB schema and data
    - Handle Entity Framework Code First migrations
    - Update connection strings for Azure SQL
    - Configure Azure SQL firewall rules
- **Azure App Service configuration**
    - Machine key configuration for consistent cookie encryption
    - Session state configuration for distributed environment
    - HTTPS enforcement setup
- **Secrets management**
    - Move connection strings to Azure App Service Configuration
    - Set up Azure Key Vault integration
- **Infrastructure as Code (Bicep) implementation**
    - Azure SQL Database provisioning
    - Azure App Service provisioning
    - Networking and security configuration
- **Deployment pipeline creation**
    - GitHub Actions workflow for Azure deployment
    - Automated deployment scripts
    - Environment-specific configuration management

### Phase 3: Azure Validation & Baselines

**Branch Strategy**: `phase-3-azure-validation` with sub-branches:

- `phase-3a-functional-testing` - Complete Azure smoke testing
- `phase-3b-performance-testing` - Azure performance benchmarking
- `phase-3c-load-testing` - Capacity and resilience testing

**Version**: `v3.0.0`

**AZ-204 Skills**: Azure Monitor, Application Insights, Load Testing

**Completion Criteria**:

- [ ] All functionality verified in Azure
- [ ] Performance comparison (local vs Azure) documented
- [ ] Load testing baseline established
- [ ] Production readiness checklist complete

**Tasks**:

- **Comprehensive Azure smoke testing**
    - All pages for all user types in Azure environment
    - ASP.NET Identity flows (registration, login, roles) - LOCAL ONLY
    - Shopping cart functionality validation
    - Admin interface operations
    - Database connectivity and performance
- **Azure performance baseline capture**
    - Same metrics as Phase 1 but in Azure environment
    - Cold start performance measurement
    - Azure SQL vs LocalDB performance comparison
    - Network latency impact assessment
- **Load testing establishment**
    - Azure App Service capacity baselines
    - Concurrent user handling in Azure
    - Database connection pool behavior
    - Session state performance under load
- **Environment comparison analysis**
    - Local vs Azure performance comparison
    - Identify Azure-specific optimizations needed
    - Document any Azure-specific behaviors or limitations

### Phase 4: Platform Migration (.NET Framework → .NET 9)

**Branch Strategy**: `phase-4-platform-migration` with sub-branches:

- `phase-4a-dotnet9-upgrade` - Target framework migration (broken check-in likely)
- `phase-4b-ef-core-migration` - Entity Framework 6 to EF Core  (broken check-in likely)
- `phase-4c-identity-migration` - ASP.NET Identity to Core Identity  (broken check-in likely)
- `phase-4d-owin-to-core` - OWIN to ASP.NET Core middleware  (broken check-in likely)
- phase-4e-ui-compatibility - **Focus on functional parity** - make everything work the same  (broken check-in likely)  (recent change) (added new section phase-4e-ui-compatibility)
- phase-4f-integraton - Iteratively fix broken issue until the system works  (recent change)

**Version**: `v4.0.0` _(breaking change - platform migration)_

**AZ-204 Skills**: .NET modernization, EF Core, ASP.NET Core

**Completion Criteria**:

- [ ] 100% functional parity with .NET Framework version - including UI
- [ ] All tests pass in .NET 9
- [ ] Performance comparison document complete
- [ ] Migration guide written for others to follow

**Tasks**:

- **.NET Framework 4.6.1 → .NET 9**
    - Project file modernization
    - Package reference updates
    - API compatibility resolution
- **Entity Framework 6 → EF Core**
    - Code First migrations handling
    - Identity schema preservation
    - Data seeding strategy (genres, sample albums, roles)
    - Connection string modernization
- **ASP.NET Identity → Core Identity migration** (local accounts only)
    - User/role schema migration
    - Authentication cookie compatibility
    - Password hashing compatibility
- **OWIN → Core middleware pipeline conversion**
    - Startup.cs modernization
    - Middleware ordering
    - Cookie authentication setup
- **Session state migration** (shopping cart functionality)
    - Session configuration for Core
    - Shopping cart state preservation
- **Configuration system modernization** (Web.config → appsettings.json)
- **Dependency injection implementation** (app currently has no DI container)
- Enhanced test coverage for migration validation

### Phase 5: Modern Authentication & OAuth Implementation

**Branch Strategy**: `phase-5-modern-auth` with sub-branches:

- `phase-5a-oauth-providers` - External OAuth provider integration
- `phase-5b-modern-identity` - Enhanced identity patterns
- `phase-5c-security-hardening` - Security modernization

**Version**: `v5.0.0` _(breaking change - authentication model)_

**AZ-204 Skills**: Azure AD integration, OAuth flows, Azure Key Vault

**Completion Criteria**:

- [ ] All OAuth providers functional in production
- [ ] Modern identity patterns implemented
- [ ] Security audit passed
- [ ] Authentication performance benchmarks captured

**Prerequisites**: Platform migration complete, .NET 9 stable

**Tasks**:

- **OAuth Provider Implementation** (using .NET 9 patterns)
    - Google OAuth 2.0 integration
    - Microsoft Account integration
    - Facebook Login integration
    - Twitter OAuth integration
- **Modern Identity Patterns**
    - Refresh tokens implementation
    - Secure cookie enhancement
    - Claims-based authorization refinement
    - JWT token handling for API scenarios
- **OAuth Provider Configuration**
    - Azure App Service OAuth configuration
    - Redirect URI management for Azure environment
    - Secrets management via Azure Key Vault
- **Authentication Flow Enhancement**
    - External provider account linking
    - Account consolidation strategies
    - Social login UX implementation
- **Security Modernization**
    - PKCE implementation for OAuth flows
    - State parameter validation
    - Anti-forgery token integration
- **Testing & Validation**
    - OAuth flow integration testing
    - External provider sandbox testing
    - Production OAuth validation

### Phase 6: Observability & Performance

**Branch Strategy**: `phase-6-observability` with sub-branches:

- `phase-6a-telemetry` - OpenTelemetry implementation
- `phase-6b-monitoring` - Advanced monitoring setup
- `phase-6c-dashboards` - Performance dashboards

**Version**: `v5.1.0`

**AZ-204 Skills**: Azure Monitor, Log Analytics, Application Insights

**Tasks**:

- OpenTelemetry implementation
- Structured logging enhancement
- Performance monitoring and dashboards
- Health check endpoints expansion
- **E-commerce specific monitoring** (cart abandonment, conversion funnels)
- **OAuth performance monitoring** (external provider latency, auth success rates)

### Phase 7: Scalability Patterns

**Branch Strategy**: `phase-7-scalability` with sub-branches:

- `phase-7a-caching` - Redis implementation
- `phase-7b-session-state` - Distributed session management
- `phase-7c-async-patterns` - Async/await optimization

**Version**: `v5.2.0`

**AZ-204 Skills**: Azure Cache for Redis, Performance optimization

**Tasks**:

- Distributed caching (Redis)
- **Session state externalization** (critical for shopping cart)
- Database connection pooling
- Async/await pattern adoption
- **Shopping cart state management** optimization
- **OAuth token caching strategies**
- Load testing implementation

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