
Roy Osherove Pattern - Early TDD Era (~2000s)

AddToCart_NewAlbum_CreatesNewCartItem
│         │        │
│         │        └─ Expected Behavior (outcome)
│         └─ Scenario (initial condition/context)
└─ Method Under Test (what you're testing)


## Step 1: Start with the Public API (Contract)

**What can external code do with ShoppingCart?**
**First principle:** Test the public interface, not implementation details.






## Step 2: Identify State Transitions

**Shopping cart has implicit states based on database contents:**
```
Empty Cart → Has Items → Empty Cart (cycle)
                ↓
           Has Multiple Items
                ↓
           Different Quantities
```

**Key insight:** Cart state lives in the **database**, not the object.


## Step 3: For Each Method, Ask "What Are the Scenarios?"

### Method 1: `GetCart(HttpContextBase context)`

**Question:** "Under what different conditions might someone get a cart?"
```
Scenario 1: First time (no session)
Scenario 2: Returning visitor (session exists)
Scenario 3: Authenticated user

```



## The "Am I Testing Enough?" Checklist

**For any class, ask:**

1. ✅ **Is every public method tested?** (Except trivial getters/setters)
2. ✅ **Is every major branch tested?** (if/else, switch cases)
3. ✅ **Are calculations verified?** (Money, counts, dates)
4. ✅ **Are state transitions tested?** (Empty → Full → Empty)
5. ✅ **Are edge cases covered?** (Zero, null, empty)

**If yes to all 5, you have good integration coverage.**


## The "Am I Testing Enough?" Checklist

**For any class, ask:**

1. ✅ **Is every public method tested?** (Except trivial getters/setters)
2. ✅ **Is every major branch tested?** (if/else, switch cases)
3. ✅ **Are calculations verified?** (Money, counts, dates)
4. ✅ **Are state transitions tested?** (Empty → Full → Empty)
5. ✅ **Are edge cases covered?** (Zero, null, empty)

**If yes to all 5, you have good integration coverage.**



|Criteria|Rating|Notes|
|---|---|---|
|**Clarity**|A+|Intent obvious from name|
|**Consistency**|A+|Mechanical pattern|
|**Scannability**|A+|Test Explorer groups well|
|**Documentation**|A|Names read like specs|
|**Failure Messages**|A+|Self-diagnosing|
|**Team Adoption**|A+|Easy to follow|

