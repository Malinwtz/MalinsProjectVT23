using ClassLibraryStrings;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.RockScissorPaperGameController;

public class DisplayRSPGameMenu : IDisplayMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 2;
        Action.Blue(" Rock Scissor Paper Menu\n");
        Line.LineThreeStar();
        Action.Cyan("\n 1. Play game");
        Action.Cyan($" {endAlternative}. Show statistics\n\n");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
}