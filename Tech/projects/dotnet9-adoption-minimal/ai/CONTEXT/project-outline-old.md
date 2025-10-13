Migrate Framework 4.6.1 web app to .NET9

**Migration story to showcase:**

- .NET Framework MVC → .NET 9
- Entity Framework 6 → EF Core
- ASP.NET Identity 2.2.2 → ASP.NET Core Identity
- OWIN middleware → ASP.NET Core middleware
- On-premises → Azure App Service
- IIS → containerized deployment
- Include performance comparisons, modernization decisions

## Evolution Phases (each as a tagged release/branch)

### Phase 0a: Local Foundation & Observability

**Branch**: `phase-0a-local-foundation`  
**Version**: `v0.1.0`

- Choose a legacy .NET Framework 4.6.1 MVC application
- Ensure stable compilation and build process
- Comprehensive smoke testing - all pages for all user types
- Inventory tech stack - versions and dependencies
- **Inventory ASP.NET Identity dependencies** (currently 2.2.2)
- **Document OWIN pipeline** (cookie auth for local accounts only)
- **Catalog existing user roles and permissions** (Admin/Visitor system)
- **Note OAuth infrastructure** (packages installed but providers commented out)
- **Test ASP.NET Identity flows thoroughly** (registration, login, roles with local accounts only)
- **Validate shopping cart session behavior locally**
- **Ensure admin interface functionality** (StoreManagerController operations)
- Add Application Insights instrumentation for local development
- Expand unit test coverage (currently minimal - only one test)
- Add integration tests for authentication flows
- Add unit tests for core business logic (Album/Artist/Genre management)
- Minimal logging and health checks implementation
- **Capture clean local performance baselines**

**Local Performance Baselines to Capture:**

- **Page load times** (home, catalog, product detail, checkout flow)
- **Database query performance** (especially complex joins, searches)
- **Memory usage patterns** (particularly important for Framework apps)
- **Application startup time**
- **Resource consumption** (CPU, memory, I/O during typical usage)
- **ASP.NET Identity operation performance** (login, registration, role checks)
- **Shopping cart operations** (add, remove, checkout flow)
- **Admin interface response times** (CRUD operations)
- **Search functionality performance**
- **Image loading performance** (album artwork)

**Local Business Metrics Baselines:**

- **Error rates** by page/function
- **User workflow completion rates** (browse → add to cart → checkout)
- **User registration/login flow completion rates**
- **Admin workflow completion rates**
- **Database deadlocks/timeouts** (LocalDB specific)

### Phase 0b: Azure Migration & Deployment

**Branch**: `phase-0b-azure-migration`  
**Version**: `v0.2.0`

- **LocalDB → Azure SQL Database migration**
    - Create Azure SQL Database instances (Identity + Music Store)
    - Export LocalDB schema and data
    - Handle Entity Framework Code First migrations
    - Update connection strings for Azure SQL
    - Configure Azure SQL firewall rules
- **OAuth provider setup** (currently packages installed but not configured)
- **Machine key configuration** for consistent cookie encryption
- **Azure App Service configuration**
    - Machine key configuration for consistent cookie encryption
    - Session state configuration for distributed environment
    - HTTPS enforcement setup
- **Secrets management**
    - Move any sensitive configuration to Azure App Service Configuration
    - Set up Azure Key Vault integration (optional for Phase 0)
- **Infrastructure as Code (Bicep) implementation**
    - Azure SQL Database provisioning
    - Azure App Service provisioning
    - Networking and security configuration
- **Deployment pipeline creation**
    - GitHub Actions workflow for Azure deployment
    - Automated deployment scripts
    - Environment-specific configuration management
- **Application Insights setup in Azure**
    - Configure Application Insights for Azure environment
    - Set up proper instrumentation keys
    - Configure telemetry collection

### Phase 0c: Azure Validation & Baselines

**Branch**: `phase-0c-azure-validation`  
**Version**: `v0.3.0`

