I'm working on a .NET Framework to .NET 9 migration project outline. Please review the following sections for **terminology improvements**:

- Project Overview
- Phase 0: Planning
- Phase 1: Foundation & Local Baselines
- Phase 2: Azure Migration & Deployment
- Phase 3: Azure Validation & Baselines

**Focus areas for terminology review:**

1. **Migration methodology terms** - Are phrases like "migration story," "migration readiness checklist," "functional parity" the standard terms used in platform migration contexts?
2. **Azure deployment concepts** - Review terminology around App Service, SQL Database, Infrastructure as Code (Bicep), secrets management, deployment pipelines
3. **Testing & baseline terminology** - Are terms like "smoke testing," "performance baselines," "load testing baseline," "cold start performance" used correctly and precisely?
4. **Performance measurement terms** - Review phrases describing metrics, benchmarking, comparison analysis
5. **General software engineering terms** - Look for places where I might be using informal or imprecise terminology where industry-standard terms exist

**What I'm looking for:**

- Industry-standard terminology I should adopt
- More precise technical terms where I've been vague
- Corrections where I've misused terms
- Consistency improvements across these phases

**Context**: I'm a 40+ year developer (strong in MVC, SQL, C#) but learning modern .NET Core, Azure, and IaC patterns. Sometimes I'm guessing at the correct terminology.

Please highlight specific improvements with brief explanations of why the suggested term is more appropriate.



#Project Overview through Phase 3 are below:

---

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

**Important Risks**:
- Legacy project may have initial browser compatibility issues related to jQuery/Ajax functionality - test for this early in Phase 1
- Phase 4 will involve simultaneous breaking changes across multiple systems (EF, Identity, OWIN, project structure)

---

## Migration Phases
### Phase 0: Planning

**Branch Strategy**: phase-0-planning - one branch

- choose project for upgrade
- decide on Project Practices
	- investigate scope and tasks
	- make project-outline with ordered sequence of phases and tasks (this document)
	- branch strategy 
		- granularity
		- merge pattern
	- repository policy and settings
		- merge policy for main
	- repository documentation decisions:
		- initial README.md
		- CONTRIBUTING.md
		- use a PROJECT-LOG.md 
		
**Completion Criteria**:

- [ ] Initial project chosen
- [ ] project-outline (this document) complete, reviewed and committed 
- [ ] GitHub repository created, named, with policy decisions
- [ ] CONTRIBUTING.md - completed, reviewed and committed
- [ ] PROJECT-LOG.md with template for daily updates - completed, reviewed and committed
- [ ] Initial README.md with project vision completed
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
- Comprehensive smoke testing - all pages for all user types - be alert for browser incompatibility issues that may impact Ajax functionality
- Inventory tech stack - versions and dependencies
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
