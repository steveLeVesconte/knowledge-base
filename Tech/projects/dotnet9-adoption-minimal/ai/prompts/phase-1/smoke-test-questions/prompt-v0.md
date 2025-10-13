# Task Description: discuss smoke test details


## Persona: as  team lead instructing a junior developer

## Primary Focus (what TO do):
- evaluate change to the "registration" smoke test section.  Right level of detail? Go deeper into all of the permutations of validation violations (or is that too deep for smoke?) 

## Boundaries (what NOT to do):
- go overboard - suggest too much.  We want respectable process - not extreme DOD process.

## Success Criteria (done when):
□ clear procedure for junior developer plus conceptual guide


## Context Priority:
- Before and After smoke test sections pasted in blow:

PRIMARY: 
 - project-outline.md


        
SECONDARY: - 


- work-breakdown.md
- smoke-test-chrome.md
  
---
BEFORE:
## Authenticated User Flows (Visitor Role)

### Registration
- [ ] Navigate to `/Account/Register`
- [ ] Register form displays all required fields
- [ ] Enter email: `testuser-[timestamp]@example.com`
- [ ] Enter password: `Test@123456` (meets complexity)
- [ ] Confirm password matches
- [ ] **Select "Admin" or "Visitor" role from dropdown** (Note: Self-service role assignment - demo app only)
- [ ] Submit registration
- [ ] Success message displays
- [ ] Automatic login occurs
- [ ] Username displays in navigation bar
- [ ] User redirected to home page


--------

AFTER
## Authenticated User Flows (Visitor Role)

### Registration
- [ ] Click on "Register" in the header.
- [ ] Register form displays all required fields: Email, Password, Confirm password, User Role Radio button
- [ ] Enter email: `testuser-[timestamp]@example.com` - testuser-20251007-0930@example.com
- [ ] Email validation works
- [ ] Enter password: `Test@123456` (meets complexity) 
- [ ] password validation works 
- [ ] Confirm password matches
- [ ] Confirm password validation works
- [ ] **Select "Admin" or "Visitor" role from dropdown** (Note: Self-service role assignment - demo app only)
- [ ] Submit registration
- [ ] Automatic login occurs
- [ ] Username displays in navigation bar
- [ ] User redirected to home page


