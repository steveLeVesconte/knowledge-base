# Known Limitations - Phase 1 Baseline

  

## Security Issues (Demo Application)

  

## Infrastructure Configuration

  

### HTTPS/SSL Not Configured

**Current State**: Application runs HTTP-only on localhost

**Impact**: Azure App Service requires HTTPS; cookie security attributes differ

**Resolution**: Enable HTTPS in Phase 2a before Azure deployment

**Testing Impact**: Phase 1 baselines captured over HTTP; Phase 3 will capture HTTPS baselines in Azure

  
  

### Self-Assigned Role Selection

**Issue**: Users can select Admin or Visitor role during registration

**Impact**: No access control - anyone can become admin

**Status**: Accepted for Phases 1-4

**Remediation**: Phase 5 - implement proper role management

  
  

## Low-Priority UI Enhancements

  

### External Links Missing target="_blank"

**Location**: Footer "Built with ASP.NET MVC 5" link

**Current**: Opens in same tab

**Suggested**: Add `target="_blank" rel="noopener noreferrer"`

**Status**: Accepted for Phases 1-10

**Priority**: Low - cosmetic only - not in scope

**Phase**: Defer to post-migration-project (UI modernization)

  
  

### All album images link to a single placeholder.gif

**Location**: All album Detail pages and featured albums

**Current**: All album images link to a single placeholder.gif

**Suggested**: change database, entities, ui and api to support separate image-id per album

**Status**: Accepted for Phases 1-10

**Priority**: Low - not in scope

**Phase**: Defer to post-migration-project (UI modernization)