public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Constructor para cargar desde archivo
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Override de métodos abstractos
    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}