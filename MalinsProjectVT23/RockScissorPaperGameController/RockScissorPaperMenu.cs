using ClassLibraryStrings;
using MalinsProjectVT23.CalculatorController;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;

namespace MalinsProjectVT23.RockScissorPaperGameController;

public class RockScissorPaperMenu : IMenu
{
    public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        var loop = true;
        switch (selectedFromMenu)
        {
            case 1:
            {
                var playGameMenu = new PlayGame();
                playGameMenu.LoopGame(dbContext);
                break;
            }
            case 2:
            {
                //stats
                break;
            }
        }
    }

    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 2;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Rock Scissor Paper Menu");
        Line.LineThreeStar();
        Console.WriteLine(" 1. Play game");
        Console.WriteLine($" {endAlternative}. Show statistics");
        Console.ForegroundColor = ConsoleColor.Gray;
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
}