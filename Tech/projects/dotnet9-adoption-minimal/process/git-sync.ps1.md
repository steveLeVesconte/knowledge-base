
$current-phase = "phase-1-foundation"
$current-sub-phase="phase-1b-testing-framework"

git fetch --all --prune
git checkout main
git pull --ff-only
git checkout $current-phase
git pull --ff-only
git checkout $current-sub-phase
git pull --ff-only