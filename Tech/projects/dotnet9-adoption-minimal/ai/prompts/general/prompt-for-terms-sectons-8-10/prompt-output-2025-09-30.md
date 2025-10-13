## Phase 8: API-First Architecture & Integration Patterns

**Branch Strategy**: `phase-8-api-modernization` with sub-branches:

- `phase-8a-api-extraction` - Web API project creation
- `phase-8b-api-management` - Azure API Management integration
- `phase-8c-async-messaging` - Azure Service Bus for background processing

**Version**: `v6.0.0` _(major feature - API layer introduction)_

**AZ-204 Skills**: Web API development, Azure API Management, Azure Service Bus, background workers

**Completion Criteria**:

- [ ]  RESTful API operational alongside MVC application
- [ ]  API Management policies configured (rate limiting, caching)
- [ ]  Asynchronous order processing with Service Bus
- [ ]  API versioning strategy implemented
- [ ]  Distributed tracing across API and MVC components

**Regional Bank Context**:

Separate the data access layer into a dedicated API to enable future mobile app development, third-party integrations (payment gateways), and internal admin tools as separate clients. This is the natural first step in architectural evolution - providing an API layer without the complexity of full microservices decomposition.

**Tasks**:

- **Web API project creation** ✅ CORE
    - ASP.NET Core Web API project (separate from MVC)
    - RESTful endpoint design (albums, artists, genres, orders)
    - OpenAPI/Swagger documentation generation
    - API versioning (URL-based: `/api/v1/albums`)
    - Shared data access layer between MVC and API projects
    - DTOs (Data Transfer Objects) for API responses
- **Azure API Management integration** ✅ CORE
    - APIM instance provisioning (Consumption or Basic tier)
    - API import and registration via OpenAPI specification
    - Rate limiting policies (protect against abuse)
    - Response caching policies (reduce database load)
    - Request/response logging for audit trails
    - **[OPTIONAL]** Request/response transformation policies
    - **[OPTIONAL]** IP filtering and geographic restrictions
- **API authentication and authorization** ✅ CORE
    - JWT bearer token authentication
    - OAuth 2.0 client credentials flow (service-to-service)
    - Claims-based authorization (role validation)
    - **[OPTIONAL]** API subscription key management (for external partners)
- **Asynchronous messaging with Azure Service Bus** ✅ CORE
    - Service Bus namespace and queue provisioning
    - Order processing queue (decouple checkout from order fulfillment)
    - Message publishing from MVC checkout workflow
    - Background worker service (hosted service) for queue processing
    - Dead letter queue monitoring and handling
    - Message retry policies with exponential backoff
- **API client implementation in MVC** ✅ CORE
    - Typed HttpClient factory pattern
    - Circuit breaker pattern (Polly) for API call resilience
    - Timeout policies for API requests
    - Response caching in MVC layer (reduce API calls)
- **Cross-cutting concerns** ✅ CORE
    - Correlation ID propagation (MVC → API → Service Bus → Worker)
    - Distributed tracing with OpenTelemetry (spans across components)
    - Structured logging with context (user ID, order ID, correlation ID)
    - Error handling with Problem Details (RFC 7807) in API
- **Database access patterns** ✅ CORE
    - API and MVC share same database (no data duplication yet)
    - Connection string management via Azure Key Vault
    - Connection pooling configuration for multiple clients
    - **[OPTIONAL]** Read replicas for scaling read operations

**API Performance Metrics Captured**:

- API endpoint response times (p50, p95, p99) ✅
- APIM policy overhead measurement ✅
- Service Bus message processing latency ✅
- Background worker throughput (messages/second) ✅
- Circuit breaker state transitions (API resilience) ✅
- End-to-end order processing time (MVC → API → Queue → Worker) ✅
- **[OPTIONAL]** API cache hit ratios by endpoint

**New Architecture Patterns Demonstrated**:

- API Gateway pattern (centralized entry point)
- Asynchronous request-reply pattern (Service Bus)
- Retry and circuit breaker patterns (transient fault handling)
- Correlation and distributed tracing (observability)

---

## Phase 9: Cloud Native Transformation (Azure Container Apps)

