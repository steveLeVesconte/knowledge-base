# Diagnose Error on Test

## Primary Focus (what TO do)
Help me understand and fix this issue with an inegration test.

## The Error Message:
-----------------------
>	MvcMusicStore.dll!MvcMusicStore.Models.ShoppingCart.CreateOrder(MvcMusicStore.Models.Order order) Line 125	C#

 	MvcMusicStore.Tests.dll!MvcMusicStore.Tests.Integration.Business.CheckoutIntegrationTests.CreateOrder_WithMultipleDifferentItems_CreatesMultipleOrderDetails() Line 109	C#

MvcMusicStore.Tests.dll!MvcMusicStore.Tests.Integration.Business.CheckoutIntegrationTests.CreateOrder_WithMultipleDifferentItems_CreatesMultipleOrderDetails() Line 109
	at D:\certification\projects\legacy-to-modern-dotnet-migration\legacy-to-modern-dotnet-migration\MvcMusicStore.Tests\Integration\Business\CheckoutIntegrationTests.cs(109)



+		$exception	{"Object reference not set to an instance of an object."}	System.NullReferenceException
-----------------------


## More Context:
Note, this error message only happens at line 25 of MvcMusicStore.dll!MvcMusicStore.Models.ShoppingCart.CreateOrder(MvcMusicStore.Models.Order order) when called from the test app, not when called from the non-test app.

I note that at that moment cartItems collection contains very different things depeding on whether called from test or real.

from test app:
-		cartItems	Count = 3	System.Collections.Generic.List<MvcMusicStore.Models.Cart>
-		[0]	{MvcMusicStore.Models.Cart}	MvcMusicStore.Models.Cart
		Album	null	MvcMusicStore.Models.Album
		- 

from real app:
+		cartItems	Count = 2	System.Collections.Generic.List<MvcMusicStore.Models.Cart>
{System.Data.Entity.DynamicProxies.Cart_C8969BF26DA24CFB05E4A418F1FC5A403BDB19ABF56171497B12D8A371D36FA7}
{System.Data.Entity.DynamicProxies.Album_9B91826B7A3EBA68992AD51254E5F29958D19815D13466FCDC2A930AA321B30C}

I think this means that the DatabaseFixture.cs is insufficient.

I note that the SampleData.cs of the real app creates List<Album>
while DatabaseFixture.cs does not.  I think this is part of the issue.




## Success Criteria (done when):
- A suggested fix for the exception that prevents the test from running
  
- An explanation of the root cause of the exception

## Context Priority:
PRIMARY: 
DatabaseFixture.cs
SampleData.cs
ShoppingCart.cs
models.md

SECONDARY: 
app.config_of_MvcMusicStore.Tests
folders.md
MusicStoreEntities.cs
packages.config_of_MvcMusicStore
packages.config_of_MvcMusicStore.Tests
ShoppingCartController.cs
Startup.cs
Web.config_of_MvcMusicStore

- Code with professional standards expected in a regional bank
- Integration test best practices for Entity Framework 6



Now: diagnose the exception