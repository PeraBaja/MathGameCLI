namespace MathGame.Models;
class Operator
{
    public string Name { get; }
    public char Symbol { get; }
    public Func<int, int, int> Calculate { get; }
    public Operator(string name, char symbol, Func<int, int, int> calculate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));

        Name = name;
        Symbol = symbol;
        Calculate = calculate ?? throw new ArgumentNullException(nameof(calculate));
    }
}