using ClassLibraryCalculations;
using ClassLibraryCalculations.Interface;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;

namespace MalinsProjectVT23.CalculatorController;

public class CalculatorMenu
{
    public ICalculateStrategy CalculateStrategy { get; set; }
    public decimal CalculatedResult { get; set; }

    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 6;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Calculator Menu");
        Line.LineThreeStar();
        Console.WriteLine(" 1. Add two numbers");
        Console.WriteLine(" 2. Subtract two numbers");
        Console.WriteLine(" 3. Multiplicate two numbers");
        Console.WriteLine(" 4. Divide two numbers");
        Console.WriteLine(" 5. Square Root");
        Console.WriteLine($" {endAlternative}. Modulus");
        Console.ForegroundColor = ConsoleColor.Gray;
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        Console.Clear();
        Console.Write(" Write number to calculate: ");
        var userInputNumberToAdd1 = ErrorHandling.TryInt();
        var userInputNumberToAdd2 = 0;
        if (selectedFromMenu != 5)
        {
            Console.Write(" Write number 2 to calculate: ");
            userInputNumberToAdd2 = ErrorHandling.TryInt();
        }

        switch (selectedFromMenu)
        {
            case 1:
            {
                CalculateStrategy = new AdditionCalculateStrategy();
                break;
            }
            case 2:
            {
                CalculateStrategy = new SubtractCalculateStrategy();
                break;
            }
            case 3:
            {
                CalculateStrategy = new MultiplicateCalculateStrategy();
                break;
            }
            case 4:
            {
                CalculateStrategy = new DivideCalculateStrategy();
                break;
            }
            case 5:
            {
                CalculateStrategy = new SquareRootCalculateStrategy();
                break;
            }
            case 6:
            {
                CalculateStrategy = new ModulusCalculateStrategy();
                break;
            }
        }

        if (selectedFromMenu == 5)
        {
            CalculatedResult = CalculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
            Console.Write($" Result: {CalculateStrategy.CalculationMethod} {userInputNumberToAdd1} " +
                          $"= {CalculatedResult}");
        }
        else
        {
            CalculatedResult = CalculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
            Console.Write($" Result: {userInputNumberToAdd1} {CalculateStrategy.CalculationMethod} {userInputNumberToAdd2} " +
                          $"= {CalculatedResult}");
        }
    }
}