- **Comprehensive Azure smoke testing**
    - All pages for all user types in Azure environment
    - ASP.NET Identity flows (registration, login, roles with local accounts)
    - Shopping cart functionality validation
    - Admin interface operations
    - Database connectivity and performance
- **Azure performance baseline capture**
    - Same metrics as Phase 0a but in Azure environment
    - Cold start performance measurement
    - Azure SQL vs LocalDB performance comparison
    - Network latency impact assessment
- **Load testing establishment**
    - Azure App Service capacity baselines
    - Concurrent user handling in Azure
    - Database connection pool behavior
    - Session state performance under load
- **Azure-specific validation**
    - Application Insights telemetry validation
    - Azure SQL connection resilience testing
    - Local account authentication performance in Azure
    - Failover scenario testing (database connectivity issues)
- **Environment comparison analysis**
    - Local vs Azure performance comparison
    - Identify Azure-specific optimizations needed
    - Document any Azure-specific behaviors or limitations
    - Establish production readiness criteria

**Azure Performance Baselines to Capture:**

- **All local metrics repeated in Azure context**
- **Cold start times** (Azure App Service specific)
- **Database connection establishment times** (Azure SQL vs LocalDB)
- **Local account authentication performance** in distributed environment
- **Session state operation performance** in distributed environment
- **Application Insights overhead measurement**
- **Resource consumption** in Azure App Service context

### Phase 1: Platform Migration

**Branch**: `phase-1-platform-migration`  
**Version**: `v1.0.0`

- .NET Framework 4.6.1 → .NET 9
- Entity Framework 6 → EF Core
    - **Code First migrations handling**
    - **Identity schema preservation**
    - **Data seeding strategy** (genres, sample albums, roles)
    - **Connection string modernization**
- **ASP.NET Identity → Core Identity migration** (local accounts only)
- **OWIN → Core middleware pipeline conversion**
- **Session state migration** (shopping cart functionality)
- Configuration system modernization (Web.config → appsettings.json)
- **Dependency injection implementation** (app currently has no DI container)
- Enhanced test coverage for migration validation
- Repeat baseline metrics and compare

### Phase 1.5: Modern Authentication Patterns

**Branch**: `phase-1.5-modern-auth`  
**Version**: `v1.1.0`

- **OAuth 2.0 / OpenID Connect implementation** using .NET 9 patterns
    - Google OAuth integration
    - Microsoft Account integration
    - Facebook OAuth integration
    - Twitter OAuth integration
- **External provider configuration** for Azure production environment
- **Claims-based authorization enhancement**
- **JWT token support** for API scenarios
- **Modern authentication UI/UX** patterns
- **Security best practices** implementation
- **Multi-factor authentication** considerations
- Comprehensive authentication testing
- Repeat baseline metrics and compare

### Phase 2: Observability & Performance

**Branch**: `phase-2-observability`  
**Version**: `v1.2.0`

- OpenTelemetry implementation
- Structured logging enhancement
- Performance monitoring and dashboards
- Health check endpoints expansion
- **E-commerce specific monitoring** (cart abandonment, conversion funnels)
- Repeat baseline metrics and compare

### Phase 3: Scalability Patterns

**Branch**: `phase-3-scalability`  
**Version**: `v1.3.0`

- Distributed caching (Redis)
- **Session state externalization** (critical for shopping cart)
- Database connection pooling
- Async/await pattern adoption
- **Shopping cart state management** optimization
- Load testing implementation
- Repeat baseline metrics and compare

### Phase 4: Advanced Authentication & Authorization

**Branch**: `phase-4-advanced-auth`  
**Version**: `v2.0.0` _(breaking change - advanced authentication model)_

