using MathGame.Models;
namespace MathGame.Controllers;

class OperatorController {
    public Operator[] operators; 
    public OperatorController() {
        Operator addition = new(
            name: "addition",
            symbol: '+',
            calculate: (int a, int b) => a + b
        );
        Operator substraction = new(
            name: "substraction",
            symbol: '-',
            calculate: (int a, int b) => a - b
        );
        Operator division = new(
            name: "division",
            symbol: '/',
            calculate: Divide
        );
        Operator multiplication = new(
            name: "multiplication",
            symbol: 'x',
            calculate: (int a, int b) => a * b
        );
        Operator exponenciation = new(
            name: "exponenciation",
            symbol: '^',
            calculate: (int a, int b) => a ^ b
        );
        operators = [addition, substraction, division, multiplication]; 
    }
    static int Divide(int dividend, int divisor)
    {
        if (0 <= divisor && divisor >= 100)
        {
            throw new ArgumentException("The divisor should be between 0 and 100");
        }
        if (dividend % divisor != 0)
        {
            throw new Exception("The division is not exact.");
        }
        return dividend / divisor;
    }

    public Operator GetRandom()
    {
        int index = new Random().Next(operators.Length);
        return operators[index];
    }
    public string[] GetNames() =>
        operators.Select(op => op.Name).ToArray();
    
    public Operator? GetOperatorByName(string value) {
        if(value == "any") return null;
        else if(!GetNames().Contains(value)) throw new Exception("The operation doesn't exist");
        return Array.Find(operators, op => op.Name == value);
    }
}