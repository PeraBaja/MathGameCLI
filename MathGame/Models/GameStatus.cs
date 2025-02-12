using System.Net.Sockets;

namespace MathGame.Models;

public enum Difficulty {
        easy = 10,
        medium = 50,
        hard = 100
}

class GameStatus{
    Difficulty _difficulty;
    int _correctAnswers;

    public Operator? Operator;
    public Difficulty Difficulty { get => _difficulty; }
    public int CorrectAnswers { get => _correctAnswers; set {
        if(value < 0) return;
        _correctAnswers = value;
    }} 
    public void SelectDifficulty(string userOption)
    {
        if (!Enum.TryParse<Difficulty>(userOption, ignoreCase: true, out _difficulty))
        {
            throw new Exception("Non existent difficulty: " + userOption);
        }
    }
    public List<string> Answers = [];
}