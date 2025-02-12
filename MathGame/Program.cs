using MathGame.Controllers;
using MathGame.Views;

OperatorController operatorController = new();
GameStatusController gameStatusController = new(operatorController);

GameController gameController = new(gameStatusController);
GameView gameView = new(gameController, operatorController);
MenuView menuView = new(gameStatusController, gameView, operatorController);


menuView.Display();