# Known Limitations - Phase 1 Baseline

## Issues to Address During Migration

### Self-Assigned Role Selection
**Impact**: Security - no access control
**Resolution**: Phase 5 - Modern Authentication & External Identity Providers
**Scope Decision**: Security issue intrinsic to authentication modernization - must fix as part of planned Phase 5 work

### HTTPS Not Configured  
**Impact**: Required for Azure deployment, affects cookie security behavior
**Resolution**: Phase 2a - Azure Migration
**Scope Decision**: Infrastructure requirement for cloud deployment - must fix as prerequisite for Phase 2


-------------------------------------------

## Tutorial App Limitations (Deferred - Out of Scope)

### Placeholder Images for All Albums
**Current**: All albums use single `placeholder.gif` (100x75)
**Scope Decision**: Feature enhancement - not addressing until Phase 5 completion
**Rationale**: Migration project scope limited to platform modernization and cloud deployment. New features deferred to potential Phase 5a (Feature Enhancements) or post-migration work.

### No Artist or Genre Detail Pages
**Current**: Artist and genre names display as text only (not clickable)
**Scope Decision**: Feature enhancement - not addressing until Phase 5 completion
**Rationale**: Migration project scope limited to platform modernization and cloud deployment. New features deferred to potential Phase 5a (Feature Enhancements) or post-migration work.

### External Footer Link Opens in Same Tab
**Current**: "Built with ASP.NET MVC 5" link lacks `target="_blank" rel="noopener noreferrer"`
**Additional note**: Microsoft redirects this URL to ASP.NET Core marketing page (not MVC 5 docs)
**Scope Decision**: UI/UX improvement - not addressing until Phase 5 completion
**Rationale**: 
- Cosmetic issue unrelated to migration objectives
- Link destination controlled by Microsoft, not this application
- Does not impact functional parity or cloud deployment success

**Potential Phase 5+ action**: Update footer to "Built with ASP.NET" (framework-agnostic) or remove link entirely

### External Link on Login Page Opens in Same Tab
**Current**: "See this article for details..." link lacks `target="_blank" rel="noopener noreferrer"`
**Additional note**: Microsoft redirects this URL to ASP.NET Core marketing page (not promised OAuth setup details)
**Scope Decision**: UI/UX improvement - not addressing until Phase 4 view migration
**Rationale**: 
- Cosmetic issue unrelated to migration objectives
- Link destination controlled by Microsoft, not this application
- Does not impact functional parity or cloud deployment success

**Phase 4 action**: Remove sentence and link during view migration - external OAuth setup instructions no longer relevant after Phase 5 authentication modernization

### Non-Responsive UI Design
**Current**: Fixed-width layout optimized for desktop (approximately 950px-1200px viewport width)
**Impact**: Unusable on mobile devices, degraded experience on ultra-wide monitors (tablets not tested)
**Scope Decision**: UI modernization - deferred until Phase 5 completion, then re-evaluate priority
**Rationale**: Implementing responsive design requires Bootstrap upgrade (3.4.1 → 5.x) and CSS refactoring across all views. This work introduces regression risk during platform migration. Mobile responsiveness does not affect cloud deployment success or functional parity with current application. Defer to post-Phase 5 evaluation.

## Data Quality Issues (Not Addressing)

