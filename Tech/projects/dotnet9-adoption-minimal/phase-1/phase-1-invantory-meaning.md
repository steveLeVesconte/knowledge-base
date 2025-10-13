# Creating a Dependency Inventory: Educational Debrief

## The Big Picture: Why This Matters

A dependency inventory isn't just bureaucratic documentation—it's a **risk assessment disguised as a spreadsheet**. When migrating a legacy application, you're essentially performing surgery on a running system. The dependency inventory is your pre-operative scan that reveals:

- **What will break** (high-risk dependencies with no direct upgrade path)
- **What might break** (dependencies with behavioral changes)
- **What's trivial** (drop-in replacements)
- **What's missing** (gaps in your understanding)

For this MVC Music Store migration, the inventory immediately surfaced that you're dealing with a "breaking change trifecta": ASP.NET Identity, OWIN middleware, and Entity Framework 6 all need simultaneous replacement in Phase 4. Without the inventory, you'd discover this the hard way—mid-migration, with everything broken at once.

## The Method: Triangulating Truth from Multiple Sources

I used **three primary documents** to build a complete picture:

### 1. packages.config - The Declared Dependencies

This is your "source of truth" for what NuGet thinks is installed. However, it's naive—it doesn't tell you:

- Why each package exists
- Which packages are actually used vs. just installed
- Transitive dependencies (packages that pull in other packages)

**Key insight**: Note the external OAuth providers (Facebook, Google, etc.) are _declared_ but you need to check actual code usage.

### 2. MvcMusicStore.csproj - The Build Manifest

This reveals:

- Target framework version (net461 → net48 discrepancy shows framework retargeting happened)
- Direct assembly references (System.Web.*, etc.)
- Build tooling dependencies (Roslyn compilers)

**Critical detail**: The `<Reference>` elements for `System.Web.*` assemblies are the smoking gun. These don't exist in .NET Core/5+. Every one represents a namespace collision you'll face in Phase 4.

### 3. Web.config - Runtime Configuration

This shows:

- Assembly binding redirects (version conflicts the app has already encountered)
- Connection string providers (System.Data.SqlClient)
- Authentication mode (`<authentication mode="None" />` means OWIN handles it)

**Important pattern**: The binding redirects for Microsoft.Owin.* packages (all redirecting to 4.0.0.0) tell you the app has been upgraded from an older OWIN version. This suggests authentication code has already been touched—potential for undocumented behavior.

### 4. Startup.cs - Actual Usage Validation

Cross-referencing against code confirms what's _actually used_ vs. just installed:

- OWIN cookie authentication is active
- External OAuth providers are commented out (present but not loaded)
- Role creation happens at startup (Admin/Visitor roles)

## Important Details Worth Learning

### Detail 1: Version Number Archaeology

Look at this pattern in packages.config:

```
Microsoft.Owin 4.0.0
Microsoft.Owin.Security 4.0.0
Microsoft.Owin.Security.Cookies 4.0.0
```

All OWIN packages share the same version (4.0.0). This is **deliberate coordinated versioning**—these packages are designed to work as a cohesive unit. When you see this pattern, it means:

- They were likely all upgraded together
- Mixing versions will cause runtime errors
- In migration, they must all be replaced together (you can't incrementally migrate OWIN)

Contrast with:

```
jQuery 3.3.1
jQuery.Validation 1.17.0
```

Different major versions suggest these can evolve independently. jQuery.Validation doesn't need to match jQuery's version exactly.

### Detail 2: The "Missing" Test Framework

The packages.config shows MSTest packages, but the test project wasn't provided. I handled this with:

```
[Unknown - test project not provided]
```

**Why this matters**: In documentation, explicit uncertainty is better than implied certainty. The bracket notation signals "this is incomplete _on purpose_" rather than "I forgot to document this." During Phase 1a, someone reads this and knows exactly what to go find.

### Detail 3: Risk Stratification

The document categorizes dependencies by migration risk:

**High Risk**: ASP.NET Identity, OWIN, Entity Framework 6

- Why? No direct upgrade path—requires code rewrite
- These share data (Identity tables, authentication cookies)
- Breaking one breaks all three simultaneously

**Medium Risk**: Bootstrap, jQuery, Newtonsoft.Json

- Why? Upgrade paths exist but behavior changes
- Bootstrap 3→5 changes class names (UI breaks but doesn't crash)
- Newtonsoft.Json→System.Text.Json changes serialization behavior (subtle bugs)

**Low Risk**: MSTest, bundling tools

- Why? Drop-in replacements with similar APIs
- xUnit is conceptually identical to MSTest
- Modern bundlers are better in every way

This stratification guides your Phase 4 planning: tackle high-risk items together (they're coupled anyway), defer low-risk items if time-constrained.

### Detail 4: The "Gaps" Section Philosophy

The gaps aren't failures—they're **explicit uncertainty acknowledgment**:

```
1. Browser Compatibility: Verify jQuery 3.3.1 and AJAX functionality...
```

This transforms "I don't know" into "here's what testing must validate." It's the difference between:

- ❌ "Documentation is incomplete"
- ✅ "Documentation accurately reflects pre-testing state"

When you start Phase 1a smoke testing, you have a checklist of empirical questions to answer.

## The Hidden Value: Migration Decision Support

Notice how the inventory already influences architecture decisions:

**From the inventory**: "Session state: Current implementation uses in-memory session (single instance only)"

**Implications for Phase 2**: You can't scale horizontally in Azure without distributed session state (shopping cart will break). This means:

- Phase 2 must accept single-instance limitation initially
- Phase 7 distributed cache becomes critical, not optional
- Load testing in Phase 3 must document single-instance capacity

**From the inventory**: External OAuth packages present but commented out

**Implications for Phase 5**: The groundwork exists, suggesting OAuth was planned but never deployed. This means:

- Phase 5 work is "enabling dormant code" not "building from scratch"
- Configuration secrets likely exist somewhere (ask stakeholders)
- Test accounts may already be registered with providers

## Process Lessons

**Start with packages.config, validate with everything else**

- packages.config is exhaustive but not explanatory
- Web.config reveals runtime behavior
- Code confirms what's actually invoked

**Document risk, not just facts**

- "EntityFramework 6.2.0" is a fact
- "Replace with EF Core (migration script preservation critical)" is a risk assessment
- The latter helps Phase 4 planning; the former is just trivia

**Embrace explicit gaps**

- Unknown information is different from missing information
- Tag gaps with [NOTE: ...] so they become action items
- Don't guess—empirical questions need empirical answers

**Think in systems, not packages**

- ASP.NET Identity isn't one package—it's Identity.Core + Identity.EntityFramework + Identity.Owin
- These form a subsystem; document them as a unit
- Their coupling explains why Phase 4 is risky (change one, must change all)

## What You'd Have Learned Doing It Manually

You would have:

1. **Opened packages.config** and felt overwhelmed by 29 packages
2. **Googled "OWIN .NET Core equivalent"** and learned it doesn't exist (middleware replaces it)
3. **Cross-referenced Web.config** and discovered the authentication mode setting
4. **Checked Startup.cs** and realized OAuth is dormant
5. **Realized** the authentication subsystem is tightly coupled (Identity + OWIN + EF6)

The key insight you'd have earned: **legacy .NET apps aren't just old code—they're tightly coupled ecosystems where dependencies form mutual support networks**. You can't upgrade one piece without understanding the ripple effects.

---

**Bottom line**: A dependency inventory is detective work. You're not just listing packages—you're reconstructing the architectural decisions that created the current system, identifying coupling points, and predicting where the migration will hurt. The document I created does this by triangulating multiple sources, categorizing risk, and explicitly acknowledging uncertainty. That's the craft of migration planning.