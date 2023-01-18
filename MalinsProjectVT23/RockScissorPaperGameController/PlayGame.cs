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
        Draw = 3
    }

    public PlayGame(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    private int _computerPoints { get; set; } = 0;
    private int _userPoints { get; set; } = 0;
    private decimal _averageUserWins { get; set; } = 0;
    private int _numberOfDraws { get; set; } = 0;
    private string[] gameOptions { get; } = { "Rock", "Scissor", "Paper" };
    public ApplicationDbContext DbContext { get; set; }

    public void LoopGame()
    {
        var numberOfGames = 0;
        while (true)
        {
            var randomizedOption = GetRandomizedOption();
            GameHeader();
            var userOption = ReturnSelectionFromMenu();
            if (userOption == -1) break;

            GameHeader();
            Action.Blue($" {GameResult.User.ToString()}: {gameOptions[userOption]} \n " +
                        $"{GameResult.Computer.ToString()}: {gameOptions[randomizedOption]}\n");
            ShowSingleGameResultMessage(randomizedOption, userOption);
            numberOfGames++;
            Action.Cyan($"\n Points\n {GameResult.User.ToString()}: {_userPoints}\n " +
                        $"{GameResult.Computer.ToString()}: {_computerPoints}");
            Action.PressEnterToContinue();
        }

        Console.Clear();
        Action.Blue("\n Game finished!\n\n");

        CalculateAverageNumberOfUserWins(numberOfGames - _numberOfDraws);
        
        var resultString = ShowEndedGameResultMessage();
        ShowWinner(resultString);

        Action.PressEnterToContinue();
        AddNewGameResult(resultString);
        DbContext.SaveChanges();
        Action.Successful(" Game results saved to database");
        Action.PressEnterToContinue();
    }

    private string ShowEndedGameResultMessage()
    {
        var resultString = "";
        if (_computerPoints == _userPoints)
        {
            resultString = GameResult.Draw.ToString();
        }
        else if (_computerPoints > _userPoints)
        {
            resultString = GameResult.Computer.ToString();
        }
        else if (_computerPoints < _userPoints)
        {
            resultString = GameResult.User.ToString();
        }
        return resultString;
    }

    private void ShowSingleGameResultMessage(int randomizedOption, int userOption)
    {
        if (randomizedOption == userOption)
        {
            Action.Cyan($"\n {GameResult.Draw.ToString()}!");
            _numberOfDraws++;
        }
        else if ((randomizedOption == 0 && userOption > randomizedOption && userOption != gameOptions.Length - 1)
                 || (randomizedOption == 1 && userOption > randomizedOption) || (randomizedOption == 2 &&
                     userOption < randomizedOption &&
                     userOption != 0))
        {
            Action.Cyan($"\n WINNER: {GameResult.Computer.ToString()} with {gameOptions[randomizedOption]}!");
            _computerPoints++;
        }
        else
        {
            Action.Cyan($"\n WINNER: {GameResult.User.ToString()} with {gameOptions[userOption]}!");
            _userPoints++;
        }
    }

    private void CalculateAverageNumberOfUserWins(int numberOfGames)
    {
        if (numberOfGames > 0)
        {
            var averageWinsInDecimal = _userPoints / Convert.ToDecimal(numberOfGames);
            _averageUserWins = averageWinsInDecimal * 100;
        }
    }

    private void AddNewGameResult(string resultString)
    {
        DbContext.RockScissorPaperGameResults.Add(new RockScissorPaperGameResult
        {
            Date = DateTime.Now,
            Winner = resultString,
            NumberOfComputerWins = _computerPoints,
            NumberOfUserWins = _userPoints,
            AverageUserWins = Math.Round(_averageUserWins, 1, MidpointRounding.AwayFromZero)
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
        Action.Cyan($"\n > WINNER: {resultString} \n" +
                    $"\n UserPoints: {_userPoints} " +
                    $"\n ComputerPoints: {_computerPoints}");
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