I'm working on a .NET Framework 4.6.1 to .NET 9 migration project (MVC Music Store). 

Context documents:
- project-outline.md (10-phase migration plan)
- base-project-context.md (current app details)
- Startup.cs
- Startup.Auth.cs
- Web.config
- packages.config
- HomeControllerTest.cs (from testing project)
- MvcMusicStore.Tests.csproj (from testing project)

We've completed the planning phase. Ready to discuss:
1. Test coverage strategy for Phase 0a

Current app state: Local authentication only, no OAuth currently active.

Please suggest test coverage and testing tools.  Note, there are currently only 3 tests, so if there is a compelling reason to change testing tools, this would be a good time to do it.  Balance these three goals:

- The purpose of the tests is to ensure we are not braking stuff as we migrate to .NET9
- professional coverage - as if this were an enterprise project
- tempered by the need to "get it done" - so, I can't spend too many days writing tests

I think this should be a list.  not fully coded tests, but be specific enough that I can  code to the list.

