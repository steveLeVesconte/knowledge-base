# Context Coherence Analysis Meta-Prompt

## AI Task

Analyze the attached context files and prompt for coherence, contradictions, and relevance. Provide a structured assessment with clear GO/NO-GO recommendation.

## Analysis Framework

### 1. CONTRADICTIONS (Critical - Must Fix)

Identify any conflicting information across context files:

**Format:**

```
❌ CONTRADICTION FOUND
Files: [file1.md] vs [file2.md]
Issue: [specific contradiction]
Impact: [how this will confuse output]
Fix: [which file to trust / how to resolve]
```

**Examples of contradictions:**

- Different target frameworks (.NET 8 vs .NET 9)
- Conflicting naming conventions
- Incompatible architectural decisions
- Contradictory requirements

### 2. RELEVANCE (High Priority - Should Fix)

Assess each context file's relevance to the prompt:

**Format:**

```
📊 RELEVANCE ASSESSMENT

High Relevance (90-100%):
├── [filename]: [why directly relevant]
└── [filename]: [why directly relevant]

Medium Relevance (50-89%):
├── [filename]: [relevant sections] / [irrelevant sections]

Low Relevance (<50%):
└── [filename]: [mostly irrelevant, consider removing]
```

**Question to answer:** "If I removed this file, would the output quality suffer?"

### 3. COHERENCE (Medium Priority - Nice to Fix)

Evaluate whether context tells a unified story:

**Format:**

```
✅ COHERENCE CHECK

Strong coherence:
- All files support same architectural direction
- Consistent terminology across files
- Clear progression/relationship between files

Weak coherence:
- [filename] uses different terminology than others
- [filename] addresses different abstraction level
- Unclear how [file1] and [file2] relate
```

### 4. GAPS (Advisory - May Impact Output)

Identify information the prompt seems to expect but isn't provided:

**Format:**

```
⚠️ POTENTIAL GAPS

Missing context that might improve output:
├── [what's missing]: [why it might matter]
└── [what's missing]: [why it might matter]
```

### 5. REDUNDANCY (Low Priority - Efficiency Issue)

Note significant overlapping information:

**Format:**

```
ℹ️ REDUNDANCY DETECTED

[file1.md] and [file2.md] both cover:
- [overlapping topic]
Impact: Minor - increases token usage but doesn't hurt quality
```

## Final Assessment

### GO / NO-GO Recommendation

**🛑 NO-GO - Fix before proceeding:**

- [ ] Critical contradictions found
- [ ] Multiple low-relevance files (>30% of context)
- [ ] Major gaps in required information

**⚠️ PROCEED WITH CAUTION:**

- [ ] Minor contradictions that should be clarified
- [ ] Some low-relevance content but not critical
- [ ] Weak coherence but not contradictory

**✅ GO - Context is solid:**

- [ ] No contradictions
- [ ] All files highly relevant (>70%)
- [ ] Strong coherence
- [ ] No critical gaps

### Recommended Actions

**If NO-GO:**

1. [Specific file to remove/modify]
2. [Specific contradiction to resolve]
3. [Critical context to add]

**If CAUTION:**

1. [Optional improvements]
2. [Nice-to-have additions]

**If GO:**

- Proceed with prompt as-is
- Consider these minor optimizations: [list]

## Context Summary

**Total context size:** [X files, ~Y tokens] **Relevance density:** [High/Medium/Low] **Contradiction count:** [number] **Overall quality:** [Excellent/Good/Needs Work/Poor]

**Bottom line:** [One sentence - should I use this context or fix something first?]