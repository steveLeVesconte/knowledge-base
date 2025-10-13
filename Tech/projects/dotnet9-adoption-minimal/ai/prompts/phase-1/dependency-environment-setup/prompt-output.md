# Environment Setup Guide

## Development Environment Requirements

### Required Software

#### .NET Framework Development

- **Visual Studio 2019 or later** (Community, Professional, or Enterprise)
    - Workloads required:
        - ASP.NET and web development
        - .NET desktop development
    - Individual components:
        - .NET Framework 4.8 SDK
        - .NET Framework 4.8 targeting pack

#### Database

- **SQL Server LocalDB** (included with Visual Studio)
    - Minimum version: SQL Server 2016 LocalDB
    - Instance name: `MSSQLLocalDB`
    - Two databases will be created automatically:
        - `MvcMusicStoreUsers001` (ASP.NET Identity)
        - `MvcMusicStore001` (Music Store data)

#### Version Control

- **Git** 2.30 or later
- **GitHub account** with repository access

#### Optional (Recommended)

- **SQL Server Management Studio (SSMS)** 18.0 or later
    - For database inspection and troubleshooting
- **Fiddler** or **Browser DevTools**
    - For monitoring HTTP requests and debugging Ajax calls

---

## Initial Setup Steps

### 1. Clone Repository

```bash
git clone https://github.com/steveLeVesconte/legacy-to-modern-dotnet-migration.git
cd legacy-to-modern-dotnet-migration
```

### 2. Restore NuGet Packages

**Via Visual Studio:**

1. Open `MvcMusicStore.sln`
2. Right-click solution → **Restore NuGet Packages**
3. Wait for package restoration to complete

**Via Command Line:**

```bash
nuget restore MvcMusicStore.sln
```

### 3. Build Solution

**Via Visual Studio:**

1. Build → **Rebuild Solution**
2. Verify build succeeds (warnings about vulnerable packages are expected and documented)

**Via Command Line:**

```bash
msbuild MvcMusicStore.sln /t:Rebuild /p:Configuration=Debug
```

### 4. Initialize Databases

Databases are created automatically on first run via Entity Framework Code First with the `SampleData` initializer configured in `Global.asax.cs`.

**First run will:**

- Create LocalDB instances if they don't exist
- Run Entity Framework migrations
- Seed initial data (genres, albums, roles)
- Create Admin and Visitor roles via `Startup.cs`

### 5. Run Application

**Via Visual Studio:**

1. Press **F5** (Debug) or **Ctrl+F5** (Run without debugging)
2. Application should launch in default browser
3. Default URL: `http://localhost:59188/`

---

## Verification Checklist

After setup, verify the following:

- [ ] **Build succeeds** with only expected NuGet vulnerability warnings (documented below)
- [ ] **Application starts** without errors
- [ ] **Home page loads** successfully
- [ ] **Database connection works** (browse to `/Store` - catalog should display)
- [ ] **Identity system works** (register a new user account)
- [ ] **Role creation successful** (Admin and Visitor roles exist in AspNetRoles table)

---

## Known Issues and Warnings

### Security Vulnerabilities in Dependencies

The rebuild process produces the following **expected** NuGet package vulnerability warnings:

```
NU1902: jQuery 3.3.1 - moderate severity
NU1903: jQuery.Validation 1.17.0 - high severity  
NU1903: Microsoft.AspNet.Identity.Owin 2.2.2 - high severity
NU1903: Microsoft.Owin 4.0.0 - high severity (2 advisories)
NU1903: Microsoft.Owin.Security.Cookies 4.0.0 - high severity
NU1903: Newtonsoft.Json 11.0.1 - high severity (2 advisories)
```

**Status:** These are **documented legacy issues** to be addressed in Phase 4 (platform migration). Do **NOT** update packages at this stage - maintaining version consistency is critical for baseline capture.

### Browser Compatibility Alert

**CRITICAL:** Phase 1a smoke testing **must** verify jQuery/Ajax functionality across browsers. The legacy jQuery 3.3.1 implementation may exhibit compatibility issues with modern browsers, particularly:

- Shopping cart Ajax updates (`RemoveFromCart.js`)
- Client-side validation
- Dynamic content loading

**Action Required:** Document any browser-specific issues in `docs/phase-1/smoke-test-checklist.md` during Phase 1a.

---

## Database Connection Strings

Located in `Web.config`:

```xml
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=MvcMusicStoreUsers001;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
  <add name="MusicStoreEntities" 
       connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=MvcMusicStore001;Integrated Security=SSPI;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Two separate databases:**

1. **MvcMusicStoreUsers001** - ASP.NET Identity (users, roles, claims)
2. **MvcMusicStore001** - Application data (albums, artists, genres, orders, carts)

---

## Project Structure Overview

```
MvcMusicStore/
├── App_Start/           # Application configuration (routes, bundles, filters)
├── Controllers/         # MVC controllers
├── Models/              # Domain models and EF context
├── Views/               # Razor views
├── Scripts/             # JavaScript (jQuery, validation, custom)
├── Content/             # CSS and images
├── Migrations/          # Entity Framework migrations
└── ViewModels/          # View-specific models

MvcMusicStore.Tests/
└── Controllers/         # Unit tests (MSTest - to be converted to xUnit in Phase 1b)
```

---

## Authentication System Overview

**Technology Stack:**

- **ASP.NET Identity 2.2.2** (user/role management)
- **OWIN 4.0.0** (authentication pipeline)
- **Cookie Authentication** (primary method)

**Configured Roles:**

- `Admin` - Store management access
- `Visitor` - Standard user access

**External Authentication Providers:**

- Code present but **commented out** in `Startup.Auth.cs`
- Providers available: Microsoft, Twitter, Facebook, Google
- **Status:** Not active - to be implemented in Phase 5

**Key Files:**

- `Startup.cs` - OWIN startup, role initialization
- `Startup.Auth.cs` - Authentication middleware configuration
- `Models/IdentityModels.cs` - Identity context and user model
- `App_Start/IdentityConfig.cs` - User manager, sign-in manager

---

## Troubleshooting

### Build Failures

**Symptom:** "Could not find a part of the path to Roslyn compilers"

```
Solution: Clean solution and restore NuGet packages
1. Build → Clean Solution
2. Delete bin/ and obj/ folders
3. Restore NuGet packages
4. Rebuild
```

**Symptom:** "The type or namespace 'Owin' could not be found"

```
Solution: Ensure all NuGet packages restored successfully
1. Check NuGet Package Manager → Installed Packages
2. Verify Microsoft.Owin.* packages present
3. Restore packages if missing
```

### Runtime Errors

**Symptom:** Database connection fails

```
Verification steps:
1. SQL Server LocalDB installed? Check: sqllocaldb info
2. Instance running? Start: sqllocaldb start MSSQLLocalDB
3. Connection string correct in Web.config?
```

**Symptom:** "A network-related or instance-specific error occurred"

```
Solution: 
1. Stop LocalDB: sqllocaldb stop MSSQLLocalDB
2. Delete instance: sqllocaldb delete MSSQLLocalDB
3. Create fresh: sqllocaldb create MSSQLLocalDB
4. Restart application (databases will recreate)
```

**Symptom:** Role creation fails on startup

```
Check:
1. Identity database created? (MvcMusicStoreUsers001)
2. AspNetRoles table exists?
3. Startup.cs CreateRoles() executing without errors?
4. Check Application Insights or debug output for exceptions
```

### Ajax/JavaScript Issues

**Symptom:** Shopping cart remove button doesn't work

```
Debugging steps:
1. Open browser DevTools → Console (check for JavaScript errors)
2. Network tab → Verify Ajax POST to /ShoppingCart/RemoveFromCart
3. Check Scripts/App/RemoveFromCart.js for jQuery compatibility issues
4. Test in multiple browsers (Chrome, Firefox, Edge)
```

---

## Next Steps

After successful environment setup:

1. **Complete Phase 1a tasks** (see `work-breakdown.md`)
2. **Execute smoke tests** thoroughly - document any browser issues
3. **Proceed to Phase 1b** (testing framework expansion)

---

## Environment Validation Command Sequence

Run these commands to verify environment readiness:

```bash
# 1. Verify Git installation
git --version

# 2. Verify LocalDB
sqllocaldb info MSSQLLocalDB

# 3. Clone repository (if not done)
git clone https://github.com/steveLeVesconte/legacy-to-modern-dotnet-migration.git
cd legacy-to-modern-dotnet-migration

# 4. Restore packages
nuget restore MvcMusicStore.sln

# 5. Build
msbuild MvcMusicStore.sln /t:Rebuild /p:Configuration=Debug

# 6. Verify build output
# Should show: "2 succeeded, 0 failed, 0 skipped"
```

If all steps succeed, environment is ready for Phase 1 work.