# context:

working on:
- smoke-test-chrome.md
- project-outline
- KNOWN-LIMITATIONS

I have decided to add the material below the dashed line to the smoke-test-chrome.md because initial tests of HTTPS were fraught, difficult and prolonged.

AI Task: Please provide:
- improvements (if any) to the smoke-test-chrome.md (below the dashed line)
- addition to project-outline phase-2 to honor the promise of "Phase 2 explicitly includes HTTPS testing as first task.".
- additions to KNOWN-LIMITATIONS (if any) suggested for this situation.
- how to indicate something like "N/A" or "delayed" in the checkbox of "- [ ] HTTPS enforced: NOT CONFIGURED for local development".  Should I just replace the "[x]" with a word like "postponed"?  Currently our checkbox seems to only distinguish "done" from "not yet done"


---
- [ ] HTTPS enforced: NOT CONFIGURED for local development

**Decision**: HTTPS configuration deferred to Phase 2 (Azure deployment requirement).
Local testing continues over HTTP. Phase 2 will test:
- Azure App Service HTTPS enforcement
- Certificate configuration
- Secure cookie attributes
- OAuth callback over HTTPS

**Risk**: May discover HTTPS-specific issues in Phase 2 (late discovery).
**Mitigation**: Phase 2 explicitly includes HTTPS testing as first task.






----------------


AI Task: (2 items)

# Item1 (corrections)
Please redo the document updates of the last prompt with the clear understanding that:
- There will be no support for external providers until phase-4
- Owin Only


see attached code file for confirmation Setup_Auth.cs



# Item 2 (addtion)

Create some text for PROJECT-LOG.md for this decision.

