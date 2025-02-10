using System.Net.Sockets;

namespace MathGame;

public enum Difficulty {
        easy = 10,
        medium = 50,
        hard = 100
}

class GameStatus{
    Difficulty _difficulty;
    int _correctAnswers;
    public Difficulty Difficulty { get => _difficulty; }
    public int CorrectAnswers { get => _correctAnswers; set {
        if(value < 0) return;
        _correctAnswers = value;
    }} 
    public void SelectDifficulty()
    {
        string[] difficulties = Enum.GetNames<Difficulty>();
        Console.Write($"Select the dificulty level by typing: ");
        foreach(string difficulty in difficulties){
            Console.Write($"{difficulty} -");
        }
        Console.WriteLine("");
        string userOption = Console.ReadLine() ?? "";
        Console.Clear();

        if (!difficulties.Contains(userOption.ToLower()))
        {
            Console.WriteLine( "The selected dificulty level doesn't exist. Please select another.");
            SelectDifficulty();
            return;
        }
        _difficulty = Enum.Parse<Difficulty>(userOption, ignoreCase: true);
    }
    public List<string> Answers = [];
}