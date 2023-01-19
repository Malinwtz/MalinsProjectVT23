using ClassLibraryStrings;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.MainMenuController;

public class MainMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 3;
        Action.BlueGradient("\n MAIN MENU\n");
        Line.LineTwoEqual();
        Line.LineThreeStar();
        Action.Yellow("\n 1. Shapes\n\n");
        Action.Magenta(" 2. Calculator\n\n");
        Action.DarkCyan($" {endAlternative}. Rock, Scissor, Paper\n\n\n");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
}