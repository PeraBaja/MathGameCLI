
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

    public static string[] GetNames(IEnumerable<Operator> operators) =>
        operators.Select(op => op.Name).ToArray();

    public static Operator GetRandom(IEnumerable<Operator> operators) =>
        operators.ElementAt(new Random().Next(operators.Count()));

    public override string ToString()
    {
        return Name;
    }
}