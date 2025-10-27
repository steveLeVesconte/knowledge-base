

### Session Context


**Session success pattern:**

- prompt output was useful and seemed accurate
- one odd issue in prompt output:
  prompt output claimed that:
  
```
Suggested Improvements
1. Add One Key Context File (High Priority)
Missing: CheckoutController.cs - You reference it in prompt.md but didn't attach it. This is critical because:
```
  
but the file is still visible in your input list

I want to know the root cause of this inconsistency.  Was it because too much context was provided?





---

## 🤖 AI ANALYSIS REQUESTED (The AI will fill this out)

Analyze the conversation focusing on the "problem zone" identified above. Diagnose what caused the deterioration in session quality.

### Failure Root Cause Breakdown

For each category, provide a percentage estimate of how much it contributed to the failures (should total ~100%):

**1. Nature of the Problem (Technical/Environmental Constraints)** [___%] - The problem itself was inherently difficult to solve given unknown constraints

- Was the root cause discoverable from early symptoms?
- Could ANY prompt have succeeded before discovering the constraint?
- Evidence from the conversation:

**2. Context Dilution (Session Degradation)**  
[___%] - The long conversation caused the AI to lose track of important information

- Evidence of forgetting previous decisions:
- Evidence of contradicting earlier solutions:
- Signs of context window pressure:

**3. Missing Critical Context (Prompter Could Have Provided)** [___%] - Information that would have prevented failures if stated upfront

- What specific information was missing:
- When could the prompter have provided this:
- How it would have changed outcomes:

**4. AI Performance Issues (Random/Inconsistent Behavior)** [___%] - Genuine AI limitations, hallucinations, or unexplained failures

- Specific instances of ignoring explicit constraints:
- Unexplained variance in solution quality:
- True randomness vs. predictable confusion:

### Failure Sequence Analysis

Map the cascade of failures in the problem zone:

**Attempt #1** [Exchange #__]

- What was tried:
- Why it failed:
- What context was available:
- What context was missing:

**Attempt #2** [Exchange #__]

- What was tried:
- Why it failed:
- Did this repeat a previous mistake? [YES/NO]

**Attempt #3** [Exchange #__] [Continue for major attempts...]

**Breaking Point:** [Identify the exchange where it became clear the approach wasn't working]

### The Smoking Gun

**Primary culprit for the failure cascade:** [One clear sentence: e.g., "The AI didn't know localStorage was unavailable, and you didn't state this constraint until after 8 failures"]

**Could this have been prevented?** [YES/NO and explain how]

**Was starting a fresh session the answer?** [YES/NO and explain why/why not]

---

## 💡 PREVENTION STRATEGY

### For Your Next Session

**Red flags to watch for:** 🚩 [Specific warning sign from this session] 🚩 [Another warning sign] 🚩 [Another warning sign]

**When you see these flags, immediately:**

- [Specific action to take]
- [Another action to take]

**Upfront context checklist for similar problems:**

```
- [ ] Environment clearly stated (e.g., "Claude artifacts", "Node.js app", etc.)
- [ ] Known constraints explicitly listed (e.g., "No browser storage", "Must use X library")
- [ ] Relevant error messages pasted in full, not paraphrased
- [ ] Reference to similar working examples in the project
- [ ] [Add session-specific item based on what was missing]
```

### Session Management Rules

**Fresh session trigger:** [Define specific condition based on this experience, e.g., "After 3 consecutive failures on the same error, start fresh with full context reset"]

**Context refresh strategy:** [How to reorient mid-session if you notice degradation]

---

## 🎓 SKILL DEVELOPMENT TAKEAWAY

### Responsibility Split

**Prompter responsibility: [___%]** Specific examples where better prompting would have helped:

1. [Example from conversation]
2. [Example from conversation]

**AI limitation: [___%]** Cases where AI genuinely couldn't know or performed poorly:

1. [Example from conversation]
2. [Example from conversation]

**Discovery process: [___%]** Cases where the root cause had to be found through trial and error:

1. [Example from conversation]

### Your #1 Improvement Action

[One concrete, specific action you'll take in your next session based on this analysis]

### The Most Valuable Lesson

[One sentence that captures what you learned from this failure pattern]


- Total prompts: [rough estimate]
- Root cause discovered: [when/how]
- Tests performed: [what you tried that failed]