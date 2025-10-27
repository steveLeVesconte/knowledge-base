The prompt in prompt.md delivered excellent output with one flaw.

It did not use a helper method similar to that shown in "example" below.

Treat the example as a conceptual example, not necessary the exact code needed.

AI Task: rewrite the prompt in prompt.md but incorporating the use of a helper method  or helper methods for  WithFreshContext

<example>
Consider extracting a helper method for consistent fresh context usage:
```csharp
protected T WithFreshContext(Func query)
{
    using (var context = new MusicStoreEntities())
    {
        return query(context);
    }
}
// Usage:
var cartItem = WithFreshContext(db => 
    db.Carts.SingleOrDefault(c => c.CartId == _testCartId));
</exmaple>