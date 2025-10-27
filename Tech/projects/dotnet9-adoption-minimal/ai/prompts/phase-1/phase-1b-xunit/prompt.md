# Task Description: create an xUnit test outline including a list of xUnit test in a hierarchical list to use in this project


## Persona: as a Lead Developer coaching a junior Developer

## Primary Focus (what TO do):
- create a list of tests (within categories) to include as I add unit testing to this project.  

## Boundaries (what NOT to do):
- go overboard - suggest too much.  We want respectable process - not extreme DOD process. 

  
  

## Success Criteria (done when):
- A list with names of tests and enough code context or architecture context to allow me to begin work on the test.  The list should propose goldilocks coverage - not overboard but respectable - and enough to be useful during stage 4 when everything (including the tests) breaks.
  
- Business logic tests (cart operations, order calculations, checkout workflows) - these survive migration
- Minimal auth behavior tests (role checks, cart migration on login) - these provide Phase 1-3 value even if they break in Phase 4
- Defer integration tests for OWIN pipeline specifics until after Phase 4
## Critical Workflows to Test:
1. **Shopping Cart Operations**
   - Add/remove items
   - Calculate totals with price variations
   - Session persistence across requests

2. **Checkout Flow**
   - Promo code validation ("FREE")
   - Order creation with correct user context
   - Cart-to-order conversion

3. **Authentication Impact**
   - Cart migration on login
   - Role-based access (Admin vs Visitor)
   - Anonymous cart persistence

4. **Catalog Operations (Admin)**
   - CRUD operations for Albums/Artists/Genres
   - Validation rules (price range, required fields)
     
## Test Organization Request:
Group tests into these xUnit test classes:
- **ShoppingCartTests** (Add, Remove, Total calculations)
- **CheckoutTests** (Promo code, order creation, validation)
- **CatalogAdminTests** (Album/Artist/Genre CRUD with validation)
- **AuthenticationTests** (Cart migration on login, role checks) 
     
    ## Note: while the _test structure_ survives, Phase 4 will require:

- Updating test setup (mock HttpContext/session for .NET Core)
- Changing EF 6 mocking to EF Core in-memory database
- Updating Identity-related test doubles
     
     
     
     
     
## Context Priority:

PRIMARY: 
   Assume no existing tests. xUnit is being added fresh and empty.
   Assume that I am not vary knowledgeable about test coverage and you will need to decide what is useful and professional coverage for this project to (a) be useful to me as developer and (b) look professional.
   

- project files
	-- project-outline.md
	
	
- subset of code files as clues:
    -- project-outline.md
    -- models.md
	-- AccountController.cs
	-- AccountViewModels.cs
	-- CheckoutController.cs
	-- HomeController.cs
	-- IdentityConfig.cs
	-- IdentityModels.cs
	-- ManageController.cs
	-- ManageViewModels.cs
	-- MusicStoreEntities.cs
	-- ShoppingCartController.cs
	-- ShoppingCartRemoveViewModel.cs
	-- ShoppingCartViewModel.cs
	-- Startup.Auth.cs
	-- Startup.cs
	-- StoreController.cs
	-- StoreManagerController.cs
	-- Web.config
	

        
SECONDARY:
project stage: Phase 1: just finished smoke tests, ready to start adding xUnit and tests.
Note: since phase-4 includes "ASP.NET Identity to Core Identity", it is unclear to me how much OWIN related code survives, so I am unsure how unit tests in that zone help. Perhaps they help a little in phase-1 and phase-2.
I am a Software Dev
30+ experience: MVC, .NET, C#, SQL, APIs, HTML, CSS, XML, Banking, Government, Incentives
Out of work for 2 years
Refreshing skill set to include more Core and cloud
The target organization is the size and scope of a regional bank or a state government agency who might judge the project in job interviews



- partial file tree:
  

├───MvcMusicStore
│   ├───App_Start
│   ├───bin
│   │   └───roslyn
│   ├───Content
│   │   └───Images
│   ├───Controllers
│   ├───fonts
│   ├───Migrations
│   ├───Models
│   ├───obj
│   ├───Properties
│   ├───Scripts
│   │   └───App
│   ├───ViewModels
│   └───Views
│       ├───Account
│       ├───Checkout
│       ├───Home
│       ├───Manage
│       ├───Shared
│       ├───ShoppingCart
│       ├───Store
│       └───StoreManager
├───[ADD NEW XUNIT TEST PROJECT HERE]