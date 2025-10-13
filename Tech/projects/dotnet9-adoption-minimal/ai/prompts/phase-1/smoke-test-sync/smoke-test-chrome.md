# Smoke Test Execution - MVC Music Store
**Environment**: Local
**Date**: 2025-10-05
**Tester**: s levesconte
**Build/Commit**: 00f882d
**Browser**: 140.0.7339.208 (Official Build) (64-bit)
**Test Duration**: 12:37 - [End time]

---

## Checkbox Status Legend

- `[x]` - Test executed and passed
- `[ ]` - Test not yet executed
- `[DEFERRED]` - Test intentionally postponed to later phase
- `[N/A]` - Test not applicable in current environment/phase
- `[BLOCKED]` - Test blocked by dependency (specify reason)
- `[SKIP]` - Test skipped due to known limitation (reference KNOWN-LIMITATIONS.md)

---

## Test Environment Validation
- [x] Application starts without errors
- [x] Database connection successful (both Identity & MusicStore DBs)
- [x] No console errors on initial page load


---

## Anonymous User Flows

### Home Page
- [x] Navigate to root URL successfully
- [x] Page loads within 3 seconds
- [x] Genre navigation menu displays all genres
- [x] Featured albums render with images - 5 rendered with test image
- [x] No JavaScript console errors
- [x] No broken image links

### Catalog Browse
- [x] Click "Rock" genre from navigation
- [x] Album list loads for selected genre
- [x] All album images display correctly
- [x] Album titles are clickable links
- [x] Genre filter persists on page refresh

### Album Detail Page
- [x] Click any album from catalog
- [x] Album details load completely (title, price, artist, genre)
- [x] "Add to cart" button visible and enabled
- [x] Album details load completely (title, price, artist, genre)
- [x] Album artwork displays (placeholder.gif or configured image)

### Shopping Cart (Anonymous User)

**Add Items to Cart**
- [x] Navigate to album detail page, click "Add to cart"
- [x] Navigate to `/ShoppingCart`
- [x] Verify cart shows: album name, quantity (1), unit price, line total
- [x] Verify header shows "Cart (1)"
- [x] Return to same album detail, click "Add to cart" again
- [x] Verify quantity incremented to 2, line total = price × 2
- [x] Verify header shows "Cart (2)"
- [x] Add different album to cart
- [x] Verify cart shows both albums with correct quantities and totals
- [x] Verify header cart count = total items across all albums
- [x] Verify cart grand total = sum of line totals

**Remove Items from Cart**
- [x] Click "Remove from cart" on item with quantity > 1
- [x] Verify quantity decremented by 1, line total recalculated
- [x] Verify header cart count decremented
- [x] Verify message: "[Album] has been removed from your shopping cart"
- [x] Click "Remove from cart" on item with quantity = 1
- [x] Verify item removed from cart entirely (row deleted)
- [x] Verify cart grand total and header count recalculated

**Checkout Preparation**
- [x] Add items back to cart for checkout testing
- [x] Click "Checkout" - **should redirect to `/Account/Login`**

---

## Authenticated User Flows (Visitor Role)

### Registration (Happy Path)
- [x] Click on "Register" in the header.
- [x] Verify form displays all required fields: Email, Password, Confirm Password, User Role radio buttons
- [x] Enter email: `testuser-[timestamp]@example.com` (example: testuser-20251007-0930@example.com)
- [x] Enter password: `Test@123456` (meets complexity requirements)
- [x] Confirm password matches
- [x] Select "Visitor" role (Note: Self-service role assignment - demo app only)
- [x] Submit registration
- [x] Verify success: automatic login occurs, username displays in navigation bar
- [x] Verify redirect to home page


### Login
- [x] Log out from current session
- [x] Click on "LogIn" in the header.
- [x] Enter registered credentials
- [x] "Remember me" checkbox present
- [x] Submit login
- [x] Redirect to home
- [x] Username visible in header
- [x] Session persists across page navigation

### Shopping Cart Persistence
- [x] Browse catalog, add 2 albums to cart
- [x] Navigate away from cart
- [x] Close and reopen browser (if testing cookie persistence)
- [x] Navigate back to cart (click on Cart(n) in header)
- [x] Both items still present with quantities
- [x] Update quantity on one item (this can only be done by visiting the detail page and clicking "Add To Cart" button again to add another item)
- [x] Remove one item completely (each click of "remove from cart" is a single decrement)

### Checkout Process
- [x] Navigate to cart with items (click on Cart(n) in header)
- [x] Click "Checkout"
- [x] Checkout form loads (no redirect to login)
- [x] Fill required fields:
  - First Name: Test
  - Last Name: User
  - Address: 123 Main St
  - City: Seattle
  - State: WA
  - Postal Code: 98101
  - Country: USA
  - Phone: 555-1212
  - Email Address: testuser-20251007-0930@example.com
  - Promo Code: FREE
