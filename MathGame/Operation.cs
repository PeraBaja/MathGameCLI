using System.Net;

namespace MathGame;

class Operation{

    public int FirstNumber;
    public int SecondNumber;

    public readonly int Result; 
    public Operation(GameStatus gameStatus, Operator _operator) {
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
}