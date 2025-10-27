# Task Description: session oriented smoke tests 


## Persona: as Lead Dev who is also a career couch.

## Primary Focus (what TO do):
- Plan Session Management smoke tests.

## Boundaries (what NOT to do):
- go overboard - suggest too much.  We want respectable process - not extreme DOD process.

  
  

## Success Criteria (done when):
- smoke-test-edge.md and related documents record this issue in a clear and professional and useful way.  They appear professional for the audience of Hiring managers.
- The developer (me) clearly understands the meaning of the smoke test evidence
  


## Context Priority:

PRIMARY: 
Smoke test that appears professional
Smoke test that helps as a baseline for the upgrade process.
I learn from the process.
Current situation: I am somewhat confused by these three smoke test lines:

### Session Management

- [ ] Session maintains across page navigation **PASS**

- [ ] Session timeout works (default 20 min, sliding expiration) **PASS - NOT EXHAUSTIVE**

- [ ] Session expires on logout **FAIL** (expected behavior, but problematic for cart)

I find them too general and detached from observation and proof.
I would prefer lines like "I did X and I saw Y so PASS".
I am especially interested in adding tests that address (not an exhaustive list):
- what to specifically look for to say "Session maintains" - just cart contents or watch cookie (which one?)
- what should happen when an anonymous user has items in cart, hits "checkout", sees login page, turns off computer, returns next day and logs in.
So I want, I think, 5-10 tests that are clear and specific about these issues.
If what I am asking for is to detailed for a smoke test, then say which ones are too specific, but provide them anyway.  

- smoke-test-edge.md
- KNOWN-LIMITATIONS.md
- project-outline.md
- PARKING-LOT.md
- PROJECT-LOG.md



        
SECONDARY:
- smoke-test-chrome.md
assume the organization is the size of a regional bank working on in-house software.
I am a Software Dev
30+ experience: MVC, .NET, C#, SQL, APIs, HTML, CSS, XML, Banking, Government, Incentives
Out of work for 2 years
Refreshing skill set to include more Core and cloud


# FILE LOCATIONS:
.
PARKING-LOT.md
PROJECT-LOG.md
project-outline.md

.\docs
KNOWN-LIMITATIONS.md
 
 .\docs\phase-1\smoke-tests
smoke-test-chrome.md
smoke-test-edge.md


