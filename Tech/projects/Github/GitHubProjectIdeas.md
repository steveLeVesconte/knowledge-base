2 prompts

_________________________________________________________________
> *suggest 5 github projects with an opportunity to show good skills. Not so much to be the actual project I will use, but to give me an idea of the kind of project that works.*

Edit

Here are 5 project types that would effectively demonstrate modern development skills to potential employers:

## 1. Legacy System Modernization Showcase

**Project**: "Enterprise CRUD Modernization" Take a typical legacy pattern (like a Windows Forms inventory app with direct database calls) and rebuild it as:

- .NET 8 Web API with clean architecture
- React/Vue frontend
- Containerized with Docker
- Deployed to Azure with Infrastructure as Code
- Include both versions in the repo to show the transformation

**Why it works**: Directly addresses your background while showing you can modernize. Perfect narrative for interviews.

## 2. Multi-Service Integration Platform

**Project**: "Document Processing Pipeline" Build a system that:

- Accepts document uploads (Azure Blob Storage)
- Processes them through multiple services (OCR, validation, classification)
- Uses Azure Service Bus for messaging
- Includes monitoring/logging with Application Insights
- Has a status dashboard

**Why it works**: Shows distributed systems thinking, cloud-native patterns, and real-world complexity without being overly ambitious.

## 3. Developer Productivity Tool

**Project**: "Infrastructure Drift Detective" Create a tool that:

- Scans Azure resources using REST APIs
- Compares actual configuration against Bicep templates
- Reports configuration drift
- Suggests remediation steps
- Includes GitHub Actions workflow for scheduled checks

**Why it works**: Solves a real DevOps problem, shows API integration, demonstrates understanding of Infrastructure as Code challenges.

## 4. Modern Data Processing Application

**Project**: "Cost Optimization Analyzer" Build an application that:

- Ingests Azure billing data via APIs
- Processes data with Azure Functions
- Stores results in Cosmos DB
- Provides recommendations via web dashboard
- Uses managed identity for security

**Why it works**: Combines data processing, serverless computing, modern database patterns, and security best practices.

## 5. CI/CD Demonstration Platform

**Project**: "Deployment Pattern Showcase" Create a simple application but focus on the deployment story:

- Multiple environments (dev/staging/prod)
- Blue-green deployments
- Feature flags implementation
- Automated testing at multiple levels
- Infrastructure provisioning and teardown
- Complete GitOps workflow

**Why it works**: Shows you understand the full software development lifecycle beyond just coding.

## Key Success Patterns

Each project should:

- **Start simple, evolve complexity** (show your thought process through commit history)
- **Include thorough documentation** (README, architecture decisions, lessons learned)
- **Demonstrate testing strategies** (unit, integration, end-to-end)
- **Show monitoring/observability** (logs, metrics, health checks)
- **Use modern security practices** (managed identities, least privilege, secrets management)

The goal isn't to build the next unicorn startup - it's to show you can think through real-world problems with modern tools and patterns. Each repository becomes a conversation starter that lets you demonstrate depth of understanding beyond what any certification can show.

__________________________________________________________





> ***Evaluate these project suggestions:***
> 
> ***A logic app to automatically delete azure resource based on tags as a cost cutting tool for students. Any resource older than its sell by date gets automatically deleted each night.***
> 
> ***An educational project designed to make OAuth Connect (might not be the right term) as visible as possible. Not sure of the modality, log dashboards specifically to show auth sequences in action.***
> 
> ***A collection of ai prompt sets for specific purposes such as "make a deployment ps1 and bicep": * a prompt * curated context like file list, project structure, Program.cs files (whatever the prompt needs for context efficiency) Is this even a good candidate for a GitHub repo?***
> 
> ***Can I find a canonical legacy mvc project that would work for a display of upgrade skills to migrate to .NET Core and promote to cloud. Would this be a reasonable way to demo?***

Edit

Let me evaluate each of these against the "demonstrates modern development skills to employers" criteria:

## 1. Resource Auto-Delete Logic App ⭐⭐⭐⭐

**Strong project.** This hits several sweet spots:

**Pros:**

- Solves a real, common problem (runaway Azure costs)
- Shows understanding of Azure governance and cost management
- Demonstrates Logic Apps, Azure Resource Manager APIs, tagging strategies
- Natural progression: start with Logic App, then show how you'd rebuild as Azure Function for more control
- Perfect for Infrastructure as Code deployment story

**Considerations:**

- Include robust safety mechanisms (dry-run mode, exclusion lists, manual approval workflows)
- Add monitoring/alerting for what gets deleted
- Document the governance strategy, not just the technical implementation

## 2. OAuth/OpenID Connect Visualization ⭐⭐⭐⭐⭐

**Excellent educational project.** This is actually brilliant:

**Why it works:**

- OAuth/OIDC is poorly understood by many developers but critical for modern apps
- Shows deep understanding of security concepts
- Could include multiple flows (authorization code, client credentials, device flow)
- Great candidate for interactive dashboards showing token exchange, claims, etc.
- Demonstrates both frontend and backend skills

**Implementation ideas:**

- Build sample apps that authenticate through different providers
- Real-time visualization of token flows
- Include common misconfiguration examples and their fixes
- Perfect for blog posts/documentation that establish your expertise

## 3. AI Prompt Collections ⭐⭐

**Interesting but risky as a standalone GitHub project:**

**Issues:**

- Prompts without context aren't very valuable to others
- Hard to demonstrate traditional development skills
- Could look like you're trying to replace coding with AI

**Better approach:**

- Integrate this into other projects as documentation
- Show how you use AI to accelerate development, not replace understanding
- Include the generated code AND your modifications/improvements
- Frame it as "AI-Assisted Development Workflow" within a larger project

## 4. Legacy MVC Migration Demo ⭐⭐⭐⭐⭐

**Perfect for your situation.** This directly addresses your background:

**Canonical options:**

- Microsoft's MusicStore sample (if still available)
- Contoso University sample
- NorthWind Traders implementations
- Or create your own "typical enterprise app" with common patterns

**Migration story to showcase:**

- .NET Framework MVC → .NET 8
- Entity Framework 6 → EF Core
- Windows Auth → Azure AD integration
- On-premises → Azure App Service
- IIS → containerized deployment
- Include performance comparisons, modernization decisions

**Why this works exceptionally well:**

- Directly leverages your experience
- Shows you can evaluate and improve existing code
- Demonstrates migration strategy thinking
- Perfect interview conversation starter: "Walk me through your approach to this migration"

## Refined Recommendations

**Start with #4 (Legacy Migration)** - this plays to your strengths while showing modern skills.

**Add #1 (Resource Cleanup)** - shows cloud-native thinking and practical value.

**Consider #2 (OAuth Visualization)** if you want to establish expertise in a specific area.

**Skip #3 as standalone** - but integrate AI assistance documentation into the other projects.

The legacy migration project is particularly powerful because it tells your story: "I understand these old systems because I built them, and I can modernize them because I understand both worlds." That narrative directly addresses potential employer concerns about your background being outdated.