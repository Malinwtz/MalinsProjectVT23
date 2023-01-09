using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;

namespace MalinsProjectVT23.CalculatorController;

public class CalculatorMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 6;
        Console.WriteLine(" Calculator Menu");
        Console.WriteLine("*****************"); //Lines.LineThreeStar();
        Console.WriteLine(" 1. Add two numbers");
        Console.WriteLine(" 2. Subtract two numbers");
        Console.WriteLine(" 3. Multiplicate two numbers");
        Console.WriteLine(" 4. Divide two numbers");
        Console.WriteLine(" 5. Square Root");
        Console.WriteLine($" {endAlternative}. Modulus");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        var loop = true;
        while (loop)
            switch (selectedFromMenu)
            {
                case 1:
                    {
                        //add
                        break;
                    }
                case 2:
                    {
                        //subtract
                        break;
                    }
                case 3:
                    {
                        //multi
                        break;
                    }
                case 4:
                    {
                        //divide
                        break;
                    }
                case 5:
                    {
                        //modulus
                        break;
                    }
            }
    }
}