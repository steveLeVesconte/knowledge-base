
# Context Preprocessing: Project Outline → README Context

## Source Document
- File: project-outline.md
- Size: 41,000 characters
- Content: Detailed migration project plan with 10 phases

## Preprocessing Goal
Extract README-relevant information to use as context for README generation prompt.

## Extraction Criteria

### HIGH PRIORITY (Must Include)
**Project Overview:**
- What: .NET Framework X.X → .NET 9 migration
- Why: Learning goals + portfolio showcase
- Who: Target audience (employers, learners, contributors)

**Technical Stack:**
- Current: Framework versions, technologies
- Target: .NET 9, Azure services used
- Key dependencies: Major packages, tools

**Project Structure:**
- Phase progression (names only, not details)
- Major milestones
- Deliverables overview

**Value Proposition:**
- What makes this project notable?
- Learning objectives addressed
- Portfolio value

### MEDIUM PRIORITY (Include if Space Permits)
- High-level phase descriptions (1-2 sentences each)
- Key architectural decisions (Azure App Service vs Container Apps, etc.)
- Success metrics or outcomes

### LOW PRIORITY (Exclude)
- Detailed task breakdowns per phase
- Branch strategy specifics
- Completion criteria checklists
- Internal notes or decisions
- AZ-204 certification mapping details

## Output Requirements

**Format:**
```

# README Context Summary

## Project Overview

[2-3 paragraph narrative]

## Technical Stack

**Current State:**

- [key technologies]

**Target State:**

- [target technologies]

## Migration Phases

1. Phase 0: [Name] - [one sentence]
2. Phase 1: [Name] - [one sentence] [etc.]

## Key Features

- [notable aspect 1]
- [notable aspect 2]

## Value Proposition

[Why this project matters - 1 paragraph]

```

**Target length:** 4,000-6,000 characters
**Tone:** Professional but accessible
**Perspective:** External audience (not internal team)

## Success Criteria
- Someone unfamiliar with the project can understand its purpose
- Technical stack is clear
- Project scope is evident
- No implementation minutiae
- Ready to use as context for README generation

