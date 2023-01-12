using ClassLibraryStrings;
using MalinsProjectVT23.MainMenuController;

namespace MalinsProjectVT23.CalculatorController;

public class CalculatorMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 6;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Calculator Menu");
        Line.LineThreeStar();
        Console.WriteLine(" 1. Add two numbers");
        Console.WriteLine(" 2. Subtract two numbers");
        Console.WriteLine(" 3. Multiply two numbers");
        Console.WriteLine(" 4. Divide two numbers");
        Console.WriteLine(" 5. Square Root");
        Console.WriteLine($" {endAlternative}. Modulus");
        Console.ForegroundColor = ConsoleColor.Gray;
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
}