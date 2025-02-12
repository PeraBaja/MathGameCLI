using System.Net;

namespace MathGame.Models;

class Operation{

    public readonly int FirstNumber;
    public readonly int SecondNumber;
    public readonly Operator Operator;
    public int UserAnswer;
    public readonly int Result;
    public bool IsUserAnswerCorrect(int userAnswer) {
        UserAnswer = userAnswer; 
        return Result == userAnswer;

    } 
    public Operation(GameStatus gameStatus, Operator _operator) {
        Operator = _operator;
        FirstNumber = new Random().Next((int)gameStatus.Difficulty);
        SecondNumber = new Random().Next((int)gameStatus.Difficulty);
        while(true) {
            try
            {
                Result = _operator.Calculate(FirstNumber, SecondNumber);
                break;
            }
            catch{ 
                FirstNumber = new Random().Next((int)gameStatus.Difficulty);
                SecondNumber = new Random().Next((int)gameStatus.Difficulty);
            }
        }
    }
    public override string ToString() {
        char status = (Result == UserAnswer) ? '✓' : 'X';
        return $"{FirstNumber} {Operator.Symbol} {SecondNumber} = {UserAnswer} {status}";
    }
}