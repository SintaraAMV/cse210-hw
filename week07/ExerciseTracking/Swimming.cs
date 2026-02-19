public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthKm = 0.05; // 50 metros = 0.05 km

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapLengthKm;

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;

    public override double GetPace() => Minutes / GetDistance();
}