- [x] Submit order
- [x] Order processing completes (no errors)
- [x] Order confirmation page displays
- [x] Order number visible on confirmation
- [x] Order total matches cart total
- [x] Cart is now empty

### Logout
- [x] Click logout link
- [x] Redirect to home page
- [x] Username no longer in navigation
- [x] Session persists (cart items remain after logout) ← TUTORIAL BEHAVIOR

**Note**: Shopping cart is session-based, not user-based. Cart persists across login/logout. 
This is expected tutorial app behavior. See KNOWN-LIMITATIONS.md for details and Phase 7 considerations.

---

## Admin User Flows

### Admin Authentication
- [x] Navigate to `/Account/Login` or click "Log in" in header
- [x] Login with admin credentials
  - Email: admin-[timestamp]@example.com` (example: admin-20251008-0135@example.com)
  - Password: `Test@123456`
- [x] Successful login
- [x] Admin-specific UI elements visible - link "Admin" in header

### Store Manager Access
- [x] Navigate to `/StoreManager` or click "Admin" in header
- [x] Store Manager dashboard loads
- [x] Album list displays all albums
- [x] "Edit", "Details", "Delete" actions visible for each album
- [x] "Creat New" action visible

### Create Album
- [x] Click "Create New" on Store Manager
- [x] Create form loads with all fields
- [x] Fill in test album:
  - Title: `Smoke Test Album [timestamp]`
  - Price: 9.99  (Price must be between 0.01 and 100.00)
  - Album Art URL: [use existing valid URL] - /Content/Images/placeholder.gif
  - Artist: Select from dropdown
  - Genre: Select from dropdown
- [x] Submit form
- [x] Redirect to Store Manager list
- [x] New album visible in list

### Edit Album
- [x] Click "Edit" on test album
- [x] Edit form pre-populated with current values
- [x] Change title to `Smoke Test Album EDITED`
- [x] Change price to 12.99 (Price must be between 0.01 and 100.00)
- [x] Submit changes
- [x] Album list shows updated values

### Delete Album
- [x] Click "Delete" on test album
- [x] Confirmation page displays album details
- [x] Confirm deletion
- [x] Album no longer in Store Manager list
- [x] Album no longer visible in public catalog

### Verify Public Catalog Reflects Changes
- [x] Log out from admin
- [x] Browse public catalog as anonymous user
- [x] Verify edited album shows new price (if not deleted yet)
- [x] Verify deleted album is not visible

---

## Cross-Cutting Concerns

### Session Management
- [x] Session maintains across page navigation ✅ PASS
- [x] Session timeout works (default 20 min, sliding expiration) ⚠️ PASS (not exhaustively tested)
- [x] Session expires on logout ❌ FAIL (expected behavior, but problematic for cart)

### Error Handling
- [x] Navigate to non-existent page (`/DoesNotExist`) - appropriate 404
- [x] Intentionally trigger server error - custom error page (not YSOD) ✅

**Result**: PASS - custom error configuration works correctly in both dev and production modes.
Test exception code removed after verification.

### Security Verification
- [x] Anonymous user cannot access `/StoreManager` - redirects to login
- [x] Visitor user cannot access `/StoreManager` ❌ SAME BUG AS ADMIN

**Finding**: Both Admin and Visitor roles exhibit same behavior - redirect to login 
instead of proper authorization check. This is the authorization bug discovered during 
admin testing (see PROJECT-LOG.md investigation).

**Workaround**: Access `/StoreManager` while not logged in, then login from redirect.

### Anti-Forgery Token Verification
- [x] View source on Register form - `__RequestVerificationToken` present
- [x] Token has long random value (100+ chars, base64-encoded)
- [x] Token changes on page refresh (not static)
- [x] Checked 3 other forms (Login, Album Create, Checkout) - all have tokens
- [x] Cookie `__RequestVerificationToken` present in browser

**Result**: ✅ PASS - CSRF protection active via ASP.NET MVC anti-forgery tokens

### HTTPS Enforcement
- [DEFERRED] HTTPS enforced (if configured)

**Configuration Status**: NOT CONFIGURED for local development

**Deferral Decision**: 
- HTTPS configuration deferred to **Phase 2a** (Azure deployment requirement)
- Local Phase 1 testing proceeds over HTTP only
- No local HTTPS testing attempted in Phase 1

**Risk Assessment**: 
- **Risk**: Late discovery of HTTPS-specific issues (cookies, OWIN auth, mixed content)
- **Likelihood**: Medium - HTTPS can expose cookie/auth issues not visible over HTTP
- **Impact**: High - Could block Phase 2 Azure deployment if critical issues found
- **Mitigation**: Phase 2a begins with dedicated HTTPS smoke test before database migration

**Rationale**: 
- Initial attempt to configue HTTPS blocked smoke testing.  Remediaton attemps lasted more than an hour.  Fixing this is not a smoke test concern. - document and move on.


### Validation (Basic Smoke Test)

**Client-Side Validation**
- [x] Register form: Submit with empty email - validation message displays before server request
- [x] Register form: Submit with invalid email format - validation message displays

### 🧪 Server-Side Validation Smoke Test (bypass client-side validation)

- [x] Disable JavaScript in Chrome (DevTools → Ctrl+Shift+P → “Disable JavaScript”)
- [x] Open **Register** form
- [x] Submit with empty required fields
- [x] Observe full page reload (POST → controller)
- [x] Confirm **server-side validation** handled the errors  
  **Proof:**  
  - `POST /Register` observed in DevTools Network tab (status **200**)  
  - Response HTML contained server-rendered `<div class="validation-summary-errors">`  
    with `<li>` items: *“The Email field is required.”*, *“The Password field is required.”*, etc.
- [x] Re-enable JavaScript (Ctrl+Shift+P → “Enable JavaScript”)


**Validation Libraries Load**
- [x] Check browser console: jquery.validate.min.js loads (despite load order warning)
- [x] Model attributes ([Required], [EmailAddress]) trigger validation

**Notes**:
- Most forms use standard model validation attributes (work correctly)
- Album Art URL only has [StringLength(1024)] - accepts any string up to 1024 chars
- jQuery Validate load order issue documented in view-migration-tasks.md (Phase 4f)

**Smoke Test Verdict**: ✅ PASS - Basic validation infrastructure works (client + server)


---

## Browser-Specific Issues

### JavaScript Console Errors : None
legend:**None** | **Minor** | **Major**
[If any, copy exact error message here]

### Layout/Rendering Issues: None - Not up to modern standards but no blocking issues
Legend: **None** | **Minor** | **Major**
[Describe any CSS/layout problems]

### Performance Observations
**Purpose:** Quick baseline only — detect major regressions, not for benchmarking.  
**Method:** Disable cache, reload, note “Load” time from Network tab (single sample).

| Page | Load Time (ms) | Notes |
|------|----------------|-------|
| Home | 128 | - |
| Store Manager | 344 | 135 Albums from seed |
| Checkout completion | 144 | Includes POST → 302 → confirmation page (single navigation) |



---


## Test Result Summary

**Upgrade Readiness Status:**  GO  
*(“GO” means the app builds, runs, and can be smoke-tested; issues found are recorded for later remediation.)*

**Blocker Definition:**  
A “blocker” is any issue that prevents effective smoke testing (e.g., compile failure, missing dependencies, or startup crash).

**Findings Summary**
- Blockers: 0  
- Phase-X Fixes: 1  
- Scope Variance Candidates: 1

---

## Issues Log

### Issue #1: Duplicate ID Attributes on Registration Form
**Issue Type**: Phase-4 Fix
**Category**: HTML Validation / Accessibility
**Steps to Reproduce**:
1. Navigate to /Account/Register
2. Open DevTools console

**Expected**: Each form element has unique `id` attribute
**Actual**: Both UserRole radio buttons have `id="UserRole"`
**Console Warning**: `[DOM] Found 2 elements with non-unique id #UserRole`