**Branch Strategy**: `phase-9-container-apps` with sub-branches:

- `phase-9a-containerization` - Dockerfile creation and image optimization
- `phase-9b-container-registry` - Azure Container Registry setup
- `phase-9c-container-apps-deployment` - Container Apps environment and deployment
- `phase-9d-configuration-secrets` - Externalized configuration and secrets management

**Version**: `v7.0.0` _(breaking change - deployment model)_

**AZ-204 Skills**: Docker containerization, Azure Container Registry, Azure Container Apps, managed identities

**Completion Criteria**:

- [ ]  All applications containerized and running in Azure Container Apps
- [ ]  Zero-downtime deployments with revision management
- [ ]  Auto-scaling configured based on HTTP traffic and queue length
- [ ]  Secrets externalized to Azure Key Vault with managed identity access
- [ ]  Performance comparison documented (App Service vs Container Apps)

**Regional Bank Context**:

Move from traditional App Service deployment to containerized deployment for environment consistency (dev/staging/prod parity), faster deployment cycles, better resource utilization, and foundation for modern cloud-native patterns. Container Apps provides managed container orchestration without Kubernetes complexity.

**Tasks**:

- **Container image creation** ✅ CORE
    - Multi-stage Dockerfile for .NET 9 MVC application
    - Multi-stage Dockerfile for .NET 9 Web API application
    - Multi-stage Dockerfile for Service Bus worker (background service)
    - Base image selection (`mcr.microsoft.com/dotnet/aspnet:9.0`)
    - Image size optimization (layer caching, minimize layers)
    - `.dockerignore` configuration (exclude build artifacts, source control)
    - Non-root user configuration for container security
- **Azure Container Registry (ACR)** ✅ CORE
    - Private container registry provisioning (Basic or Standard tier)
    - ACR authentication configuration
    - Image vulnerability scanning (Microsoft Defender for Containers)
    - Image retention policies (auto-purge old images)
    - **[OPTIONAL]** Geo-replication for disaster recovery
    - **[OPTIONAL]** Content trust for image signing
- **Azure Container Apps environment** ✅ CORE
    - Container Apps environment provisioning (shared infrastructure for apps)
    - Virtual network integration for environment
    - Log Analytics workspace association
    - Managed identity creation for container apps
- **Container Apps deployment** ✅ CORE
    - MVC application as Container App (public ingress)
    - Web API application as Container App (internal ingress only)
    - Service Bus worker as Container App (no ingress)
    - Revision management for zero-downtime updates
    - Traffic splitting between revisions for validation **[OPTIONAL]**
    - Container resource allocation (CPU, memory requests/limits)
- **Auto-scaling configuration** ✅ CORE
    - HTTP scaling rules for MVC and API (concurrent requests threshold)
    - Azure Service Bus queue scaling rules for worker (queue length threshold)
    - Min/max replica configuration (scale-to-zero for worker)
    - Scaling cool-down periods
- **Externalized configuration** ✅ CORE
    - Environment variables for non-sensitive application settings
    - Azure Key Vault for connection strings and secrets
    - Managed identity for Key Vault access (no credentials in code)
    - Container Apps secrets for sensitive configuration
    - Configuration override per environment (dev, staging, production)
- **Networking and ingress** ✅ CORE
    - HTTPS ingress for MVC application (public)
    - Internal ingress for Web API (accessible only within environment)
    - Custom domain configuration for production **[OPTIONAL]**
    - CORS policy configuration for API endpoints
    - **[OPTIONAL]** IP restrictions for admin endpoints
- **Persistent storage strategy** ✅ CORE
    - Azure Blob Storage for album artwork (existing pattern)
    - Managed identity for Blob Storage access
    - Stateless container design (no local file storage dependencies)
- **Container Apps observability** ✅ CORE
    - Container Apps logs aggregation in Log Analytics
    - Application Insights SDK in all containers
    - Distributed tracing across containers (correlation ID propagation)
    - Container resource utilization monitoring (CPU, memory)
    - Revision health monitoring
    - Cold start time measurement (scale-from-zero scenarios)
