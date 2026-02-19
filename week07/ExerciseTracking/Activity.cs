using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Métodos abstractos que serán implementados por las clases derivadas
    public abstract double GetDistance();  // en kilómetros
    public abstract double GetSpeed();     // en kph
    public abstract double GetPace();      // minutos por kilómetro

    // Método concreto que utiliza los métodos abstractos (polimorfismo)
    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min): " +
               $"Distance {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, " +
               $"Pace: {GetPace():F2} min per km";
    }

    // Propiedad protegida para acceso en clases derivadas
    protected int Minutes => _minutes;
}