Context: 40yrs+ Software Dev (MVC, SQL, C#, JS/HTML/CSS),
- learning (.NET Core and Azure and IaC)

I made these changes to project-outline-v3.md and am satisfied with them:
-  Change 1: Added notation about the fact that browser incompatibility may already be an issue before the upgrade starts and should be tested for
- Change 2: Amended smoke test to include mention of browser incompatibility issues.
-  Change 3: Unit test tool switch to xUnit - since there are currently no significant tests, switching to xUnit early is not much of a complication
- Change 4:  added "Attempt to add unit tests that my be useful in phase 4 when the many things will be broken at once."  I am uncertain if this will work, but I want to see if I can add test that have a chance of helping when many things are broken at once in phase 4.
- Change 5: added "- investigate adding JavaScript Unit Test that my be useful if the client side code is broken in phase 4 ".  Again, I am unsure if this will work, but I want to investigate whether adding some JavaScript unit tests will help with debugging in later phases like phase 4.
- Change 6: I moved Application Insights to after Unit Testing on the general principle that Unit Testing is the first thing to improve before other enhancements.
- Change 7:  Added " phase-4e-ui-compatibility - **Focus on functional parity** - make everything work the same " because the plan had not included any mention of the ui elements likely to break.

Three sequential tasks for AI:
1. Identify any contradictions these changes create in the document
2. Rewrite sections for consistency (provide updated sections only)
3. Assess if the revised plan appears workable

Priority documents:
- project-outline-v3.md (my current plan)
- base-project-context.md (app details)
- Startup.Auth.cs (shows OAuth is commented out)