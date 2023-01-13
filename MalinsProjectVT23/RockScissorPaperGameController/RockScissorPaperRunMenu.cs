using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;

namespace MalinsProjectVT23.RockScissorPaperGameController;

public class RockScissorPaperRunMenu : IRunMenu
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
}