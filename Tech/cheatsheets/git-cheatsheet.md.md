## Initialize Git Repository
#git #init

Purpose: add GitHub repo to an existing project.

### Steps
```powershell
git init
# paste in a .gitignore for the project
git add .gitignore
git commit -m "Initial commit: Clean .NET 9 Todo Demo project before Application Insights"

git add .
git commit -m "Initial commit of .NET API and WEB projects"

git remote add origin <github repo url>
git branch -M main
git push -u origin main

```


## List all files ignored by .gitignore
#git #utility #gitignore

Shows all files currently ignored by your `.gitignore`. Useful for troubleshooting missing files in your repo.

```powershell
git status --ignored
```



## List all files not ignored by .gitignore
#git #utility #gitignore

Shows all files included for git (not ignored)  by your `.gitignore`. Useful for troubleshooting missing files in your repo.  Just useful for listing most relevant files (not build artifacts)

```powershell
git ls-files .gitignore
```

The command above works on solutions in a normal checked-in state.  For new projects:
```
git init
<add a .gitignore file>
git ls-files --others --exclude-standard
```



## Branch creation
#git #utility #branch

Create a git branch

```powershell
git checkout main # Make sure you're on main first 
git pull # Get latest changes 
git checkout -b ai-2-infra-deploy # Branch from clean main
```


## Suggested Workflow for an AI work step
#git #utility #ai #workflow

```powershell
# You're already committed and synced, so:
git checkout -b ai-2-infra-deploy

# Create your AI subfolder
mkdir -p AI/Step2-InfrastructureDeployment

# Work with AI, iterate, test
# When satisfied:
git add .
git commit -m "Add infrastructure deployment automation"

# Merge back
git checkout main
git merge ai-2-infra-deploy
git branch -d ai-2-infra-deploy
git push
```

## Delete a committed branch
#git #utility #delete

Safe because uncommitted branches will not be deleted.

```powershell
git branch -d ai-2-infra-deploy
```



## Delete a uncommitted branch (trash)
#git #utility #delete

Dangerous - because uncommitted branches will be deleted.  Use only for trash branches.

```powershell
git branch -D ai-2-infra-deploy
```


## Is Git State Clean?
#git #status #safe #clean
**One command to check everything:**

bash

```bash
git status
```

This shows you:

- Uncommitted changes (files to add/commit)
- Commits ahead of origin (need to push)
- Current branch
- Clean state vs. dirty state

## What "Clean and Synced" Looks Like

bash

```bash
On branch main
Your branch is up to date with 'origin/main'.

nothing to commit, working tree clean
```

## If You See Problems

**Uncommitted changes:**

bash

```bash
git add .
git commit -m "Save work before branching"
```

**Ahead of origin:**

bash

```bash
git push
```

**Behind origin:**

bash

```bash
git pull
```

## Pro Tip: VS Code Status Bar

Look at the bottom-left of VS Code:

- Shows current branch name
- Shows number like "↑1 ↓2" (1 ahead, 2 behind)
- Shows "M" for modified files count

If you see just the branch name with no numbers or letters, you're clean and synced.

## One-Liner Check (if you want to be extra sure)

bash

```bash
git status && echo "--- Remote status ---" && git fetch --dry-run
```

But honestly, just `git status` is usually sufficient. If it says "nothing to commit, working tree clean" and "up to date with origin", you're good to branch!

## Rename branch:

```
git branch -m master main
```



# Git Cheat Sheet Entries (Based on This Session)

---

## Branch & Status

**Check Branch & Status**
- Template: `git status`
- Purpose/Reason To Use: See your current branch and if you have uncommitted changes.
- Common Sequence: Before switching branches or pulling, run `git status`.
- Value: Prevents loss of work and confusion before making changes.

**Switch Branch**
- Template: `git checkout <branch>`
- Purpose/Reason To Use: Move to a different branch safely.
- Common Sequence: `git status` → `git checkout main`
- Value: Safe to use when no changes are present; shows branch state.

---

## Syncing with Remote

**Fetch Remote Updates**
- Template: `git fetch origin`
- Purpose/Reason To Use: Get latest state of remote branches without altering local files.
- Common Sequence: Run before inspecting remote changes or planning updates.
- Value: Updates your repo's metadata; does not change files.

**Update Local Branch to Match Remote (Fast-Forward)**
- Template: `git pull` or `git pull origin <branch>`
- Purpose/Reason To Use: Bring your local branch up to date with the remote branch.
- Common Sequence: `git fetch origin` → `git pull`
- Value: Safely updates files and branch pointer; no merge commit if possible.

**Show Commits Missing Locally**
- Template: `git log <local_branch>..<remote>/<branch> --oneline`
- Purpose/Reason To Use: See which commits remote has that you do not locally.
- Common Sequence: After `git fetch origin`, run `git log main..origin/main --oneline`
- Value: Helps diagnose why your local branch is "behind".

---

## Rebasing & Merging

**Rebase Local Branch onto Remote/Main**
- Template: `git rebase origin/main` (or `git rebase main`)
- Purpose/Reason To Use: Replay your commits on top of the latest main or remote branch commits.
- Common Sequence: `git fetch origin` → `git checkout <feature-branch>` → `git rebase origin/main`
- Value: Keeps history linear and up-to-date; working files and repo both updated.

**Merge Remote Changes into Local Branch**
- Template: `git merge origin/main`
- Purpose/Reason To Use: Incorporate changes from remote main into your local branch.
- Common Sequence: `git fetch origin` → `git checkout main` → `git merge origin/main`
- Value: Useful if fast-forward isn’t possible; solves divergence.

---

## Safety and Inspection

**Check for File-Specific Commit History**
- Template: `git log --oneline -- <filename>`
- Purpose/Reason To Use: See commit history for a specific file.
- Common Sequence: Inspect presence/history of a file (e.g., `git log --oneline -- CONTRIBUTING.md`)
- Value: Verifies when and if a file was added.

**See Tracking Info and Divergence**
- Template: `git branch -vv`
- Purpose/Reason To Use: Show which remote branch your local branch is tracking and if it is ahead/behind.
- Common Sequence: After fetch, run `git branch -vv`
- Value: Diagnoses sync issues between local and remote.

---

## Troubleshooting Tips

- **"Fast-forward" means your branch can be updated without a merge commit because it has no unique commits compared to remote.**
- **`git fetch` only updates your repo’s metadata and remote refs, not files. Use `git pull` or merge/rebase to update files.**
- **If VS Code shows a file in "open editors" but it's missing in your folder, check your current branch and sync state.**
- **Force-push (`git push --force-with-lease`) may be needed after rebasing a branch that you’ve already pushed.**

---

## General Workflow Example

**Update Feature Branch with Latest Main**
1. `git fetch origin`
2. `git checkout main`
3. `git pull` (or `git merge origin/main`)
4. `git checkout <feature-branch>`
5. `git rebase main`
6. Resolve conflicts if any, then `git push --force-with-lease` if branch is on remote.

---


## My Review Process for This Commit

### Architecture
- [x] Base class design matches DRY requirements
- [x] Fresh context pattern correctly addresses EF isolation
- [x] Helper methods have clear, intention-revealing names

### Correctness  
- [x] All 12 tests pass
- [x] WithFreshContext used for all post-mutation assertions
- [x] Fixture access pattern consistent (CreateDbContext)
- [x] Dispose pattern correctly implemented

### Code Quality
- [x] XML documentation explains WHY pattern is needed
- [x] Method signatures use appropriate generics
- [x] No code duplication between tests
- [x] Naming conventions followed

### Edge Cases
- [x] Empty cart scenarios covered
- [x] Multiple items with quantities handled
- [x] Cart migration preserves data integrity

### Future-Proofing
- [x] Pattern extensible to Checkout/Catalog tests
- [x] No hardcoded assumptions
- [x] Clear examples in base class docs

**Approval:** Ready for PR
**Confidence:** High - pattern solves real EF cache issue
**Concerns:** None - straightforward refactoring




- feat: a new feature
- fix: a bug fix
- docs: documentation only changes
- style: formatting, no code logic changes
- refactor: code change that neither fixes a bug nor adds a feature
- perf: performance improvement
- test: adding or changing tests
- chore: maintenance (build, tooling, deps)
- ci: CI config
- build: build system changes