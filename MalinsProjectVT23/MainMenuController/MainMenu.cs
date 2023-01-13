using ClassLibraryCalculations.Interface;
using ClassLibraryStrings;
using MalinsProjectVT23.CalculatorController;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.RockScissorPaperGameController;
using MalinsProjectVT23.ShapeController;

namespace MalinsProjectVT23.MainMenuController;

public class MainMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 3;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(" MAIN MENU");
        Line.LineThreeStar();
        Console.WriteLine(" 1. Shapes");
        Console.WriteLine(" 2. Calculator");
        Console.WriteLine($" {endAlternative}. Rock, Scissors, Paper");
        Console.ForegroundColor = ConsoleColor.Gray;
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
}