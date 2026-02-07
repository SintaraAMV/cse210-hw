using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Métodos abstractos (polimorfismo)
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    // Método virtual con implementación por defecto
    public virtual string GetDetailsString()
    {
        string completionMark = IsComplete() ? "[X]" : "[ ]";
        return $"{completionMark} {_shortName} ({_description})";
    }

    // Getters
    public string GetName() => _shortName;
    public int GetPoints() => _points;
}