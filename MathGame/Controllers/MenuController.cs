using System.Collections.Immutable;
using MathGame.Models;

namespace MathGame.Controllers;

class GameStatusController(OperatorController operatorController) {
    GameStatus[] _gameStatues = [];

    readonly OperatorController _operatorController = operatorController;
    public ImmutableArray<GameStatus> GameStatues { get => [.. _gameStatues]; }
    public void NewGame() {
        var gameStatus = new GameStatus();
        _gameStatues  = [.. _gameStatues, gameStatus];  
    }
    public void ConfigureDifficulty(string userOption) {
        _gameStatues.Last().SelectDifficulty(userOption);
    }
    public void ConfigureOperator(string userOption){
        _gameStatues.Last().Operator = _operatorController.GetOperatorByName(userOption);
    }
    static public string[] GetDifficultyNames() {
        return Enum.GetNames<Difficulty>();
    }
}