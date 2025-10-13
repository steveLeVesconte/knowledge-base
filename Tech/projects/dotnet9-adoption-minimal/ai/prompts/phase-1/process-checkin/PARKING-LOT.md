# Parking Lot - Ideas for Later

> Items discovered during work that need attention but not RIGHT NOW.
> Process: Note it, keep working, address when appropriate.

## Format
- [Phase] - [Priority] - [Title] - [Date discovered]
  - Quick description
  - Where it should be addressed
  - Why it's important

---

## Current Parking Lot Items

## Active Items

### [Phase 1c] - HIGH - Database migration validation
- **Context**: Need validation strategy for Phase 2 migration
- **Solution**: Seed scripts + integrity tests + baselines  
- **Documents**: See docs/phase-1/database-validation-strategy.md

<details>
<summary>Author's Notes</summary>

- Research: https://claude.ai/chat/4176855c-880a-47f0-bec6-fb7ecc601c80
- Insights: Seed scripts preferred over backups for VCS/transparency
- Discussed production dump anti-patterns (common enterprise mistake)

</details>


### [Phase 4] - EXAMPLE MEDIUM (NOT REAL) - jQuery/Ajax browser compatibility concerns
- **Discovered**: 2025-01-10 during Phase 1a smoke testing  
- **Context**: Noticed older jQuery version might have issues
- **Action needed**: Document risk, add to Phase 4 testing
- **Address during**: Phase 1a retrospective or Phase 4 planning
- **Notes**: Test in multiple browsers before platform migration

### [Phase 2] - EXAMPLE LOW (NOT REAL) - Connection string format differences
- **Discovered**: 2025-01-10 reading EF documentation
- **Context**: LocalDB vs Azure SQL connection strings different
- **Action needed**: Document expected changes
- **Address during**: Phase 2a database migration
- **Notes**: Should be straightforward but document it