- **Dapr integration** 🔶 OPTIONAL (Advanced feature)
    - Dapr sidecar enablement for Service Bus pub/sub
    - Dapr state management for distributed session **[ALTERNATIVE to Redis]**
    - Service-to-service invocation via Dapr (API discovery)
    - **Note**: Dapr is powerful but adds complexity; Redis + HttpClient patterns work well without it

**Container Apps Performance Metrics**:

- Cold start latency (scale-from-zero time) ✅
- Warm instance response times vs App Service baseline ✅
- Scaling time (replica spawn duration under load) ✅
- Memory footprint per container instance ✅
- Container startup time (application initialization) ✅
- Auto-scaling effectiveness (replicas vs load correlation) ✅
- Revision rollout time (zero-downtime deployment validation) ✅

**Performance Comparison Analysis**:

- App Service vs Container Apps response times ✅
- Cost comparison under typical traffic patterns ✅
- Scaling characteristics (speed, granularity) ✅
- Resource efficiency (memory/CPU utilization per request) ✅

**Container Security Hardening**:

- Container image vulnerability scanning results ✅
- Non-root container execution validation ✅
- Managed identity usage (no credentials in containers) ✅
- Secret access audit logs ✅
- **[OPTIONAL]** Network policies for container-to-container communication

---

## Phase 10: DevOps Excellence & Production Readiness

**Branch Strategy**: `phase-10-devops` with sub-branches:

- `phase-10a-advanced-pipelines` - Multi-environment CI/CD pipelines
- `phase-10b-quality-gates` - Automated quality and security gates
- `phase-10c-deployment-strategies` - Advanced deployment patterns
- `phase-10d-compliance-automation` - Audit and compliance automation

**Version**: `v7.1.0`

**AZ-204 Skills**: GitHub Actions, Azure DevOps, Security scanning, Compliance automation

**Completion Criteria**:

- [ ]  Multi-stage CI/CD pipeline operational (build → dev → staging → production)
- [ ]  Automated quality gates enforced (tests, coverage, security scans)
- [ ]  Zero-downtime deployment strategy validated
- [ ]  Security scanning integrated with policy enforcement
- [ ]  Audit trail automation operational
- [ ]  DORA metrics captured and analyzed

**Regional Bank Context**:

Banks require rigorous deployment governance, audit trails, separation of duties, and automated compliance checks. This phase implements enterprise-grade DevOps practices including security scanning (mandatory for financial services), deployment approvals, rollback procedures, and comprehensive audit logging.

**Tasks**:

- **Multi-stage CI/CD pipeline implementation** ✅ CORE
    - Build stage (compile, unit tests, package)
    - Container image build and push to ACR
    - Infrastructure as Code (Bicep) validation and deployment
    - Multi-environment deployment (dev → staging → production)
    - Reusable workflow components (DRY principle)
    - Artifact versioning and retention policies
- **Progressive delivery with environment promotion** ✅ CORE
    - Environment-specific configuration management (appsettings per environment)
    - Manual approval gates for production deployments (separation of duties)
    - Environment protection rules (GitHub environments)
    - Deployment notifications (Slack, Teams, email)
    - **[OPTIONAL]** Deployment ring strategy (internal users → beta → production)
- **Automated quality gates** ✅ CORE
    - Unit test execution with pass/fail criteria
    - Code coverage threshold enforcement (e.g., 80% minimum)
    - Integration test execution (database, API, authentication flows)
    - Performance regression detection (compare to baselines)
    - Code quality analysis (code complexity, maintainability index) **[OPTIONAL]**
- **Security scanning integration (Shift-Left Security)** ✅ CORE
    - Static Application Security Testing (SAST) - code vulnerability analysis
    - Software Composition Analysis (SCA) - dependency vulnerability scanning
    - Container image vulnerability scanning (Trivy, Microsoft Defender)
    - Secret scanning (GitHub Advanced Security or GitGuardian)
    - Security scan results as quality gate (block on high/critical vulnerabilities)
    - **[OPTIONAL]** Dynamic Application Security Testing (DAST) - runtime vulnerability scanning
- **Infrastructure as Code (IaC) validation** ✅ CORE
    - Bicep template linting (syntax and best practices)
    - Azure Policy compliance checks (resource naming, tagging, allowed regions)
    - Bicep what-if analysis before deployment (change preview)
    - Infrastructure drift detection **[OPTIONAL]**
