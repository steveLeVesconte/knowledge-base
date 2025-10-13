Quick check: context health?


-------------------------

Quick session health check - are we approaching context limits or showing signs of degradation?


-------------

Session status check:
- Token budget health?
- Context retention quality?
- Should we continue or start fresh?


---

Discussion:
Meta-Session Health Check Prompts
You're asking two smart questions:

Can I check if the session is dying without killing it?
Are meta-prompts "safe" from dilution effects?


⚡ Ultra-Brief Session Health Check
The minimal viable prompt (use any time):
Quick session health check - are we approaching context limits or showing signs of degradation?
Why this works:

~15 tokens (negligible cost)
No complex requirements that could confuse a degraded session
Direct yes/no answer possible
Tests if Claude can still self-assess (meta-awareness is early casualty of degradation)

What to watch for in the response:

✅ Confident, specific answer = Session healthy
⚠️ Vague, generic response = Possible early degradation
🚩 Contradicts recent context = Degradation likely
🚩 Asks for info you just provided = Serious degradation


🎯 Slightly More Detailed Check (Still Safe)
Session status check:
- Token budget health?
- Context retention quality?
- Should we continue or start fresh?
Cost: ~30 tokens
Benefit: Gets specific metrics if available
Safe because: Simple bullet structure, no complex reasoning required

🧠 Are Meta-Prompts Safe from Dilution?
Short answer: Mostly YES, but with caveats
Why Meta-Prompts Are Relatively Safe:

Self-assessment is trained behavior - Claude is explicitly trained to evaluate its own context state
Simple task - Doesn't require deep reasoning over conversation history
Low token cost - Brief prompts don't meaningfully add to pressure
Can reveal degradation - Even a degraded response tells you something

The Ironic Problem:
If the session is badly degraded, the meta-analysis itself might be unreliable.
Think of it like asking a drunk person "Are you sober enough to drive?"

Mild impairment → Accurate self-assessment ✅
Severe impairment → Unreliable self-assessment ⚠️

Practical Guidelines:
Meta-prompts are SAFE when:

✅ Session is under 60% token budget
✅ You're checking preventatively (not after obvious problems)
✅ Prompt is simple and direct
✅ You use it to decide "continue vs. fresh session"

Meta-prompts are RISKY when:

⚠️ Session is already showing symptoms (repeated mistakes, forgetting)
⚠️ You're past 80% token budget
⚠️ You're asking for complex retrospective analysis
⚠️ You trust the answer despite contradictory evidence


📊 Token Math Reality Check
Your concern about dilution is valid but overestimatable:
Typical session capacity: ~180,000 tokens effective working space
ActionToken Cost% of BudgetBrief health check~150.008%Detailed status~300.017%Full analysis prompt~5000.28%Another code generation cycle~3,0001.7%
The real dilution risk isn't the meta-prompt itself - it's that you're spending tokens on assessment instead of progress when you could just start fresh.

🎯 Recommended Strategy
Preventative Checks (No Risk):
Every ~15 exchanges in a long session:
Quick check: context health?
If response is confident and specific → Keep going
If response is vague or seems off → Start fresh
Reactive Check (When You Notice Issues):
DON'T ask the session to analyze itself - it might be too degraded
DO just start a fresh session and optionally analyze the old one separately
The rule: If you're asking because you suspect problems, the answer is always "start fresh"

💡 The Meta-Paradox
Here's the truth:

Asking "should we continue?" costs ~20 tokens
Starting fresh costs 0 tokens from your old budget
If you're worried enough to ask, you should probably just start fresh

But yes, brief health checks are safe and useful for preventing degradation rather than diagnosing it after it's obvious.

✅ Your Takeaway Prompt
Save this for periodic checks:
Session health: token budget status and context quality? Continue or fresh session?
Use it:

✅ Every 15-20 exchanges in long sessions
✅ Before starting a complex new feature
✅ When switching topics significantly

Don't use it:

❌ After you already see repeated failures
❌ When you're past 80% tokens
❌ More than once every 10 exchanges (adds up)

The check itself won't kill your session, but if you feel you need to ask, that's often your answer.
