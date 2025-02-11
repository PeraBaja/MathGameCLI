using MathGame;

string userOption = "";

Operator addition = new(
    name: "addition",
    symbol: '+',
    calculate: (int a, int b) => a + b
);
Operator substraction = new(
    name: "substraction",
    symbol: '-',
    calculate: (int a, int b) => a - b
);
Operator division = new(
    name: "division",
    symbol: '/',
    calculate: Divide
);
Operator multiplication = new(
    name: "multiplication",
    symbol: 'x',
    calculate: (int a, int b) => a * b
);
Operator exponenciation = new(
    name: "exponenciation",
    symbol: '^',
    calculate: (int a, int b) => a ^ b
);

Operator[] operators = [addition, substraction, division, multiplication, exponenciation];
string[] operationNames = Operator.GetNames(operators);

GameStatus gameStatus = new();

while (!string.Equals(userOption, "exit"))
{
    ShowMenuOptions();
    userOption = Console.ReadLine() ?? "";
    Console.Clear();
    switch (userOption.ToLower())
    {
        case "1":
            gameStatus.SelectDifficulty();
            Console.WriteLine($"Difficulty: {gameStatus.Difficulty} | Mode: {"any"}");
            PlayGame();
            break;
        case "2":
            ViewPlayedGames();
            break;
        case "exit":
            return;
        default:
            Console.WriteLine("Not a valid option. Please, try again.");
            break;
    }
}

void ShowMenuOptions()
{
    Console.WriteLine("Welcome to the math game." +
    "\n\nThese are the aviables option:" +
    "\n\t1.Start a new game." +
    "\n\t2.View lasts attemps." +
    "\n\tExit. Close this program.");
}

void ViewPlayedGames()
{
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

bool IsCorrectAnswer(int targetResult, int userInput) => targetResult == userInput;

int Divide(int dividend, int divisor)
{
    if (0 <= divisor && divisor >= 100)
    {
        throw new ArgumentException("The divisor should be between 0 and 100");
    }
    if (dividend % divisor != 0)
    {
        throw new Exception("The division is not exact.");
    }
    return dividend / divisor;
}

void PlayGame()
{
    const int NUMBER_OF_EXERCISES = 10;
    Operator _operator;
    Console.Write($"Select the operation by typing: ");
    foreach (string name in operationNames)
    {
        Console.Write($"{name} -");
    }
    Console.WriteLine("or any for random operations.");
    string userOption = Console.ReadLine() ?? "";
    if(userOption == "any") _operator = Operator.GetRandom(operators);
    else if (!operators.Any(op => op.Name == userOption)) {
        PlayGame();
        return;
    }
    else _operator = Array.Find(operators, op => op.Name == userOption);

    for (int i = 0; i < NUMBER_OF_EXERCISES; i++)
    {
        if(userOption == "any") _operator = Operator.GetRandom(operators);
        
        Operation operation = new(gameStatus, _operator);
        string operationString = $"{operation.FirstNumber} {_operator.Symbol} {operation.SecondNumber} = ";
        Console.Write(operationString);
        int userAnswer = GetUserAnswer();
        char status;
        if (IsCorrectAnswer(operation.Result, userAnswer))
        {
            gameStatus.CorrectAnswers++;
            status = '✓';
        }
        else
        {
            status = 'X';
        }
        Console.WriteLine(status);
        gameStatus.Answers.Add(operationString + $"{operation.Result} {status}");
    }
}
static int GetUserAnswer()
{
    try
    {
        return int.Parse(Console.ReadLine() ?? "");
    }
    catch
    {
        Console.WriteLine("The response should be an integer number. Please, try again.");
        return GetUserAnswer();
    }
}