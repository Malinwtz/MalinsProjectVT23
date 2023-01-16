using ClassLibraryStrings;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController;

public class DisplayCrudCalculatorMenu : IDisplayMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 4;
        Action.DarkMagenta(" Calculator Crud Menu - Choose CRUD operation\n");
        Line.LineThreeStar();
        Action.Magenta("\n 1. Create calculation\n");
        Action.Magenta(" 2. Read calculations\n");
        Action.Magenta(" 3. Update calculation\n");
        Action.Magenta($" {endAlternative}. Delete calculation\n\n");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
}