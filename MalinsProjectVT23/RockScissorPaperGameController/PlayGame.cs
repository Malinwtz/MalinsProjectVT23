using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;
using Microsoft.EntityFrameworkCore;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.RockScissorPaperGameController;

public class PlayGame
{
    public PlayGame(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ApplicationDbContext _dbContext { get; set; }
    public void LoopGame()
    {
        var game = new Game();
        var gameOptions = new[] { "Rock", "Scissor", "Paper" };
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("{0, 190}", " Rock, Scissor, Paper Game");
        Line.LineThreeStar();
        Console.ForegroundColor = ConsoleColor.Gray;
        Action.PressEnterToContinue();

        while (true)
        {
            var rnd = new Random();
            var randomizedOption = rnd.Next(gameOptions.Length);
            var userOption = ReturnSelectionFromMenu();
            if (userOption == -1) break;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($" User: {gameOptions[userOption]} \n Computer: {gameOptions[randomizedOption]}\n");

            if (randomizedOption == userOption)
                Action.Winner(" It's a tie!");
            if ((randomizedOption == 0 && userOption > randomizedOption && userOption != gameOptions.Length - 1)
                || (randomizedOption == 1 && userOption > randomizedOption)
                || (randomizedOption == 2 && userOption < randomizedOption && userOption != 0))
            {
                Action.Winner($" Winner: Computer with {gameOptions[randomizedOption]}!");
                game.ComputerPoints++;
            }
            else if ((userOption == 0 && randomizedOption > userOption && randomizedOption != gameOptions.Length - 1)
                     || (userOption == 1 && randomizedOption > userOption)
                     || (userOption == 2 && randomizedOption < userOption && randomizedOption != 0))
            {
                Action.Winner($" Winner: User with {gameOptions[userOption]}!");
                game.UserPoints++;
            }

            Console.WriteLine($"\n Points\n User: {game.UserPoints}\n Computer: {game.ComputerPoints}");
            Console.ReadKey();
        }

        var isTie = IsTie(game);

        var isComputerWinner = IsComputerWinner(game, out var isUserWinner);

        Console.Clear();
        Console.WriteLine(" Game finished!\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($" Tie: {isTie}, ComputerWin: {isComputerWinner}, numberofwins: {game.ComputerPoints}");
        Console.WriteLine($" User: {isUserWinner}, pts {game.UserPoints}");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.ReadKey();

        _dbContext.RockScissorPaperGameResults.Add(new RockScissorPaperGameResult
        {
            Date = DateTime.Now,
            ComputerWin = isComputerWinner,
            NumberOfComputerWins = game.ComputerPoints,
            UserWin = isUserWinner,
            NumberOfUserWins = game.UserPoints,
            Tie = isTie
        });

        _dbContext.SaveChanges();
        Action.Successful(" Game results saved to database");
        Action.PressEnterToContinue();
    }

    private static bool IsComputerWinner(Game game, out bool isUserWinner)
    {
        var isComputerWinner = false;
        isUserWinner = true;
        if (game.ComputerPoints > game.UserPoints)
        {
            isComputerWinner = true;
            isUserWinner = false;
        }

        return isComputerWinner;
    }

    private static bool IsTie(Game game)
    {
        var isTie = false;
        if (game.ComputerPoints == game.UserPoints) isTie = true;
        return isTie;
    }

    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 3;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Select option: ");
        Line.LineOneHyphen();
        Console.WriteLine(" 1. Rock");
        Console.WriteLine(" 2. Scissor");
        Console.WriteLine($" {endAlternative}. Paper");
        Console.ForegroundColor = ConsoleColor.Gray;
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel-1;
    }
}