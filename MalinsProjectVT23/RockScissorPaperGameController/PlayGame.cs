using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.RockScissorPaperGameController;

public class PlayGame
{
    public enum GameResult
    {
        Computer = 1,
        User = 2,
        Tie = 3
    }

    public PlayGame(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    private int ComputerPoints { get; set; }
    private int UserPoints { get; set; }
    private string[] gameOptions { get; } = { "Rock", "Scissor", "Paper" };
    public ApplicationDbContext DbContext { get; set; }

    public void LoopGame()
    {
        while (true)
        {
            var randomizedOption = GetRandomizedOption();
            GameHeader();
            var userOption = ReturnSelectionFromMenu();
            if (userOption == -1) break;

            GameHeader();
            Action.Blue($" User: {gameOptions[userOption]} \n Computer: {gameOptions[randomizedOption]}\n");

            if (randomizedOption == userOption)
            {
                Action.Cyan(" It's a tie!");
            }
            else if ((randomizedOption == 0 && userOption > randomizedOption && userOption != gameOptions.Length - 1)
                     || (randomizedOption == 1 && userOption > randomizedOption) || (randomizedOption == 2 &&
                         userOption < randomizedOption && userOption != 0))
            {
                Action.Cyan($" Winner: Computer with {gameOptions[randomizedOption]}!");
                ComputerPoints++;
            }
            else
            {
                Action.Cyan($" Winner: User with {gameOptions[userOption]}!");
                UserPoints++;
            }

            Action.Cyan($"\n Points\n User: {UserPoints}\n Computer: {ComputerPoints}");
            Action.PressEnterToContinue();
        }

        Console.Clear();
        Action.Blue("\n Game finished!\n\n");

        var isTie = false;
        var resultString = "";
        if (ComputerPoints == UserPoints)
        {
            isTie = true;
            resultString = GameResult.Tie.ToString();
            Action.Cyan("\n It's a tie!");
        }
        else if (ComputerPoints > UserPoints)
        {
            resultString = GameResult.Computer.ToString();
            ShowWinner(resultString);
        }
        else if (ComputerPoints < UserPoints)
        {
            resultString = GameResult.User.ToString();
            ShowWinner(resultString);
        }

        Action.PressEnterToContinue();
        AddNewGameResult(resultString, isTie);
        DbContext.SaveChanges();
        Action.Successful(" Game results saved to database");
        Action.PressEnterToContinue();
    }

    private void AddNewGameResult(string resultString, bool isTie)
    {
        DbContext.RockScissorPaperGameResults.Add(new RockScissorPaperGameResult
        {
            Date = DateTime.Now,
            Winner = resultString,
            NumberOfComputerWins = ComputerPoints,
            NumberOfUserWins = UserPoints,
            Tie = isTie
        });
    }

    private int GetRandomizedOption()
    {
        var rnd = new Random();
        var randomizedOption = rnd.Next(gameOptions.Length);
        return randomizedOption;
    }

    private static void GameHeader()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("{0, 190}", " Rock, Scissor, Paper Game");
        Line.LineThreeStar();
    }

    private void ShowWinner(string resultString)
    {
        Action.Cyan($"\n Winner: {resultString} " +
                    $"\n UserPoints: {UserPoints}, " +
                    $"\n ComputerPoints: {ComputerPoints}");
    }

    public int ReturnSelectionFromMenu()
    {
        var endAlternative = 3;
        Action.Cyan(" Select option: \n");
        Action.Cyan(" 1. Rock");
        Action.Cyan(" 2. Scissor");
        Action.Cyan($" {endAlternative}. Paper");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel - 1;
    }
}