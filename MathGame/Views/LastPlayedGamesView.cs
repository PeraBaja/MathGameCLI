using MathGame.Models;

namespace MathGame.Views;

class LastPlayedGamesView {
    public static void Display(IEnumerable<GameStatus> gameStatues)
    {
        foreach(var gameStatus in gameStatues){
        if (gameStatus.Answers.Count == 0) {
            Console.WriteLine("There's no games played");
            return;
        }
        int? maxLength = gameStatus.Answers.Select(gs => gs.Length).Max();
        for(int i = 0; i < maxLength; i++) {
            Console.Write("-");
        }
        Console.WriteLine("");
        foreach(string answers in gameStatus.Answers) {
            Console.WriteLine(answers);
        }
        for(int i = 0; i < maxLength; i++) {
            Console.Write("-");
        }
        }
    }
}