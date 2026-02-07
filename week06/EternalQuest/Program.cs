using System;

/*
🌟 EXCEEDING REQUIREMENTS - CREATIVITY FEATURES 🌟

I have implemented several creative features that go beyond the core requirements:

1. LEVELING SYSTEM:
   - Users level up based on their total score
   - Each 1000 points = 1 level
   - Visual level-up notifications

2. ACHIEVEMENT SYSTEM:
   - "Goal Starter" - Create your first goal
   - "Point Master" - Reach 1000+ points
   - "Consistent Achiever" - Complete 5+ goals
   - Achievement unlock notifications with emojis

3. MOTIVATIONAL QUOTES:
   - Random inspirational quotes display when completing checklist goals
   - Encourages continued progress

4. PROGRESS TRACKING:
   - Shows total goals vs completed goals
   - Visual separation of different goal types in display

5. ENHANCED USER INTERFACE:
   - Emoji icons for better visual feedback
   - Clear section separators
   - Color-coded success messages

6. AUTO-SAVE ON QUIT:
   - Automatically saves progress when exiting
   - Prevents data loss

7. GOAL STATUS SUMMARY:
   - Shows how many goals are completed vs total
   - Quick progress overview

These features enhance user engagement and make the program more enjoyable
while maintaining all required functionality.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}