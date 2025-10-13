# Smoke Test Execution - MVC Music Store
**Environment**: Local
**Date**: 
**Tester**: 
**Build/Commit**: 00f882d
**Browser**: 
**Test Duration**: 

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
- [ ] Click on "Register" in the header.
- [ ] Verify form displays all required fields: Email, Password, Confirm Password, User Role radio buttons
- [ ] Enter email: `testuser-[timestamp]@example.com` (example: testuser-20251007-0930@example.com)
- [ ] Enter password: `Test@123456` (meets complexity requirements)
- [ ] Confirm password matches
- [ ] Select "Visitor" role (Note: Self-service role assignment - demo app only)
- [ ] Submit registration
- [ ] Verify success: automatic login occurs, username displays in navigation bar
- [ ] Verify redirect to home page


### Login
- [ ] Log out from current session
- [ ] Click on "LogIn" in the header.
- [ ] Enter registered credentials
- [ ] "Remember me" checkbox present
- [ ] Submit login
- [ ] Redirect to home
- [ ] Username visible in header
- [ ] Session persists across page navigation

### Shopping Cart Persistence
- [ ] Browse catalog, add 2 albums to cart
- [ ] Navigate away from cart
- [ ] Close and reopen browser (if testing cookie persistence)
- [ ] Navigate back to cart (click on Cart(n) in header)
- [ ] Both items still present with quantities
- [ ] Update quantity on one item (this can only be done by visiting the detail page and clicking "Add To Cart" button again to add another item)
- [ ] Remove one item completely (each click of "remove from cart" is a single decrement)

### Checkout Process
- [ ] Navigate to cart with items (click on Cart(n) in header)
- [ ] Click "Checkout"
- [ ] Checkout form loads (no redirect to login)
- [ ] Fill required fields:
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
- [ ] Submit order
- [ ] Order processing completes (no errors)
- [ ] Order confirmation page displays
- [ ] Order number visible on confirmation
- [ ] Order total matches cart total
- [ ] Cart is now empty

### Logout
- [ ] Click logout link
- [ ] Redirect to home page
- [ ] Username no longer in navigation
- [ ] Session persists (cart items remain after logout) ← TUTORIAL BEHAVIOR

**Note**: Shopping cart is session-based, not user-based. Cart persists across login/logout. 
This is expected tutorial app behavior. See KNOWN-LIMITATIONS.md for details and Phase 7 considerations.

---

## Admin User Flows

