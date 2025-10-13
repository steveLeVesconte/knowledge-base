# Smoke Test Execution - MVC Music Store
**Environment**: [Local / Azure Dev / Azure Staging]
**Date**: 2025-10-04
**Tester**: [Your Name]
**Build/Commit**: [Git SHA or version tag]
**Browser**: Chrome 131.0.6778.86 (or Edge 131.0.2903.51)
**Test Duration**: [Start time] - [End time]

---

## Test Environment Validation
- [ ] Application starts without errors
- [ ] Database connection successful (both Identity & MusicStore DBs)
- [ ] No console errors on initial page load
- [ ] SSL certificate valid (if HTTPS)

---

## Anonymous User Flows

### Home Page
- [ ] Navigate to root URL successfully
- [ ] Page loads within 3 seconds
- [ ] Genre navigation menu displays all genres
- [ ] Featured albums render with images
- [ ] No JavaScript console errors
- [ ] No broken image links

### Catalog Browse
- [ ] Click "Rock" genre from navigation
- [ ] Album list loads for selected genre
- [ ] All album images display correctly
- [ ] Album titles are clickable links
- [ ] Price displays correctly formatted ($X.XX)
- [ ] Genre filter persists on page refresh

### Album Detail Page
- [ ] Click any album from catalog
- [ ] Album details load completely (title, price, artist, genre)
- [ ] Album artwork displays full-size
- [ ] "Add to cart" button visible and enabled
- [ ] Artist name is clickable (if implemented)
- [ ] Genre is clickable (if implemented)

### Search Functionality
- [ ] Search box accepts input
- [ ] Search for "Led" returns results
- [ ] Search results display with images
- [ ] Search with no results shows appropriate message
- [ ] Search handles special characters (', ", &)

### Shopping Cart (Unauthenticated)
- [ ] Add album to cart from detail page
- [ ] Success message displays
- [ ] Cart icon updates with item count
- [ ] Navigate to `/ShoppingCart`
- [ ] Cart displays album with correct price
- [ ] Update quantity to 3 - price recalculates correctly
- [ ] Update quantity to 0 - item removes from cart
- [ ] Re-add item for checkout test
- [ ] Click "Checkout" - **redirects to `/Account/Login`**

---

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

### Login
- [ ] Log out from current session
- [ ] Navigate to `/Account/Login`
- [ ] Enter registered credentials
- [ ] "Remember me" checkbox present
- [ ] Submit login
- [ ] Successful authentication message
- [ ] Redirect to return URL (or home)
- [ ] Username visible in header
- [ ] Session persists across page navigation

### Shopping Cart Persistence
- [ ] Browse catalog, add 2 albums to cart
- [ ] Navigate away from cart
- [ ] Close and reopen browser (if testing cookie persistence)
- [ ] Navigate back to cart
- [ ] Both items still present with quantities
- [ ] Update quantity on one item
- [ ] Remove one item completely

### Checkout Process
- [ ] Navigate to cart with items
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
  - Phone: 555-0100
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
- [ ] Session terminated (verify cart empty if logging back in)

---

## Admin User Flows

### Admin Authentication
- [ ] Navigate to `/Account/Login`
- [ ] Login with admin credentials
  - Email: `admin@example.com`
  - Password: `Admin@123456`
- [ ] Successful login
- [ ] Admin-specific UI elements visible (if applicable)

### Store Manager Access
- [ ] Navigate to `/StoreManager`
- [ ] Store Manager dashboard loads
- [ ] Album list displays with pagination (if implemented)
- [ ] "Create New", "Edit", "Delete" actions visible for each album
- [ ] Search/filter functionality works (if implemented)

### Create Album
- [ ] Click "Create New" on Store Manager
- [ ] Create form loads with all fields
- [ ] Fill in test album:
  - Title: `Smoke Test Album [timestamp]`
  - Price: 9.99
  - Album Art URL: [use existing valid URL]
  - Artist: Select from dropdown
  - Genre: Select from dropdown
- [ ] Submit form
- [ ] Success message displays
- [ ] Redirect to Store Manager list
- [ ] New album visible in list

### Edit Album
- [ ] Click "Edit" on test album
- [ ] Edit form pre-populated with current values
- [ ] Change title to `Smoke Test Album EDITED`
- [ ] Change price to 12.99
- [ ] Submit changes
- [ ] Success message displays
- [ ] Album list shows updated values

### Delete Album
- [ ] Click "Delete" on test album
- [ ] Confirmation page displays album details
- [ ] Confirm deletion
- [ ] Success message displays
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
- [ ] Session maintains across page navigation
- [ ] Session timeout works (wait 20+ min or adjust web.config)
- [ ] Session expires on logout

### Error Handling
- [ ] Navigate to non-existent page (`/DoesNotExist`) - appropriate 404
- [ ] Submit invalid form data - validation messages display
- [ ] Intentionally trigger server error - custom error page (not YSOD)

### Security Verification
- [ ] Anonymous user cannot access `/StoreManager` - redirects to login
- [ ] Visitor user cannot access `/StoreManager` - access denied
- [ ] HTTPS enforced (if configured)
- [ ] Anti-forgery tokens present in forms

---

## Browser-Specific Issues

### JavaScript Console Errors
**None** | **Minor** | **Major**
[If any, copy exact error message here]

### Layout/Rendering Issues
**None** | **Minor** | **Major**
[Describe any CSS/layout problems]

### Performance Observations
- Home page load: [X] seconds
- Catalog page load: [X] seconds
- Checkout completion: [X] seconds

---

## Test Result Summary

**Overall Status**: âœ… PASS | âš ï¸ PASS WITH ISSUES | ❌ FAIL

**Total Checks**: [X passed / Y total]

**Critical Issues Found**: [Number]
**Minor Issues Found**: [Number]

---

## Issues Log

### Issue #1: [Brief title]
**Severity**: Critical | High | Medium | Low
**Category**: Authentication | UI | Performance | Data
**Steps to Reproduce**:
1. [Step 1]
2. [Step 2]

**Expected**: [What should happen]
**Actual**: [What happened]
**Console Errors**: