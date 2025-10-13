# 🔍 Failed Session Diagnostic Analysis

Use this prompt when a coding session started well but deteriorated into repeated failures.

---

## 📥 YOUR INPUT (Fill this out before submitting)

### Session Context

**Total session length:** [e.g., "45 exchanges" or "~80,000 tokens estimated"]

**Session success pattern:**

- First ~[X] exchanges: ✅ Working well
- Starting around exchange #[Y]: ⚠️ Things went sideways
- Continued struggling through exchange #[Z]

### The Problem Zone (Where it got chaotic)

**What I was trying to accomplish:** [Describe the task/feature you were working on when failures started]

**Approximate exchange/prompt numbers where failures occurred:** [e.g., "Prompts #23-35" or "The last 12 exchanges"]

**What symptom made me realize it was failing:** [e.g., "Same error kept appearing" or "Solutions stopped working" or "Started contradicting itself"]

**What the root cause turned out to be:** [e.g., "localStorage isn't available in Claude artifacts" or "Was using wrong API version" or "Still don't know"]

**When I discovered the root cause:** [e.g., "After 10 failed attempts" or "In the final exchange" or "After the session ended"]

### Optional Context

**Any environment constraints I didn't mention upfront:** [e.g., "Didn't specify it was for Claude artifacts" - leave blank if not applicable]

**Information I had but didn't provide:** [e.g., "Had error logs but only described them" - leave blank if not applicable]

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