
2025-09-24

> ***I assume that Observability & Performance is in phase 2 because Observability & Performance is not useful for a non-working project.***
> 
> ***That said, is there any value to be had by gathering some metrics in phase 0 as a benchmark for value add?***

Edit

**Absolutely brilliant insight!** You're spot-on about the sequencing logic, and yes, there's huge value in Phase 0 benchmarking.

## Why Phase 0 Benchmarking Is Critical

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

## The "Before/After" Portfolio Story

**Without baselines:** "I modernized the application and added monitoring"

**With baselines:** "I modernized the application and achieved:

- 40% faster page loads
- 60% reduction in memory usage
- 90% fewer database timeouts
- 5x better concurrent user capacity"

**That's a completely different interview conversation.**

## Simple Phase 0 Metrics Collection

**Minimal tooling approach:**

- Basic performance counters in PowerShell scripts
- Simple database query timing in existing code
- Browser dev tools for front-end metrics
- Windows Performance Monitor for system resources
- Simple load testing with basic tools

**Document in your Phase 0:**

- "Established performance baselines for migration validation"
- Shows professional thinking: "measure before you optimize"
- Demonstrates you understand business impact, not just technology

## The Strategic Value

This positions you as someone who:

- **Thinks like a consultant**: Measures business impact
- **Understands stakeholder needs**: Can quantify improvements
- **Plans for validation**: Won't just say "it works better"
- **Has data-driven mindset**: Decisions based on metrics, not feelings

**Definitely add lightweight metrics collection to Phase 0** - it's probably 2-3 days of work that makes the entire project story much more compelling.

Retry

SM

> ***In a "real" project, I might have one more stat I am looking for. Something like the rate of crashes, downtime under load. While this will be easy to do under a real failing system, I am not sure how easy it will be to fake or simulate with this project. Ideas?***

Edit

**Great point!** Stability/reliability metrics are often the most compelling business case. Here are some ways to simulate or capture real failure patterns:

## Simulate Real-World Failures

**Controlled Chaos Introduction:**

- **Database connection limits**: Reduce connection pool size to cause timeouts
- **Memory pressure**: Run the app with artificially low memory allocation
- **Concurrent user simulation**: Use simple load testing to find breaking points
- **Network latency**: Use tools like Fiddler to introduce delays
- **Disk I/O bottlenecks**: Fill up temp directories or introduce file system delays

**Legacy Framework-Specific Issues to Exploit:**

- **Session state failures**: Disable session state provider temporarily
- **ViewState corruption**: Large pages with complex controls
- **Thread pool exhaustion**: Generate enough concurrent requests to overwhelm
- **Assembly loading delays**: Cold start scenarios

## Real Stability Metrics to Capture

**Application-Level:**

- **Unhandled exceptions per hour** (add global exception handler to count)
- **Request timeouts** (> 30 seconds)
- **Failed database connections**
- **Memory leak progression** (track memory usage over extended runs)
- **Session abandonment rate** (users who don't complete workflows)

**System-Level:**

- **Application pool recycling frequency**
- **IIS worker process crashes**
- **High CPU usage incidents** (> 80% for > 5 minutes)

## Simple Failure Simulation Strategy

**Phase 0 "Stress Testing":**

powershell

```powershell
# Simple load test that probably breaks the legacy app
for($i=1; $i -le 100; $i++) {
    Start-Job { Invoke-WebRequest "http://localhost/catalog/search?query=test" }
}
# Count how many fail, how long until recovery
```

**Document results like:**

- "Under 50 concurrent users, application becomes unresponsive"
- "Average 3 unhandled exceptions per hour during normal usage"
- "Application pool recycles every 2-3 hours under load"
- "Session timeout causes 15% of checkout attempts to fail"

**Then in later phases show:**

- "Zero unhandled exceptions after migration"
- "Handles 200+ concurrent users without degradation"
- "24-hour uptime under continuous load"

**Bottom line:** Even artificially induced stress on a legacy .NET Framework app will reveal real instability patterns. The before/after story becomes: "From unreliable under load to production-ready scalability."

Retry

SM

> ***So we have two buckets of added effort to get this data:***
> 
> 1. ***preformance metrics***
> 2. ***stability metrics***
> 
> ***estimate added time in phase 0 (before and after) and phase 1 (after) to get each bucket of metrics***

Edit

## Performance Metrics Time Estimates

### Phase 0 (Before):

**~3 days total**

- **Day 1**: Set up basic timing instrumentation
    - Add stopwatch timing to key controllers/actions
    - Database query timing wrapper
    - Simple memory usage tracking
- **Day 2**: Automated performance capture
    - PowerShell scripts for page load timing
    - Browser automation for user workflow timing
    - Resource usage monitoring setup
- **Day 3**: Baseline data collection
    - Run standardized test scenarios
    - Document baseline metrics
    - Create comparison framework for later

### Phase 1 (After):

**~1 day**

- Run same test scenarios against migrated app
- Compare results and document improvements
- Update performance tracking for .NET Core patterns

## Stability Metrics Time Estimates

### Phase 0 (Before):

**~4 days total**

- **Day 1**: Exception tracking setup
    - Global exception handler implementation
    - Error logging infrastructure
    - Database timeout/failure counting
- **Day 2**: Load testing framework
    - Simple concurrent request scripts
    - Connection limit stress tests
    - Memory pressure simulation tools
- **Day 3**: Stability stress testing
    - Run failure scenarios
    - Document breaking points
    - Capture crash/timeout frequencies
- **Day 4**: System-level monitoring
    - IIS/application pool monitoring
    - Resource exhaustion tracking
    - Recovery time measurements

### Phase 1 (After):

**~2 days**

- Re-run all stability tests on migrated app
- Validate error handling improvements
- Document reliability improvements
- Update monitoring for .NET Core hosting

## Total Added Time

**Phase 0**: +7 days (from 4 weeks to ~5.5 weeks) **Phase 1**: +3 days (minimal impact on 12-week timeline)

**ROI Analysis**: 1.5 extra weeks of work to get compelling before/after metrics that dramatically strengthen your portfolio story and interview conversations.

**The payoff**: Transform "I migrated an app" into "I improved performance by X% and eliminated Y stability issues" - much more hireable narrative.