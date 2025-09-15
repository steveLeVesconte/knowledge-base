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

