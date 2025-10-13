#phase-4-view-migration-tasks.md

### Task #1: Fix Duplicate ID Attributes on Registration Form

**Problem**
**Expected**: Each form element has unique `id` attribute
**Actual**: Both UserRole radio buttons have `id="UserRole"`
**Console Warning**: `[DOM] Found 2 elements with non-unique id #UserRole`

** recomended new code **
<input id="UserRole_Admin" name="UserRole" type="radio" value="Admin">
<label for="UserRole_Admin">Admin</label>