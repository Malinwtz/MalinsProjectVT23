using ClassLibraryStrings;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController;

public class DisplayCalculatorMenu : IDisplayMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 6;
        Action.DarkMagenta(" Calculator Menu - Choose calculation method\n");
        Line.LineThreeStar();
        Action.Magenta("\n 1. Add two numbers\n");
        Action.Magenta(" 2. Subtract two numbers\n");
        Action.Magenta(" 3. Multiply two numbers\n");
        Action.Magenta(" 4. Divide two numbers\n");
        Action.Magenta(" 5. Square Root\n");
        Action.Magenta($" {endAlternative}. Modulus\n\n");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
}