### Order.Total Column Unpopulated
**Current**: Order table `Total` column stores `0.00` for all orders
**Impact**: None - no UI displays order totals, OrderDetail records contain actual line item data
**Root Cause**: Tutorial app doesn't calculate/store order totals (only line items)
**Discovered**: Phase 1a smoke testing (2025-10-08) - validated checkout workflow in database
**Scope Decision**: Data quality issue in tutorial app - not addressing during migration
**Rationale**: 
- No functional impact (UI doesn't display aggregate totals)
- Order detail records contain complete transaction data
- Fixing would be feature enhancement, not migration work
- Falls under tutorial app limitations (defer post-Phase 5)

**Migration consideration**: This field will migrate to Azure SQL as-is. If future reporting needs order totals, calculate from OrderDetails at query time or add as Phase 5+ enhancement.



### Shopping Cart Tied to Session, Not User Identity

**Current**: Shopping cart state persists in browser session regardless of user login/logout

**Technical Evidence** (Phase 1a smoke testing, 2025-10-08):
- Shopping cart stored in `Session["ShoppingCart"]`
- Session tied to `ASP.NET_SessionId` cookie (persists across login/logout)
- User identity tied to `.AspNet.ApplicationCookie` (deleted on logout)
- **Result**: Cart persists when auth cookie deleted

**Cookie Behavior Observed**:

Login State:
ASP.NET_SessionId: cesovvgptpucjuocszrufds (present)
.AspNet.ApplicationCookie: Jb8SNoK1-Ks... (present)
Logout State:
ASP.NET_SessionId: cesovvgptpucjuocszrufds (STILL PRESENT ← cart data)
.AspNet.ApplicationCookie: (DELETED ← user identity gone)

**Implications**:
- User A adds items, logs out → User B logs in → sees User A's cart
- **Privacy concern**: Shared computer scenarios
- **Security concern**: No user-to-cart isolation

**Resolution Timeline**: **MUST fix in Phase 5** (not optional)

**Why Phase 5 Forces Fix**:
- **Phase 5a (External OAuth)**: OAuth providers require user-specific session isolation
- **Phase 5b (Identity Enhancement)**: Claims-based architecture assumes user-owned carts
- **Phase 5c (Security Hardening)**: Security audit will flag shared cart as vulnerability

**Phase 5 Implementation Required**:
1. Add `UserId` foreign key to `Cart` or `CartItem` table
2. Associate cart with authenticated user on login
3. Clear or archive cart on logout
4. Implement anonymous cart → user cart migration on first login
5. Add cart ownership validation in controllers

**Alternative Approaches**:
- **Option A (Simplest)**: Clear cart on logout (lose items, but secure)
- **Option B (Better UX)**: Associate anonymous cart with user on login, clear on logout
- **Option C (Best UX)**: Persistent user carts across devices (requires database storage)

**Estimated Phase 5 Effort**: 4-8 hours (database schema, migration, controller logic, testing)


### [Phase 5] Shopping Cart Not User-Isolated

**Technical Evidence - Session Management Testing** (Phase 1a, 2025-10-08):

**Cookie Behavior on Logout**:

Before Logout:
.AspNet.ApplicationCookie: Present (user identity)
ASP.NET_SessionId: cesovvgp... (session/cart)
After Logout:
.AspNet.ApplicationCookie: DELETED ✅
ASP.NET_SessionId: cesovvgp... (STILL PRESENT) ❌
Cart items: STILL PRESENT ❌

**Root Cause Confirmed**: 
- ASP.NET authentication (OWIN) and session state are independent systems
- Logout clears authentication but NOT session
- Cart stored in session, so persists across user logout/login cycles

**Security Test Result**:
- User A logs in, adds items to cart, logs out
- User B logs in on same browser
- User B sees User A's cart items ❌ CONFIRMED

**Session Timeout Behavior**:
- Default: 20 minutes with sliding expiration
- No explicit `<sessionState>` config in web.config
- Session persists across logout until explicit timeout or browser close


### HTTPS Not Configured  
**Impact**: Required for Azure deployment, affects cookie security behavior
**Resolution**: Phase 2a - HTTPS Validation (first task before database migration)
**Scope Decision**: Infrastructure requirement for cloud deployment - must fix as prerequisite for Phase 2

**Phase 1 Testing Constraint**: 
- All Phase 1 smoke testing performed over HTTP (localhost:port)
- Cookie security attributes (`Secure`, `SameSite=Strict`) not testable in Phase 1
- OWIN cookie authentication configured but only tested over HTTP


**Phase 2 Discovery Risk**:
- **OWIN authentication cookies**: May behave differently over HTTPS (secure flag enforcement)
- **ApplicationCookie**: Primary authentication cookie must work over HTTPS
- **ExternalCookie**: Configured in OWIN but unused (external providers disabled) - verify no interference
- **Session state**: HTTPS-only cookies could break shopping cart if misconfigured
- **Mixed content**: External resources (CDNs for jQuery, Bootstrap) must use HTTPS
- **Anti-forgery tokens**: Must validate correctly over HTTPS POST requests

**Mitigation Strategy**:
1. Phase 2a begins with dedicated HTTPS smoke test (gate for rest of phase)
2. All Phase 1 smoke tests repeated in Phase 2a over HTTPS
3. Verify OWIN middleware configuration compatible with Azure App Service HTTPS
4. Document any HTTPS-specific configuration changes discovered
5. Update baseline metrics to reflect HTTPS performance characteristics (expected: <5% overhead)



### Empty Cart Checkout Allowed
**Current**: User can click "Checkout" and proceed through order form with empty cart
**Impact**: 
- Minor UX confusion (why allow checkout with no items?)
- Can create $0.00 orders with zero items in database
**Root Cause**: No client-side or server-side validation of cart state before checkout
**Discovered**: Phase 1a smoke testing (2025-10-10) - empty cart edge case
**Scope Decision**: Tutorial app limitation - not addressing during migration
**Rationale**: 
- Low-severity UX issue unrelated to migration objectives
- Functional parity requires preserving this behavior through Phase 4
- Fix would be feature enhancement (business logic validation)
- Falls under tutorial app limitations (defer post-Phase 5)

**Migration consideration**: Phase 4 regression testing must verify empty cart checkout still works identically (even though behavior is suboptimal).

**Potential Phase 5+ fix**: 
- Add cart item count check before rendering Checkout button
- Add server-side validation in `CheckoutController.AddressAndPayment()`
- Display friendly "Your cart is empty" message with link back to catalog





---

## Scope Control Policy (See CONTRIBUTING.md)
