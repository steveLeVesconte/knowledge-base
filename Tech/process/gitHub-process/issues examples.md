## Your Specific Use Cases

### **Use Case 1: Discovery in Phase 1 for Phase 5**

**Example: During Phase 1 testing, you realize authentication will be complex in Phase 5**

bash

```bash
# Create the issue immediately
gh issue create \
  --title "Phase 5: OAuth provider configuration will need environment-specific settings" \
  --label "enhancement,phase-5,authentication,future-work" \
  --body "## Context from Phase 1

During Phase 1 identity testing, discovered that OAuth providers 
are commented out but configured in Web.config. 

When we implement Phase 5 OAuth, we'll need:
- Separate dev/staging/prod OAuth app registrations
- Environment-specific client IDs and secrets
- Redirect URL configuration for each environment

## Current Code Location
MvcMusicStore/Web.config lines 45-60 (commented out)

## Phase 5 Action Items
- [ ] Register OAuth apps for each environment
- [ ] Configure Azure Key Vault for secrets
- [ ] Update authentication middleware

## Links
- Related to Phase 1 work: #78
- Blocks Phase 5 authentication work"
```

**Benefits:** ✅ Won't forget this ✅ Context preserved with links back to Phase 1 ✅ Can refine details as you get closer ✅ Shows up in Phase 5 milestone queries

### **Use Case 2: Parking Lot Items**

**Example: "We should consider adding CQRS pattern" but uncertain when/if**

bash

```bash
gh issue create \
  --title "[IDEA] Consider CQRS pattern for read-heavy operations" \
  --label "idea,parking-lot,architecture,low-priority" \
  --body "## Idea
Shopping cart and catalog browsing are read-heavy. 
CQRS pattern might improve performance.

## Why Parking Lot
- Not critical for MVP
- Adds complexity
- Need to see performance baselines first

## Decision Point
Revisit after Phase 3 load testing results.
If catalog queries are bottleneck, promote to Phase 7.

## References
- Martin Fowler CQRS: [url]
- Related to Phase 7 optimization work"
```

### **Use Case 3: Technical Debt**

**Example: Found ugly code but fixing it now is out of scope**

bash

```bash
gh issue create \
  --title "Refactor ShoppingCart to use dependency injection" \
  --label "technical-debt,refactoring,phase-1b,future-work" \
  --body "## Current Problem
ShoppingCart.cs creates MusicStoreEntities directly (line 10).
This makes unit testing difficult.

## Impact
- Blocks pure unit testing of ShoppingCart
- Tight coupling to EF context

## Proposed Solution
Extract IShoppingCartRepository interface, inject DbContext.

## Why Not Now
- Phase 1b is integration testing (this doesn't block it)
- Want to establish test patterns first
- Will address during unit test expansion

## When to Fix
After Phase 1b integration tests complete, before Phase 4 migration.

## Related
- Discovered during: #12
- Blocks future unit testing efforts"
```

## Query Strategies for Future Issues

### **Find Phase 5 Work While in Phase 1:**

bash

```bash
# Via CLI
gh issue list --label "phase-5" --state open

# Via GitHub search
is:issue is:open label:phase-5

# All future discoveries made during Phase 1
is:issue label:future-work created:2024-10-01..2024-10-31
```

### **Review Parking Lot Items:**

bash

```bash
# Quarterly review
gh issue list --label "parking-lot" --state open

# Promote to active work
gh issue edit 67 --remove-label "parking-lot" --add-label "ready"
gh issue edit 67 --milestone "Phase-6"
```

### **Find Blocking Research Items:**

bash

```bash
# Before starting Phase 4
gh issue list --label "research,phase-4" --state open

# All spikes that need completion
gh issue list --label "spike" --state open
```

## Documentation Complement

Issues are great, but **also** maintain:

### **docs/future-work/discoveries.md**

markdown

```markdown
# Future Work Discovered During Migration

## Phase 1 Discoveries

### Authentication Complexity
**Issue:** #45
**Discovery:** OAuth providers exist but commented out
**Impact:** Phase 5 implementation will need careful planning
**Created:** 2024-10-15 during identity testing

### Connection Pool Behavior  
**Issue:** #52
**Discovery:** Azure SQL pooling differs from LocalDB
**Impact:** Phase 3 load testing strategy
**Created:** 2024-10-20 during integration tests
```

This gives you:

- ✅ Chronological narrative (issues don't)
- ✅ Quick reference during planning
- ✅ Context for retrospectives
- ✅ Portfolio documentation

## Issue Templates for Future Work

Create `.github/ISSUE_TEMPLATE/future-work.md`:

markdown

````markdown
---
name: Future Work Discovery
about: Document work discovered now but needed later
title: '[PHASE-X] Brief description'
labels: future-work
assignees: ''
---

## Discovery Context
**Discovered During:** Phase X, Issue #YYY
**Relevant For:** Phase Z
**Priority:** High/Medium/Low

## What We Learned
Brief description of what you discovered

## Why This Matters
Impact if we don't address this

## When to Address
Specific phase or milestone

## Acceptance Criteria (when we get there)
- [ ] Criterion 1
- [ ] Criterion 2

## Related Issues
- Discovered in: #YYY
- Blocks: #ZZZ (if known)

## References
- Code locations
- Documentation links
- Research materials
```

## The "Don't Lose It" System

Your complete system:
```
Immediate Discovery → Create Issue Immediately
         ↓
    Label appropriately
    (phase-X, future-work, priority)
         ↓
    Link to current work
    (discovered during #12)
         ↓
    Add to docs/future-work/discoveries.md
         ↓
    Set reminder for phase planning
    (GitHub milestone or calendar)
         ↓
    Query before starting phase
    (gh issue list --label "phase-5")
````

## Practical Workflow

### **During Phase 1:**

bash

```bash
# You discover something while working on #12

# 1. Create issue immediately (don't wait)
gh issue create \
  --title "Phase 5: OAuth redirect URIs need environment config" \
  --label "phase-5,authentication,future-work,priority-medium"

# 2. Add comment to current issue linking them
gh issue comment 12 --body "Discovered future work needed: #67"

# 3. Update your discovery log
echo "- #67: OAuth config needed (from #12)" >> docs/future-work/phase1-discoveries.md

# 4. Continue with current work
```

### **Before Starting Phase 5:**

bash

```bash
# Review all Phase 5 related issues
gh issue list --label "phase-5" --state open

# Review discoveries made in earlier phases
cat docs/future-work/phase1-discoveries.md
cat docs/future-work/phase2-discoveries.md

# Refine issue details now that you're ready to work on them
gh issue edit 67 --body "$(cat refined-description.md)"

# Move from future-work to active
gh issue edit 67 --remove-label "future-work" --add-label "ready"
gh issue edit 67 --milestone "Phase-5a"
```


https://claude.ai/chat/d0d2e15d-a986-495d-85a0-56d7a086cb74
"Use Case 1: Discovery in Phase 1 for Phase 5"





mutable!!!!!!!!!!!!!!!!!!!


## Acceptance Criteria
- [x] Test CreateOrder with single item
- [x] Test CreateOrder with multiple items
- [x] Test order total calculation
- ~~[ ] Test cart emptying after order~~ **REMOVED** - Cart emptying tested separately in ShoppingCartTests
- [x] Tests use DatabaseFixture
- [x] All tests pass

## Scope Changes
**2024-10-23:** Removed "cart emptying after order" test - discovered this is shopping cart responsibility, not checkout responsibility. Covered in issue #14 (ShoppingCartIntegrationTests) instead to avoid duplication.