**Impact**: 
- HTML validation failure
- Potential accessibility issues with screen readers
- Future JavaScript bugs if code references `#UserRole`

**Current Behavior**: Radio buttons function correctly due to `name` attribute grouping
**Resolution**: Phase 4 (view migration to .NET 9)

### Issue #2: Navigation Links Disabled at Tablet/Laptop Widths
**Issue Type**: Scope Variance Candidate - phase 5+  
**Viewports**: ≤980px (iPad, small laptops)  
**Symptoms**: Genre menu and top nav links non-functional; no hover, no click. Album links still work.  
**Impact**: Core navigation blocked for tablet/small laptop users  
**Root Cause Hypothesis**: CSS media query + jQuery event handler conflict (Bootstrap 3/jQuery legacy)  
**Decision**: Defer to Phase 4e (Bootstrap 5 upgrade) - likely resolved by framework modernization  
**Workaround**: Zoom browser >980px or use direct URLs  
**Browser**: Chrome 140.0.7339.208



### Issue #n: [Brief title]
**Severity**: Blocker | Phase-X Fix | Scope Variance Candidate 
**Category**: Authentication | UI | Performance | Data
**Steps to Reproduce**:
1. [Step 1]
2. [Step 2]

**Expected**: [What should happen]
**Actual**: [What happened]
**Console Errors**:




