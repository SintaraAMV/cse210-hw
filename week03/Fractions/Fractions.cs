public class Fraction
{
    private int _top;
    private int _bottom;

    // 1) 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 2) wholeNumber/1
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // 3) top/bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = (bottom == 0) ? 1 : bottom; // evita división por cero
    }

    public int GetTop() => _top;
    public void SetTop(int top) => _top = top;

    public int GetBottom() => _bottom;
    public void SetBottom(int bottom) => _bottom = (bottom == 0) ? 1 : bottom;

    public string GetFractionString() => $"{_top}/{_bottom}";

    public double GetDecimalValue() => (double)_top / _bottom;
}
