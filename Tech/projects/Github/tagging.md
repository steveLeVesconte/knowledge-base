## Primary Focus (what TO do):
- advise on plan to ensure that phase-1-foundation gets tag of v1.0.0
## Success Criteria (done when):
AI provides a clear description of the needed tagging and the steps to achieve it
## Context Priority:
PRIMARY: - developer is unsure of how semantic tags work
- developer is unsure standards for using semantic tags
- project outline specifies that phase-1-foundation gets tag of "v1.0.0"
- project progress into GitHub at this moment:
  -- seed project has been roughly smoke tested (public pages only) - it builds - it makes a website locally
  -- seek project has been committed to phase-1a-local-setup and pushed to origin
  -- no tags yet applied to any branch
- developer suspects -> I should tag now as "v1.0.0", then as I make more commits, I should increase the last digit (say for checking in the docs/phase-1/readme.md
- developer hopes this happens in the current branch phase-1a-local-setup and then gets inscribed in phase-1-foundation and main through merges.EditSemantic Versioning and Git Tagging Strategy
Your instinct is partially correct but needs refinement. Let me clarify how semantic versioning and Git tags work in practice.
Semantic Versioning Basics
Format: MAJOR.MINOR.PATCH (e.g., v1.0.0)

MAJOR (1.x.x): Breaking changes - incompatible API changes
MINOR (x.1.x): New features - backward compatible additions
PATCH (x.x.1): Bug fixes - backward compatible fixes

When to Tag in Your Project
Your project outline specifies v1.0.0 for Phase 1 completion, not at the start. Here's the correct approach:
Tags Mark Milestones, Not Work-in-Progress
Tags should be applied to completed, stable states that represent a milestone - typically when code is merged to main and represents a release point.
Incorrect approach (what you're considering):
bash# On phase-1a-local-setup
git commit -m "Add initial smoke tests"
git tag v1.0.0  # ❌ Too early - phase incomplete
git commit -m "Add documentation"
git tag v1.0.1  # ❌ Not how versions work
Correct approach:
bash# Work on phase-1a-local-setup (no tags yet)
git commit -m "Add initial smoke tests"
git commit -m "Add documentation"
git commit -m "Complete environment setup"

# Merge to phase-1-foundation
git checkout phase-1-foundation
git merge phase-1a-local-setup

# Work on phase-1b-testing-framework
git checkout -b phase-1b-testing-framework
# ... commits ...
git checkout phase-1-foundation
git merge phase-1b-testing-framework

# Work on phase-1c-baselines
git checkout -b phase-1c-baselines
# ... commits ...
git checkout phase-1-foundation
git merge phase-1c-baselines

# NOW Phase 1 is complete - merge to main and tag
git checkout main
git merge phase-1-foundation --no-ff
git tag -a v1.0.0 -m "Phase 1: Foundation & Local Baselines complete"
git push origin main --tags
Your Specific Situation
Current state:

You're on phase-1a-local-setup
Code is pushed but no tags exist
Phase 1a is not yet complete

What to do now:

Don't tag yet - Continue working on Phase 1a
Make normal commits as you complete tasks (docs, tests, etc.)
When Phase 1a is complete, merge to phase-1-foundation
When ALL Phase 1 sub-phases complete, merge to main and tag v1.0.0

Tagging Commands
When you're ready to tag (Phase 1 fully complete):
bash# Annotated tag (recommended - includes metadata)
git tag -a v1.0.0 -m "Phase 1: Foundation & Local Baselines complete"

# Push tag to remote
git push origin v1.0.0

# Or push all tags
git push origin --tags
Why Not Tag Individual Documents?
Your idea of incrementing patch versions for documentation commits (v1.0.0 → v1.0.1 for README) doesn't align with semantic versioning principles:

Documentation changes alone don't warrant version bumps (unless it's API documentation fixing incorrect information)
Patch versions are for bug fixes in code, not iterative work
You'd end up with v1.0.47 by the time Phase 1 completes - meaningless noise

What About Tracking Progress Without Tags?
Use commits and branch organization:
bash# Descriptive commit messages track progress
git commit -m "docs: add Phase 1 README"
git commit -m "docs: add smoke test checklist template"
git commit -m "test: convert MSTest to xUnit"
git commit -m "test: add Album CRUD unit tests"
Recommended Tagging Strategy for Your Project
Based on your project outline:
TagApplied WhenLocationv1.0.0Phase 1 completemain branchv2.0.0Phase 2 complete (Azure migration)main branchv3.0.0Phase 3 complete (Azure validation)main branchv4.0.0Phase 4 complete (.NET 9 migration)main branch...Each phase completionmain branch
Each tag represents a stable, tested, documented milestone merged to main.
Common Pitfall to Avoid
Don't confuse Git tags with issue tracking. If you want to track granular progress:

Use GitHub Issues with checkboxes
Use your PROJECT-LOG.md (already in your plan)
Use commit messages
Use branch names

Tags are for external-facing releases and major milestones, not internal work tracking.
Summary
Right now: Keep working, keep committing, don't tag yet.
When Phase 1 is 100% complete (all sub-phases merged to phase-1-foundation, all completion criteria met):

Merge phase-1-foundation to main
Tag main with v1.0.0
Push tag to origin
Move to Phase 2

The tag will naturally be "inscribed" through merges because Git tags point to specific commits - when you merge to main, that commit gets the tag.