- **Azure AD B2C integration** for enterprise scenarios
- **Role-based access control (RBAC)** enhancement
- **Policy-based authorization** implementation
- **API authentication patterns** (JWT, API keys)
- **Single sign-on (SSO)** capabilities
- **Advanced security features** (account lockout, suspicious activity detection)
- **Compliance and audit** authentication logging
- **External identity provider** federation beyond basic OAuth
- Repeat baseline metrics and compare

### Phase 5: Architecture Evolution

**Branch**: `phase-5-microservices`  
**Version**: `v2.1.0`

- Extract first microservice (user management)
- API Gateway patterns
- Service-to-service communication
- Event-driven architecture introduction
- Service mesh considerations
- **Payment processing** security considerations (if implemented)
- Repeat baseline metrics and compare

### Phase 6: Cloud Native Transformation

**Branch**: `phase-6-cloud-native`  
**Version**: `v3.0.0` _(breaking change - deployment model)_

- Containerization (Docker)
- Kubernetes deployment patterns
- Configuration management (Azure Key Vault)
- Secrets management modernization
- Cloud-native storage patterns
- **Image/asset migration** strategies (album artwork)
- Repeat baseline metrics and compare

### Phase 7: DevOps Excellence

**Branch**: `phase-7-devops-excellence`  
**Version**: `v3.1.0`

- Advanced GitHub Actions workflows
- Multi-environment promotion pipelines
- Automated quality gates
- Security scanning integration
- Compliance and audit automation
- **Frontend tooling modernization** assessment
- Repeat baseline metrics and compare

### Phase 8: Advanced Deployment Strategies

**Branch**: `phase-8-deployment-strategies`  
**Version**: `v3.2.0`

- Blue/Green deployment implementation
- Feature flags and toggles
- Canary release patterns
- Automated rollback procedures
- Chaos engineering introduction
- Repeat baseline metrics and compare

### Phase 9: Testing Excellence

**Branch**: `phase-9-testing-excellence`  
**Version**: `v3.3.0`

- Comprehensive unit testing strategy
- Integration testing patterns
- End-to-end testing automation
- Performance testing pipelines
- Contract testing for microservices
- **E-commerce workflow testing** (complete purchase flows)

### Phase 10: Production Excellence

**Branch**: `phase-10-production-excellence`  
**Version**: `v4.0.0` _(major - full production readiness)_

- Advanced monitoring and alerting
- Disaster recovery implementation
- Security hardening and compliance
- Cost optimization strategies
- Documentation and runbook completion
- **Frontend modernization completion** (Bootstrap 5+, modern JavaScript)
- **Legacy dependency cleanup** (Modernizr assessment, jQuery modernization)
- Repeat baseline metrics and compare

## Migration-Specific Considerations for MVC Music Store

### Authentication Migration Complexity

- ASP.NET Identity 2.2.2 with existing local accounts only
- OWIN cookie authentication pipeline (no external providers currently active)
- Role-based authorization (Admin/Visitor roles)
- Email-based authentication system
- OAuth packages installed but providers commented out

### Modern Authentication Implementation (Phase 1.5)

- .NET 9 OAuth 2.0 / OpenID Connect patterns
- External provider integration (Google, Microsoft, Facebook, Twitter)
- Modern security practices and patterns
- Claims-based authorization enhancement
- JWT support for API scenarios

### Entity Framework Migration Challenges

- EF 6.2.0 → EF Core with existing data
- ASP.NET Identity schema migration
- Music store schema (Albums, Artists, Genres)
- Code First migrations preservation
- LocalDB connection string modernization

### E-commerce Specific Requirements

- Shopping cart session state management
- User workflow preservation (browse → cart → checkout)
- Admin interface for catalog management
- Image handling for album artwork
- Search functionality performance

### Legacy Dependencies to Address

- jQuery 3.3.1 → Modern JavaScript patterns
- Bootstrap 3.4.1 → Bootstrap 5+
- Modernizr 2.8.3 → Assess continued necessity
- OWIN middleware → ASP.NET Core middleware
- Web.config → appsettings.json configuration