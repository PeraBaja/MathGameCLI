using MathGame.Controllers;
using MathGame.Models;
namespace MathGame.Views;

class MenuView(GameStatusController controller, GameView gameView, OperatorController operatorController)
{
    readonly GameStatusController _controller = controller;
    readonly GameView _gameView = gameView;
    readonly OperatorController _operatorController = operatorController;
    public void Display() {
        while (true)
        {
            ShowMenuOptions();
            string userOption = Console.ReadLine() ?? "";
            Console.Clear();
            switch (userOption.ToLower())
            {
                case "1":
                    _controller.NewGame();
                    SelectDifficulty();
                    SelectOperation();
                    _gameView.Display();
                    break;
                case "2":
                    LastPlayedGamesView.Display(_controller.GameStatues);
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Not a valid option. Please, try again.");
                    break;
            }
        }
    }           
    static void ShowMenuOptions()
    {
        Console.WriteLine("Welcome to the math game." +
        "\n\nThese are the aviables option:" +
        "\n\t1.Start a new game." +
        "\n\t2.View lasts attemps." +
        "\n\tExit. Close this program.");
    }
    public void SelectDifficulty() {
        while(true) {
            Console.Write($"Select the dificulty level by typing: ");
            foreach(string difficulty in GameStatusController.GetDifficultyNames()){
                Console.Write($"| {difficulty} |");
            }
            Console.WriteLine("");
            string userOption = Console.ReadLine() ?? "";
            Console.Clear();
            try {
                _controller.ConfigureDifficulty(userOption);
                break;
            }
            catch {
                Console.WriteLine( "The selected dificulty level doesn't exist. Please select another.");
            }
        }
    }
    void SelectOperation() {
        
        while(true){
            Console.Write($"Select the operation by typing: ");
            foreach(string _operator in _operatorController.GetNames()){
                Console.Write($"| {_operator} |");
            }
            Console.WriteLine("Or any for random operations");
            string userOption = Console.ReadLine() ?? "";
            try{
                {
                _controller.ConfigureOperator(userOption);
                break;
            }
            }
            catch{
                Console.WriteLine("The selected operation is not allowed or doesn't exist");
            }
        }
        
    }
}