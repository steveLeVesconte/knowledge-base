Issues:

Distributed Session State Duplication
AI Question:  The goal of phase 2 is to lift and shift with as few changes as possible.  Is it reasonable and workable to remove "Distributed session" from phase 2?  Would that be a reasonable choice for a Regional Bank (perhaps not for production at all)?  So "Use in-memory session state or note it as a temporary solution" is defensible?




Application Insights Timing Contradiction
So, the idea is to add Application Insights SDK in phase 1 to start getting metrics for later comparison.   I assume we must at least update the NuGet Package in phase 4 when we break everything to get to .NET 9.  Should we just introduce OpenTelemetry at that point?  Is that what would happen in a real small enterprise project?


Database Migration Timing
In phase 2, I think all that happens is the connection string changes to point to Azure SQL database instead of LocalDB.  Am I missing something?