- **Compliance as code and audit automation** ✅ CORE
    - Azure Policy enforcement for resource compliance
    - Automated compliance reporting (CIS benchmarks, PCI-DSS controls) **[OPTIONAL]**
    - Deployment audit log aggregation (who deployed what, when)
    - Change request documentation automation
    - Audit log retention policies (7 years for financial services)
- **Deployment strategies** ✅ CORE
    - Container Apps revision-based deployment (zero-downtime by default)
    - Traffic splitting for validation (e.g., 10% new revision, 90% stable) **[OPTIONAL]**
    - Automated rollback on health check failure
    - Rollback procedures documented and tested
    - **[OPTIONAL]** Feature flags for progressive feature rollout (LaunchDarkly, Azure App Configuration)
- **Pipeline observability and metrics** ✅ CORE
    - Deployment frequency (DORA metric)
    - Lead time for changes (commit to production)
    - Mean time to recovery (MTTR) from failures
    - Change failure rate (deployments causing incidents)
    - Pipeline execution time trends
    - Deployment success/failure rates
- **Rollback and disaster recovery procedures** ✅ CORE
    - Documented rollback procedures (Container Apps revision revert)
    - Database rollback strategy (migration scripts, backups)
    - Rollback testing (validate rollback works before production deployment)
    - Disaster recovery runbook (restore from backup, re-deploy infrastructure)
    - Recovery Time Objective (RTO) and Recovery Point Objective (RPO) documentation

**DevOps Performance Metrics**:

- Pipeline execution time (build to production) ✅
- Deployment frequency (deployments per week) ✅
- Lead time for changes (commit to production duration) ✅
- Change failure rate (percentage of deployments causing issues) ✅
- Mean time to recovery (MTTR from deployment failures) ✅
- Security scan duration and issue detection rate ✅
- Test execution time and coverage percentage ✅

**Compliance and Audit Capabilities**:

- Immutable audit trail (who approved, who deployed, when) ✅
- Deployment approval workflow enforcement ✅
- Security scan results archival ✅
- Infrastructure change tracking ✅
- Access control validation (separation of duties) ✅

**Regional Bank Deployment Governance**:

- Change Advisory Board (CAB) approval simulation (manual approval gates) ✅
- Deployment windows enforcement (e.g., no Friday deployments) **[OPTIONAL]**
- Emergency hotfix procedures (expedited approval path) **[OPTIONAL]**
- Production access logging and monitoring ✅

**Pipeline Security Hardening**:

- GitHub Actions OIDC authentication (no long-lived credentials) ✅
- Azure service principal with least-privilege permissions ✅
- Pipeline secret management (GitHub Secrets, Azure Key Vault) ✅
- Pipeline audit logging ✅
- **[OPTIONAL]** Pipeline artifact signing and verification

---

## Success Metrics (Updated)

### **Phase-Specific Measurable Outcomes**

|Phase|Performance Metrics|Quality Metrics|
|---|---|---|
|**Phase 1**|Local baseline times|Test coverage %|
|**Phase 3**|Azure vs local comparison|Uptime %|
|**Phase 4**|.NET 9 performance gains|Migration success %|
|**Phase 5**|OAuth response times|Security scan results|
|**Phase 6**|Monitoring coverage|MTTR improvements|
|**Phase 7**|Cache hit ratios|Scalability metrics|
|**Phase 8**|API/Service Bus latency|Distributed tracing coverage|
|**Phase 9**|Container Apps performance|Container security score|
|**Phase 10**|DORA metrics (deployment frequency, lead time)|Security gate pass rate|

### **Overall Project Success Criteria**

- [ ]  Complete functional parity maintained throughout all phases
- [ ]  Measurable performance improvements documented (local → Azure → Container Apps)
- [ ]  Zero data loss during all migrations (database, identity, session state)
- [ ]  All security scans passed with no high/critical vulnerabilities
- [ ]  Comprehensive migration playbook produced for others to follow
- [ ]  AZ-204 exam skills demonstrated and documented across all phases



