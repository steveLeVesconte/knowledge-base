
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

---

## Legend

- **✅ CORE** - Essential for learning objectives and portfolio demonstration
- **🔶 OPTIONAL** - Valuable for production but not required for learning/portfolio
- **[DELAYABLE to Phase X]** - Better suited for a later phase (e.g., Kubernetes features in Phase 9)
- **[OPTIONAL]** - Can skip if time-constrained; evaluate value vs. effort

## Decision Framework

**When deciding whether to implement OPTIONAL items:**

1. **Time constraint**: If behind schedule, skip all OPTIONAL items
2. **Learning goals**: If a pattern teaches AZ-204 concepts, prioritize it
3. **Portfolio value**: If it demonstrates production-readiness thinking, consider it
4. **Dependencies**: If Phase 8/9/10 needs it, do it; otherwise defer
5. **Complexity**: If adding an OPTIONAL item doubles implementation time, skip it

**Recommended minimum path** (for time-constrained scenario):

- Skip all items marked OPTIONAL
- Implement all CORE items
- Revisit OPTIONAL items in a "Phase 6.5" / "Phase 7.5" if productionizing later