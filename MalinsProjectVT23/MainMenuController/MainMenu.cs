using ClassLibraryStrings;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.MainMenuController;

public class MainMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 3;
        Line.LineThreeStar();
        Action.White(" MAIN MENU\n");
        Line.LineTwoEqual();
        Line.LineThreeStar();
        Action.DarkYellow("\n 1. Shapes\n\n");
        Action.DarkMagenta(" 2. Calculator\n\n");
        Action.DarkCyan($" {endAlternative}. Rock, Scissor, Paper\n\n\n");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
}