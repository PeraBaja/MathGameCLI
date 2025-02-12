
using MathGame.Controllers;
using MathGame.Models;

namespace MathGame.Views;

class GameView(GameController gameController, OperatorController operatorController) {

    GameController _gameController = gameController;
    static int GetUserAnswer()
    {
        int userAnswer;
        while(true){
            
            if(!int.TryParse(Console.ReadLine() ?? "", out userAnswer))
                Console.WriteLine("The answer should be an integer number. Please Try again");
            else break;
        }
        return userAnswer;
    }

    public void Display()
    {
        _gameController.PlayNewGame(operatorController);
        foreach(var operation in _gameController.Operations) {
            Console.Write($"{operation.FirstNumber} {operation.Operator.Symbol} {operation.SecondNumber} = ");
            int userAnswer = GetUserAnswer();

            if(operation.IsUserAnswerCorrect(userAnswer)){
                Console.WriteLine('✓');
            }
            else Console.WriteLine('X');
            
        }
        _gameController.SaveAnswers();
    }
    
}