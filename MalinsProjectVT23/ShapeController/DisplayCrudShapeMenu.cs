using ClassLibraryStrings;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.ShapeController;

public class DisplayCrudShapeMenu : IDisplayMenu
{
    public int ReturnSelectionFromMenu()
    {
        var endAlternative = 4;
        Action.DarkYellow(" Crud Shape Menu\n");
        Line.LineThreeStar();
        Action.Yellow(" 1. Create shape\n");
        Action.Yellow(" 2. Show list of saved shapes\n");
        Action.Yellow(" 3. Update shape\n");
        Action.Yellow($" {endAlternative}. Delete shape\n");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
}