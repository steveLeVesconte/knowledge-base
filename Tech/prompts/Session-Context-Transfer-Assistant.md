# 🔄 Session Context Transfer Assistant

**Use this when:** You want to start a fresh session but need to carry forward relevant context efficiently.

source: https://claude.ai/chat/9e8c3fea-5e58-41cc-bc90-91d72debbbd2

---

## 📋 YOUR INPUT

**New session focus:** [Describe what you'll be working on - e.g., "Continue debugging the SSL redirect issue" or "Pivot to implementing the authentication flow"]

**Estimated scope:** [Quick/Single issue | Medium/Feature work | Extended/Multi-day project]

---

## 🎯 CONTEXT EXTRACTION REQUESTED

### 1. Essential Documents/Artifacts to Bring Forward

Review this conversation and identify:

**Critical code artifacts:**

- [File name]: [Why it's needed - e.g., "Current working implementation" vs "Reference pattern"]
- [File name]: [Why it's needed]

**Configuration/Environment info:**

- [What to document - e.g., "Project structure", "Key dependencies", "Environment constraints"]

**Decision history that matters:**

- [Key decision and why - e.g., "Rejected approach X because Y - prevents backtracking"]

**Format recommendation:** [Suggest: Single document, Multiple files, Artifact + bullet points, etc.]

### 2. Context Summary for New Session

Provide a **concise summary** (aim for <500 words) that captures:

**Current state:** [Where we are now - what works, what doesn't]

**Key constraints discovered:** [Critical limitations learned - e.g., "localStorage unavailable in Claude artifacts", "Must use .NET Framework 4.8, not Core"]

**Established patterns/standards:** [Coding patterns, architectural decisions that should continue]

**Known gotchas:** [Specific things that caused problems - e.g., "Chrome aggressively caches redirects - always test in incognito"]

**Open questions/next steps:** [What still needs to be resolved]

### 3. Danger List (What to Avoid Re-explaining)

**Topics/context that might seem missing but are actually handled:**

- [E.g., "Authentication is mocked in dev - this is intentional, don't suggest implementing real auth"]
- [E.g., "Error handling seems minimal - we're deferring this until core functionality works"]

**Dead ends explored:**

- [E.g., "Already tried: IIS Express property settings (doesn't exist in this version)"]
- [E.g., "Already tried: web.config rewrite rules (syntax was correct, not the issue)"]

### 4. Optimization: What Can Be Dropped

**Context from this session that's NOT needed for the new focus:**

- [Topics that were tangential]
- [Resolved issues that won't recur]
- [Exploratory work that led nowhere]

**Rationale:** [Why dropping this is safe]

---

## 📦 DELIVERABLE FORMAT

### Option A: Standalone Context Document (Recommended for Medium+ sessions)

```markdown
# Project Context for [New Session Focus]

## Current State
[Summary]

## Environment & Constraints
[Key technical constraints]

## Established Patterns
[What's working and should continue]

## Known Issues & Gotchas
[Things that caused problems]

## What NOT to Suggest
[Dead ends already explored]

## Next Steps
[Where to continue]

## Reference Artifacts
[List of code files with brief descriptions]
```

### Option B: Minimal Context Checklist (For quick pivots)

```markdown
Quick context for new session:

Working state: [1-2 sentences]
Key constraint: [The critical limitation discovered]
Don't suggest: [The dead end we already tried]
Next: [Immediate next action]

[Attach 1-2 critical artifacts if needed]
```

### Option C: Hybrid (Most Common)

- Core context document (Option A structure)
- Critical artifacts attached
- 3-5 bullet "quick reference" at top

---

## 🎯 SELECTION CRITERIA

**Choose Option A (Full Document) when:**

- Session had >30 exchanges
- Multiple false starts/dead ends explored
- Complex environment constraints discovered
- Will be working on this for multiple future sessions

**Choose Option B (Minimal) when:**

- Session had <15 exchanges
- Focused on single clear issue
- Quick debugging pivot
- Context is mostly "don't repeat this one mistake"

**Choose Option C (Hybrid) when:**

- Medium session length (15-30 exchanges)
- Some complexity but bounded scope
- Want quick reference + full details available