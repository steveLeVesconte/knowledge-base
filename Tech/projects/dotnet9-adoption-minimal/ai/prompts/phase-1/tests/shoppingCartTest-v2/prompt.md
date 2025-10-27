# Create a Integration Tests for Shopping Cart

## Primary Focus (what TO do)
Create Integration Tests for ShoppingCart in a way that is compatible with sharing reusable test infrastructure with other planed integration tests.
Specifications:
- use shared infrastructure such as;
	-- Collection Fixtures (For Multiple Test Classes) employing minimal seed data robust enough to serve for all planned integration tests.
	-- use shard fakes: (more if needed)
		-- TestHttpContext.cs
		-- TestSessionState.cs
		-- TestUser.cs


## Boundaries (what NOT to do):

- Do not go to extremes as in DOD standards.  
- Do not exceed the normal good practice expected in a regional bank

## Success Criteria (done when):
- ~ 12 integration tests for ShoppingCart appear professional for the audience of hiring managers.
- the integration tests work properly.
- the shared infrastructure lays a foundation for more planned integration tests 


## Context Priority:
PRIMARY: 
- app.config_of_MvcMusicStore.Tests
- folders.md
- Global.asax.cs
- models.md
- MusicStoreEntities.cs
- packages.config_of_MvcMusicStore
- packages.config_of_MvcMusicStore.Tests
- PROJECT-LOG-excerpt.md
- ShoppingCartController.cs
- Startup.cs
- Web.config_of_MvcMusicStore



SECONDARY: 
- code with professional standards that would be expected in a regional bank.


## Output Format:
c# xUnit tests and related infrastructure code compatible with Framework 4.8

Now: generate code for the shoppingCart integrations tests and shared testing infrastructure and any related methods of the test.
If some important context is missing, say so.

