
Migrate Framework 4.6 web app to .NET9


**Migration story to showcase:**

- .NET Framework MVC → .NET 9
- Entity Framework 6 → EF Core
- Windows Auth → Azure AD integration
- On-premises → Azure App Service
- IIS → containerized deployment
- Include performance comparisons, modernization decisions


## Evolution Phases (each as a tagged release/branch)

### Phase 0: Foundation & Safety

**Branch**: `phase-0-foundation`  
**Version**: `v0.1.0`

- Choose a legacy .NET Framework 4.x MVC application
- Test build
- Smoke test locally - all pages for all user types 
- Inventory tech stack - versions 
- Decide if we can support the configuration in Azure (ok to have SQL?)
- Repeatable deployment (PowerShell scripts)
- Basic unit tests for core business logic
- Minimal logging and health checks
- GitHub Actions workflow wrapping existing scripts
- Infrastructure as Code (Bicep) for Azure resources
- Smoke tests and deployment validation

**Branch**: `phase-0a-observability-and-metrics`  
**Version**: `v0.2.0`

**Performance baselines you should capture:**

- **Page load times** (home, catalog, product detail, checkout flow)
- **Database query performance** (especially complex joins, searches)
- **Memory usage patterns** (particularly important for Framework apps)
- **Application startup time**
- **Resource consumption** (CPU, memory, I/O during typical usage)

**Business metrics baselines:**

- **Error rates** by page/function
- **User workflow completion rates** (browse → add to cart → checkout)
- **Database deadlocks/timeouts**
- **Peak concurrent user handling**

### Phase 1: Platform Migration

**Branch**: `phase-1-platform-migration`  
**Version**: `v1.0.0`

- .NET Framework 4.6 → .NET 9
- Entity Framework 6 → EF Core
- Configuration system modernization
- Dependency injection implementation
- Enhanced test coverage for migration validation
- repeat baseline metrics and compare

### Phase 2: Observability & Performance

**Branch**: `phase-2-observability`  
**Version**: `v1.1.0`


- OpenTelemetry implementation
- Structured logging enhancement
- Performance monitoring and dashboards
- Health check endpoints expansion
- repeat baseline metrics and compare

### Phase 3: Scalability Patterns

**Branch**: `phase-3-scalability`  
**Version**: `v1.2.0`

- Distributed caching (Redis)
- Session state externalization
- Database connection pooling
- Async/await pattern adoption
- Load testing implementation
- repeat baseline metrics and compare

### Phase 4: Authentication Modernization

**Branch**: `phase-4-auth-modernization`  
**Version**: `v2.0.0` _(breaking change - authentication model)_

- Windows Auth → Azure AD integration
- JWT token handling
- Claims-based authorization
- API security patterns
- OAuth/OpenID Connect implementation
- repeat baseline metrics and compare

### Phase 5: Architecture Evolution

**Branch**: `phase-5-microservices`  
**Version**: `v2.1.0`

- Extract first microservice (user management)
- API Gateway patterns
- Service-to-service communication
- Event-driven architecture introduction
- Service mesh considerations
- repeat baseline metrics and compare

### Phase 6: Cloud Native Transformation

**Branch**: `phase-6-cloud-native`  
**Version**: `v3.0.0` _(breaking change - deployment model)_

- Containerization (Docker)
- Kubernetes deployment patterns
- Configuration management (Azure Key Vault)
- Secrets management modernization
- Cloud-native storage patterns
- repeat baseline metrics and compare

### Phase 7: DevOps Excellence

**Branch**: `phase-7-devops-excellence`  
**Version**: `v3.1.0`

- Advanced GitHub Actions workflows
- Multi-environment promotion pipelines
- Automated quality gates
- Security scanning integration
- Compliance and audit automation
- repeat baseline metrics and compare

### Phase 8: Advanced Deployment Strategies

**Branch**: `phase-8-deployment-strategies`  
**Version**: `v3.2.0`

- Blue/Green deployment implementation
- Feature flags and toggles
- Canary release patterns
- Automated rollback procedures
- Chaos engineering introduction
- repeat baseline metrics and compare

### Phase 9: Testing Excellence

**Branch**: `phase-9-testing-excellence`  
**Version**: `v3.3.0`

- Comprehensive unit testing strategy
- Integration testing patterns
- End-to-end testing automation
- Performance testing pipelines
- Contract testing for microservices

### Phase 10: Production Excellence

**Branch**: `phase-10-production-excellence`  
**Version**: `v4.0.0` _(major - full production readiness)_

- Advanced monitoring and alerting
- Disaster recovery implementation
- Security hardening and compliance
- Cost optimization strategies
- Documentation and runbook completion
- repeat baseline metrics and compare

