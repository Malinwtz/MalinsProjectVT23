using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.RockScissorPaperGameController;

public class RockScissorPaperRunMenu : IRunSecondMenu
{
    public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        Console.Clear();
        var loop = true;
        switch (selectedFromMenu)
        {
            case 1:
            {
                var playGameMenu = new PlayGame(dbContext);
                playGameMenu.LoopGame();
                break;
            }
            case 2:
            {
                var gameResults = new ShowGameResult(dbContext);
                gameResults.GameResults();
                Action.PressEnterToContinue();
                break;
            }
        }
    }
}