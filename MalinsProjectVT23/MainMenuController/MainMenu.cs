using System.Security.AccessControl;
using ClassLibraryStrings;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.MainMenuController;

public class MainMenu
{
    private string MainMenuString { get; set; } = "\n MAIN MENU\n";
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 3;
       // StringFormat.Center(MainMenuString);
        Action.PurpleGradient(MainMenuString);
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