### Admin Authentication
- [ ] Navigate to `/Account/Login` or click "Log in" in header
- [ ] Login with admin credentials
  - Email: admin-[timestamp]@example.com` (example: admin-20251008-0135@example.com)
  - Password: `Test@123456`
- [ ] Successful login
- [ ] Admin-specific UI elements visible - link "Admin" in header

### Store Manager Access
- [ ] Navigate to `/StoreManager` or click "Admin" in header
- [ ] Store Manager dashboard loads
- [ ] Album list displays all albums
- [ ] "Edit", "Details", "Delete" actions visible for each album
- [ ] "Creat New" action visible

### Create Album
- [ ] Click "Create New" on Store Manager
- [ ] Create form loads with all fields
- [ ] Fill in test album:
  - Title: `Smoke Test Album [timestamp]`
  - Price: 9.99  (Price must be between 0.01 and 100.00)
  - Album Art URL: [use existing valid URL] - /Content/Images/placeholder.gif
  - Artist: Select from dropdown
  - Genre: Select from dropdown
- [ ] Submit form
- [ ] Redirect to Store Manager list
- [ ] New album visible in list

### Edit Album
- [ ] Click "Edit" on test album
- [ ] Edit form pre-populated with current values
- [ ] Change title to `Smoke Test Album EDITED`
- [ ] Change price to 12.99 (Price must be between 0.01 and 100.00)
- [ ] Submit changes
- [ ] Album list shows updated values

### Delete Album
- [ ] Click "Delete" on test album
- [ ] Confirmation page displays album details
- [ ] Confirm deletion
- [ ] Album no longer in Store Manager list
- [ ] Album no longer visible in public catalog

### Verify Public Catalog Reflects Changes
- [ ] Log out from admin
- [ ] Browse public catalog as anonymous user
- [ ] Verify edited album shows new price (if not deleted yet)
- [ ] Verify deleted album is not visible

---

## Cross-Cutting Concerns

### Session Management
- [ ] Session maintains across page navigation **PASS**
- [ ] Session timeout works (default 20 min, sliding expiration) **PASS - NOT EXHAUSTIVE**
- [ ] Session expires on logout **FAIL** (expected behavior, but problematic for cart)

### Error Handling
- [ ] Navigate to non-existent page (`/DoesNotExist`) - appropriate 404 **PASS**
- [ ] Intentionally trigger server error - custom error page (not YSOD) **PASS**

**Result**: PASS - custom error configuration works correctly in both dev and production modes.
Test exception code removed after verification.

### Security Verification
- [ ] Anonymous user cannot access `/StoreManager` - redirects to login
- [ ] Visitor user cannot access `/StoreManager` **FAIL** SAME BUG AS ADMIN

**Finding**: Both Admin and Visitor roles exhibit same behavior - redirect to login 
instead of proper authorization check. This is the authorization bug discovered during 
admin testing (see PROJECT-LOG.md investigation).

**Workaround**: Access `/StoreManager` while not logged in, then login from redirect.

### Anti-Forgery Token Verification
- [ ] View source on Register form - `__RequestVerificationToken` present
- [ ] Token has long random value (100+ chars, base64-encoded)
- [ ] Token changes on page refresh (not static)
- [ ] Checked 3 other forms (Login, Album Create, Checkout) - all have tokens
- [ ] Cookie `__RequestVerificationToken` present in browser

**Result**: **PASS** - CSRF protection active via ASP.NET MVC anti-forgery tokens

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
- Initial attempt to configure HTTPS blocked smoke testing. Remediation attempts lasted more than an hour. Fixing this is not a smoke test concern - document and move on.


### Validation (Basic Smoke Test)

**Client-Side Validation**
- [ ] Register form: Submit with empty email - validation message displays before server request
- [ ] Register form: Submit with invalid email format - validation message displays

### 🧪 Server-Side Validation Smoke Test (bypass client-side validation)

- [ ] Disable JavaScript in Chrome (DevTools → Ctrl+Shift+P → "Disable JavaScript")
- [ ] Open **Register** form
- [ ] Submit with empty required fields
- [ ] Observe full page reload (POST → controller)
- [ ] Confirm **server-side validation** handled the errors  
  **Proof:**  
  - `POST /Register` observed in DevTools Network tab (status **200**)  
  - Response HTML contained server-rendered `<div class="validation-summary-errors">`  
    with `<li>` items: *"The Email field is required."*, *"The Password field is required."*, etc.
- [ ] Re-enable JavaScript (Ctrl+Shift+P → "Enable JavaScript")


**Validation Libraries Load**
- [ ] Check browser console: jquery.validate.min.js loads (despite load order warning)
- [ ] Model attributes ([Required], [EmailAddress]) trigger validation

**Notes**:
- Most forms use standard model validation attributes (work correctly)
- Album Art URL only has [StringLength(1024)] - accepts any string up to 1024 chars
- jQuery Validate load order issue documented in view-migration-tasks.md (Phase 4f)

**Smoke Test Verdict**: **PASS** - Basic validation infrastructure works (client + server)

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
**Method:** Disable cache, reload, note "Load" time from Network tab (single sample).

| Page | Load Time (ms) | Notes |
|------|----------------|-------|
| Home |  | - |
| Store Manager |  | 135 Albums from seed |
| Checkout completion |  | Includes POST → 302 → confirmation page (single navigation) |

---


## Test Result Summary

**Upgrade Readiness Status:**  GO  
*("GO" means the app builds, runs, and can be smoke-tested; issues found are recorded for later remediation.)*

**Blocker Definition:**  
A "blocker" is any issue that prevents effective smoke testing (e.g., compile failure, missing dependencies, or startup crash).

**Findings Summary**
- Blockers: 0  
- Phase-X Fixes: 0  
- Scope Variance Candidates: 1

---

## Issue Type Legend
- **Blocker**: Prevents smoke testing or app startup
- **Phase-X Fix**: Will be resolved during specific migration phase (not scope creep)
- **Scope Variance Candidate**: New work outside original migration scope - requires approval

---

## Issues Log

### Issue #1: Checkout Button Visible on Empty Cart
**Issue Type**: Scope Variance Candidate
**Category**: UX / Business Logic
**Classification**: Tutorial App Limitation (deferred)

**Steps to Reproduce**:
1. Add items to shopping cart
2. Remove all items (click "Remove from cart" until cart empty)
3. Observe "Checkout" button still visible
4. Click "Checkout" button

**Expected (Ideal)**: 
- Checkout button disabled or hidden when cart empty
- Clicking checkout on empty cart shows friendly message ("Your cart is empty")

**Actual**: 
- Checkout button remains enabled on empty cart
- Clicking proceeds to `/Checkout/AddressAndPayment` form
- User can submit order with $0.00 total and zero items

**Impact**: 
- Minor UX issue - confusing to proceed through checkout with empty cart
- Potential to create $0.00 orders in database (data quality issue)

**Baseline Behavior**: Tutorial app does not validate cart state before checkout
**Resolution**: Defer to post-Phase 5 (tutorial app limitation - see KNOWN-LIMITATIONS.md)
**Migration Note**: Phase 4 must preserve this behavior (functional parity requirement)

**Validation in Future Phases**:
- Phase 4: Verify empty cart checkout still behaves identically (regression check)
- Phase 5+: Consider fix if addressing tutorial app limitations

**Related Items**: 
- Shopping cart not user-isolated (see KNOWN-LIMITATIONS.md)
- Order.Total column unpopulated (see KNOWN-LIMITATIONS.md)



### Issue #n: [Brief title]
**Issue Type**: Blocker | Phase-X Fix | Scope Variance Candidate 
**Category**: Authentication | UI | Performance | Data
**Steps to Reproduce**:
1. [Step 1]
2. [Step 2]

**Expected**: [What should happen]
**Actual**: [What happened]
**Console Errors**: