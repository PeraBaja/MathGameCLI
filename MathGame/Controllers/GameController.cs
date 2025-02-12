using MathGame.Models;
namespace MathGame.Controllers;

class GameController(GameStatusController gameStatusController) {
    readonly List<Operation> _operations = [];

    public IEnumerable<Operation> Operations {get => _operations;}
    public void PlayNewGame(OperatorController operatorController) {
        _operations.Clear();
        for(int i = 0; i < 10; i++){
            if(gameStatusController.GameStatues.Last().Operator == null) _operations.Add(new Operation(gameStatusController.GameStatues.Last(), operatorController.GetRandom()));
            else _operations.Add(new Operation(gameStatusController.GameStatues.Last(), gameStatusController.GameStatues.Last().Operator));
        }
    }
    public bool IsCorrectAnswer(int userAnswer, int index) {
        return _operations[index].IsUserAnswerCorrect(userAnswer);
    }
    public void SaveAnswers() {
        foreach(var operation in _operations){
            gameStatusController.GameStatues.Last().Answers.Add($"{operation}"); 
        }
        
    }
}