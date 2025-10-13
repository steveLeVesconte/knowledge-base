
Yes, once again, you have shown the gob-smacking power of the fill-in-the-blank prompt structure. Which begs the question, if I was missing that powerful technique, what other important technique am I missing? AI Task: Please review my past month's prompts (is this too big), and identify important techiques that I am not using.

I'll search through your past month's conversations to analyze your prompting patterns and identify techniques you might be missing.

Relevant chats

4 results

Let me continue gathering more data from your recent conversations:

Relevant chats

Let me search for specific prompting techniques and patterns in your conversations:

Relevant chats

2 results

Relevant chats

2 results

Now let me analyze what I'm seeing and provide you with the findings:

# 🔍 Prompting Techniques Analysis: What You're Missing

Based on reviewing your recent conversations, here's what I found:

## **What You're Already Doing Well:**

✅ **Fill-in-the-blank structured templates** (discovered in this session) ✅ **Hierarchical organization** (you naturally use nested structures) ✅ **Context provision** (you provide project files, standards) ✅ **Iterative refinement** (you're comfortable with multi-turn conversations) ✅ **Meta-prompting** (you think about thinking about prompts)

---

## **🎯 Missing Techniques (High-Value Opportunities)**

### **[1. Few-Shot Examples]**

**What it is:** Providing 2-3 concrete examples of desired output format before asking for new content

**What you're doing instead:** Describing what you want in words

**Example from your chats:**

```
Your approach:
"Generate a README section that has curb appeal for employers"

Few-shot approach:
"Generate a README section. Here are examples of the style I want:

Example 1 (Good):
'This project demonstrates advanced .NET migration patterns including...'

Example 2 (Bad - too generic):
'This is a .NET project for learning purposes...'

Now write the Overview section in the 'Good' style."
```

**Why you're missing it:** You have strong domain knowledge and assume Claude understands your quality bar. But Claude interprets "professional" or "curb appeal" differently than you do.

**Impact:** Medium-High. Few-shot examples would reduce your iteration cycles from 2-3 to 1-2.

**Search evidence:** "curb-appeal for the audience" - descriptive but no examples provided

---

### **[2. Constraint-First Prompting]**

**What it is:** Leading with what NOT to do, before saying what TO do

**What you're doing instead:** Positive instructions only, discovering constraints through iteration

**Example pattern:**

```
Your approach:
"Create a migration strategy"
→ Gets comprehensive strategy
→ "Too detailed, focus on 2 providers only"

Constraint-first:
"Create a migration strategy. Constraints:
- Maximum 2 external auth providers
- No implementation details
- Focus on decision rationale only
Now create the strategy."
```

**Why you're missing it:** Your thinking is additive ("what do I need to include?") rather than subtractive ("what must I exclude?")

**Impact:** High. This directly addresses your "front-load constraints" insight from earlier.

**Search evidence:** Multiple instances of "too comprehensive" feedback requiring scope-down iterations

---

### **[3. Role/Persona Assignment]**

**What it is:** Explicitly telling Claude what role/expertise to adopt

**What you're doing instead:** Implicit expertise assumptions

**Example:**

```
Your approach:
"Review this code for best practices"

Role-assigned:
"You are a senior .NET architect reviewing junior developer code for a production migration. Focus on: reliability, maintainability, Azure-specific patterns. Review this code."
```

**Why you're missing it:** You're treating Claude as a general assistant rather than asking it to adopt specific expert lenses.

**Impact:** Medium. Would get more targeted, opinionated responses aligned with your actual needs.

**Search evidence:** You describe YOUR expertise ("40+ year developer") but don't assign Claude a complementary role

---

### **[4. Negative Examples]**

**What it is:** Showing examples of what you DON'T want

**What you're doing instead:** Only positive examples or descriptions

**Example:**

```
Your approach:
"Write professional documentation"

With negative examples:
"Write professional documentation.

❌ DON'T write like this:
'This project uses advanced techniques for modern development...' (too vague)

✅ DO write like this:
'This project migrates a .NET Framework 4.8 WCF application to .NET 9 minimal APIs...' (specific)
"
```

**Why you're missing it:** Easier to recognize bad output than specify good output, but you're not leveraging this.

**Impact:** Medium. Particularly valuable for subjective quality criteria like "curb appeal" or "professional tone."

**Search evidence:** You give feedback like "too generic" but don't encode that as negative examples upfront

---

### **[5. Chain-of-Thought Prompting]**

**What it is:** Asking Claude to show its reasoning before answering

**What you're doing instead:** Requesting direct outputs

**Example:**

```
Your approach:
"Which approach is better: A or B?"

Chain-of-thought:
"Compare approaches A and B. First, list the evaluation criteria that matter for this use case. Then score each approach on those criteria. Finally, recommend one with justification."
```

**Why you're missing it:** You're comfortable thinking through tradeoffs yourself, but you could get better analysis by making Claude show its work.

**Impact:** Low-Medium. Most valuable for complex decisions, less critical for artifact generation.

**Search evidence:** You ask direct "which is better?" questions without requesting structured analysis first

---

### **[6. Output Format Specification]**

**What it is:** Explicitly defining the structure of the response (not just content)

**What you're doing:** Strong on templates, weak on ad-hoc format specs

**Example:**

```
Your approach:
"Explain the tradeoffs"

Format-specified:
"Explain the tradeoffs in this format:
## Approach A
Pros: [bullet list]
Cons: [bullet list]
Best for: [scenario]

## Approach B
[same structure]

## Recommendation
[one paragraph]"
```

**Why you're partially missing it:** You excel at this for retrospectives (fill-in-blank), but don't apply it to exploratory questions.

**Impact:** Low-Medium. You already get structured outputs, this would just make them more consistent.

**Search evidence:** Your discussion questions get prose responses; you could request specific formats

---

### **[7. Context Hierarchy Declaration]**

**What it is:** Explicitly stating which context files are most/least important

**What you're doing instead:** Providing all context without priority signals

**Example:**

```
Your approach:
[Attaches 5 files]
"Generate migration script"

With hierarchy:
[Attaches 5 files]
"Generate migration script using these files:

PRIMARY (must follow): coding-standards.md, current-architecture.cs
SECONDARY (reference if relevant): deployment-patterns.md
TERTIARY (background only): project-history.md

Prioritize consistency with PRIMARY files."
```

**Why you're missing it:** You assume Claude will figure out which context matters most.

**Impact:** Low. Only matters when providing 3+ context files.

**Search evidence:** Your "Tier 1/2/3 context" thinking exists but isn't explicitly communicated in prompts

---

### **[8. Success Criteria Upfront]**

**What it is:** Defining "done" before generating, not after evaluating

**What you're doing instead:** Generate → evaluate → iterate

**Example:**

```
Your approach:
"Create README"
→ Reviews output
→ "Needs more technical detail"

Success-criteria-first:
"Create README that meets these criteria:
□ Employer can understand project value in 30 seconds
□ Includes specific tech stack versions
□ Avoids implementation details
□ Professional tone (not tutorial)

Mark each criterion when complete."
```

**Why you're missing it:** You know quality when you see it, but don't articulate it before generation.

**Impact:** High. This is essentially your "front-load constraints" insight, applied to quality rather than scope.

**Search evidence:** Your "success criteria" example shows you KNOW this pattern, but you don't use it in actual prompts

---

## **📊 Impact Summary**

|Technique|Impact|Effort|Priority|
|---|---|---|---|
|Constraint-First|High|Low|🔥 Immediate|
|Success Criteria Upfront|High|Low|🔥 Immediate|
|Few-Shot Examples|Med-High|Medium|⭐ Next session|
|Negative Examples|Medium|Low|⭐ Next session|
|Role/Persona|Medium|Low|📅 Long-term|
|Context Hierarchy|Low|Low|📅 Long-term|
|Chain-of-Thought|Low-Med|Medium|📅 Long-term|
|Output Format Spec|Low-Med|Low|📅 Long-term|

---

## **🎯 Immediate Action Plan**

**Next 3 prompts, try this template:**

markdown

```markdown
# [Task Description]

## Constraints (what NOT to do):
- [Constraint 1]
- [Constraint 2]

## Success Criteria (done when):
□ [Criterion 1]
□ [Criterion 2]
□ [Criterion 3]

## Context Priority:
PRIMARY: [most important files/info]
SECONDARY: [nice to have]

## Desired Output Format:
[Specify structure if not using template]

Now: [specific request]
```

**This combines your top 4 missing techniques in one reusable pattern.**

---

Want me to create a "Prompt Enhancement Checklist" artifact that you can reference before submitting complex prompts?