# Known Limitations - Phase 1 Baseline

## Issues to Address During Migration

### Self-Assigned Role Selection
**Impact**: Security - no access control
**Resolution**: Phase 5 - Modern Authentication & External Identity Providers
**Scope Decision**: Security issue intrinsic to authentication modernization - must fix as part of planned Phase 5 work

### HTTPS Not Configured  
**Impact**: Required for Azure deployment, affects cookie security behavior
**Resolution**: Phase 2a - Azure Migration
**Scope Decision**: Infrastructure requirement for cloud deployment - must fix as prerequisite for Phase 2


-------------------------------------------

## Tutorial App Limitations (Deferred - Out of Scope)

### Placeholder Images for All Albums
**Current**: All albums use single `placeholder.gif` (100x75)
**Scope Decision**: Feature enhancement - not addressing until Phase 5 completion
**Rationale**: Migration project scope limited to platform modernization and cloud deployment. New features deferred to potential Phase 5a (Feature Enhancements) or post-migration work.

### No Artist or Genre Detail Pages
**Current**: Artist and genre names display as text only (not clickable)
**Scope Decision**: Feature enhancement - not addressing until Phase 5 completion
**Rationale**: Migration project scope limited to platform modernization and cloud deployment. New features deferred to potential Phase 5a (Feature Enhancements) or post-migration work.

### External Footer Link Opens in Same Tab
**Current**: "Built with ASP.NET MVC 5" link lacks `target="_blank" rel="noopener noreferrer"`
**Additional note**: Microsoft redirects this URL to ASP.NET Core marketing page (not MVC 5 docs)
**Scope Decision**: UI/UX improvement - not addressing until Phase 5 completion
**Rationale**: 
- Cosmetic issue unrelated to migration objectives
- Link destination controlled by Microsoft, not this application
- Does not impact functional parity or cloud deployment success

**Potential Phase 5+ action**: Update footer to "Built with ASP.NET" (framework-agnostic) or remove link entirely

### External Link on Login Page Opens in Same Tab
**Current**: "See this article for details..." link lacks `target="_blank" rel="noopener noreferrer"`
**Additional note**: Microsoft redirects this URL to ASP.NET Core marketing page (not promised OAuth setup details)
**Scope Decision**: UI/UX improvement - not addressing until Phase 4 view migration
**Rationale**: 
- Cosmetic issue unrelated to migration objectives
- Link destination controlled by Microsoft, not this application
- Does not impact functional parity or cloud deployment success

**Phase 4 action**: Remove sentence and link during view migration - external OAuth setup instructions no longer relevant after Phase 5 authentication modernization

### Non-Responsive UI Design
**Current**: Fixed-width layout optimized for desktop (approximately 950px-1200px viewport width)
**Impact**: Unusable on mobile devices, degraded experience on ultra-wide monitors (tablets not tested)
**Scope Decision**: UI modernization - deferred until Phase 5 completion, then re-evaluate priority
**Rationale**: Implementing responsive design requires Bootstrap upgrade (3.4.1 → 5.x) and CSS refactoring across all views. This work introduces regression risk during platform migration. Mobile responsiveness does not affect cloud deployment success or functional parity with current application. Defer to post-Phase 5 evaluation.



---

## Scope Control Policy (See CONTRIBUTING.md)
