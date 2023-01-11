using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.RockScissorPaperGameController;

public class PlayGame
{
    public void LoopGame(ApplicationDbContext dbContext)
    {
        var c = new Player();
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
                c.ComputerPoints++;
            }
            else if ((userOption == 0 && randomizedOption > userOption && randomizedOption != gameOptions.Length - 1)
                     || (userOption == 1 && randomizedOption > userOption)
                     || (userOption == 2 && randomizedOption < userOption && randomizedOption != 0))
            {
                Action.Winner($" Winner: User with {gameOptions[userOption]}!");
                c.UserPoints++;
            }

            Console.WriteLine($"\n Points\n User: {c.UserPoints}\n Computer: {c.ComputerPoints}");
            Console.ReadKey();
        }
    }

    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 3;
        Console.ForegroundColor = ConsoleColor.Yellow;
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