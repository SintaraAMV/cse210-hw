using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private List<string> _achievements;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _achievements = new List<string>();
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine("🌟 Eternal Quest Program 🌟");
        Console.WriteLine("============================\n");
        
        LoadGoals(); // Cargar metas existentes
        
        while (true)
        {
            DisplayPlayerInfo();
            DisplayMenu();
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": DisplayAchievements(); break;
                case "7": 
                    Console.WriteLine("\n👋 Goodbye! Keep pursuing your eternal quest!");
                    SaveGoals();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"📊 Score: {_score} points | Level: {_level}");
        Console.WriteLine($"🎯 Goals: {_goals.Count} total ({GetCompletedGoals()} completed)");
        Console.WriteLine("========================================");
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. View Achievements");
        Console.WriteLine("  7. Quit");
        Console.Write("Select a choice: ");
    }

    private int GetCompletedGoals()
    {
        int count = 0;
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete()) count++;
        }
        return count;
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\n📝 No goals have been created yet.");
            return;
        }
        
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\n🎯 Create New Goal");
        Console.WriteLine("==================");
        Console.WriteLine("Goal Types:");
        Console.WriteLine("  1. Simple Goal (One-time completion)");
        Console.WriteLine("  2. Eternal Goal (Never ending)");
        Console.WriteLine("  3. Checklist Goal (Multiple times with bonus)");
        Console.Write("Select goal type: ");
        
        string type = Console.ReadLine();
        
        Console.Write("Goal Name: ");
        string name = Console.ReadLine();
        
        Console.Write("Description: ");
        string description = Console.ReadLine();
        
        Console.Write("Points per completion: ");
        int points = int.Parse(Console.ReadLine());
        
        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("✅ Simple Goal created!");
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("♾️  Eternal Goal created!");
                break;
            case "3":
                Console.Write("Target completions: ");
                int target = int.Parse(Console.ReadLine());
                
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("📋 Checklist Goal created!");
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }
        
        CheckAchievements();
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\n⚠️  No goals available to record.");
            return;
        }
        
        Console.WriteLine("\nSelect a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
        
        Console.Write("Enter goal number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal selectedGoal = _goals[index - 1];
            
            if (selectedGoal.IsComplete())
            {
                Console.WriteLine("✅ This goal is already completed!");
                return;
            }
            
            selectedGoal.RecordEvent();
            int pointsEarned = selectedGoal.GetPoints();
            _score += pointsEarned;
            
            // Bonus para ChecklistGoal
            if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                int bonus = checklistGoal.GetBonus();
                _score += bonus;
                Console.WriteLine($"🎉 BONUS! +{bonus} points for completing the goal!");
                DisplayRandomQuote();
            }
            
            Console.WriteLine($"\n✅ Event recorded! +{pointsEarned} points");
            Console.WriteLine($"🏆 Total score: {_score}");
            
            CheckLevelUp();
            CheckAchievements();
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"\n🎉 LEVEL UP! You are now Level {_level}!");
        }
    }

    private void CheckAchievements()
    {
        // Logro por primera meta
        if (_goals.Count == 1 && !_achievements.Contains("Goal Starter"))
        {
            _achievements.Add("Goal Starter");
            Console.WriteLine("\n🏅 ACHIEVEMENT UNLOCKED: Goal Starter!");
        }
        
        // Logro por 1000 puntos
        if (_score >= 1000 && !_achievements.Contains("Point Master"))
        {
            _achievements.Add("Point Master");
            Console.WriteLine("\n🏅 ACHIEVEMENT UNLOCKED: Point Master!");
        }
        
        // Logro por completar 5 metas
        if (GetCompletedGoals() >= 5 && !_achievements.Contains("Consistent Achiever"))
        {
            _achievements.Add("Consistent Achiever");
            Console.WriteLine("\n🏅 ACHIEVEMENT UNLOCKED: Consistent Achiever!");
        }
    }

    private void DisplayAchievements()
    {
        Console.WriteLine("\n🏆 Your Achievements:");
        if (_achievements.Count == 0)
        {
            Console.WriteLine("No achievements yet. Keep working on your goals!");
        }
        else
        {
            foreach (string achievement in _achievements)
            {
                Console.WriteLine($"  ✓ {achievement}");
            }
        }
    }

    private void DisplayRandomQuote()
    {
        string[] quotes = {
            "The secret of getting ahead is getting started. - Mark Twain",
            "Don't watch the clock; do what it does. Keep going. - Sam Levenson",
            "The only way to do great work is to love what you do. - Steve Jobs",
            "Believe you can and you're halfway there. - Theodore Roosevelt",
            "It always seems impossible until it's done. - Nelson Mandela"
        };
        
        Random random = new Random();
        Console.WriteLine($"\n💫 \"{quotes[random.Next(quotes.Length)]}\"");
    }

    public void SaveGoals()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine($"Score:{_score}");
                writer.WriteLine($"Level:{_level}");
                
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("💾 Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        try
        {
            if (!File.Exists("goals.txt"))
            {
                Console.WriteLine("No saved data found.");
                return;
            }
            
            string[] lines = File.ReadAllLines("goals.txt");
            _goals.Clear();
            
            foreach (string line in lines)
            {
                if (line.StartsWith("Score:"))
                {
                    _score = int.Parse(line.Split(':')[1]);
                }
                else if (line.StartsWith("Level:"))
                {
                    _level = int.Parse(line.Split(':')[1]);
                }
                else if (line.Contains(":"))
                {
                    string[] parts = line.Split(':');
                    string type = parts[0];
                    string[] data = parts[1].Split(',');
                    
                    switch (type)
                    {
                        case "SimpleGoal":
                            bool isComplete = bool.Parse(data[3]);
                            _goals.Add(new SimpleGoal(data[0], data[1], 
                                int.Parse(data[2]), isComplete));
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(data[0], data[1], 
                                int.Parse(data[2])));
                            break;
                        case "ChecklistGoal":
                            _goals.Add(new ChecklistGoal(data[0], data[1], 
                                int.Parse(data[2]), int.Parse(data[4]), 
                                int.Parse(data[3]), int.Parse(data[5])));
                            break;
                    }
                }
            }
            
            Console.WriteLine($"📂 Loaded {_goals.Count} goals. Score: {_score}");
            CheckAchievements();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading: {ex.Message}");
        }
    }
}