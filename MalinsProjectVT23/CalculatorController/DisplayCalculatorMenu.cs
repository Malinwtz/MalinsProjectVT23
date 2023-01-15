using ClassLibraryStrings;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;

namespace MalinsProjectVT23.CalculatorController;

public class DisplayCalculatorMenu : IDisplayMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 6;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" Calculator Menu - Choose calculation method");
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