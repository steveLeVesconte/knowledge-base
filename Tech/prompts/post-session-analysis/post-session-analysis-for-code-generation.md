
## ⚙️ Code Generation Session Review

## 📊 Session Resource Consumption

**Token Budget Status:**
- Estimated tokens used: ~[X] of ~200,000 available
- Capacity consumed: [X]% 
- Budget health: [HEALTHY <25% | MODERATE 25-60% | ELEVATED 60-80% | CRITICAL >80%]

**Context Window Pressure:**
- Conversation exchanges: [X]
- Average tokens per exchange: ~[X]
- Context density: [LOW | MODERATE | HIGH | SATURATED]
  - LOW: Plenty of room for complexity
  - MODERATE: Normal working range
  - HIGH: Approaching limits, simplify if possible
  - SATURATED: Risk of context loss, consider fresh session

**Rework Overhead:**
- Clean exchanges (first-try success): [X]
- Refinement exchanges (iterations): [X]
- Rework ratio: [X]% (Target: <20%)
- Efficiency rating: [OPTIMAL <10% | GOOD 10-20% | ACCEPTABLE 20-35% | WASTEFUL >35%]

**Conversation Health Indicators:**
- 🟢 **Safe to continue** - All metrics healthy, no concerns
- 🟡 **Monitor closely** - [specific metric] approaching limits
- 🟠 **Consider wrapping up** - [specific concern] showing strain
- 🔴 **Start fresh session** - [critical issue] compromising quality

**Over-Optimization Risk Assessment:**
- Unnecessary refinement cycles detected: [count]
- Diminishing returns threshold: [reached/not reached]
- **Verdict:** [LEAN - stopped at good enough | BALANCED - appropriate polish | OVER-OPTIMIZED - chasing perfection]

**Reality Check:**
[One-line assessment: e.g., "You used 3% of available tokens with 15% rework - this session had plenty of headroom, no optimization needed" OR "You're at 72% capacity with high context density - wrap up soon or start fresh"]


**Build Scope:**
- Module/Component: [name]
- Architecture layer: [feature | shared | core]
- Dependencies added: [count]
- Files generated: [count]

**Context Adherence:**
- Style guide compliance: [full | partial | ignored areas]
  - Violations: [specific examples or "none"]
- Project patterns matched: [consistent | mixed]
  - Example: [where you stayed/deviated from established patterns]
- Standards drift: [none | minor | broke conventions]

**Progressive Build Quality:**
- Starting context provided: [full project state | partial | minimal]
- Context retained across prompts: [all | lost X after prompt Y]
- Dependency awareness: [caught all | missed X]
- Import statement accuracy: [correct | needed fixes]

**Code Quality Indicators:**
- TypeScript typing: [strict | loose | any abuse]
- Separation of concerns: [clean | some mixing | tangled]
- Reusability: [high | medium | copy-paste detected]
- Test generation: [included | partial | skipped]

**Prompt Efficiency Analysis:**
✅ **Most effective prompt:**
   - Example: "Prompt #3: 'Generate UserService following AuthService pattern, inject HttpClient, handle errors consistently'"
   - Result: [one-shot success | minor tweaks needed]

⚠️ **Costly iterations:**
   - Prompt #[X]: [what went wrong]
   - Rework cost: [Y] follow-ups to fix
   - Root cause: [unclear requirements | missed context | style mismatch]

**Token Economics:**
- Code tokens generated: ~[X]
- Explanation/comments: ~[X]
- Rework tokens (regenerations): ~[X]% overhead
- Most expensive component: [which] ([reason])

**Pattern Recognition:**
🎯 **Successful prompt structures:**
   1. [e.g., "Explicit pattern reference: 'Follow XComponent's structure'"]
   2. [e.g., "Stating non-functional requirements: 'Keep under 200 lines'"]

🎯 **Context management wins:**
   - [e.g., "Provided project tree structure upfront = better imports"]

🎯 **What caused rework:**
   - [e.g., "Not specifying reactive vs template-driven forms"]
   - [e.g., "Assumed DI patterns instead of stating them"]

**Session Score: [0-100]**
- Standards compliance (30pts): [score]
- First-attempt usability (25pts): [score]
- Context accuracy (25pts): [score]
- Efficiency (20pts): [score]

**Next Session Strategy:**
- Pre-provide: [what context to include upfront]
- Prompt template: [pattern that worked best]
- Avoid: [specific mistake to not repeat]