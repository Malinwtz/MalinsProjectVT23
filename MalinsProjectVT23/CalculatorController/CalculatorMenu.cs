﻿using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;
using ClassLibraryCalculations;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;

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
        MathServices mathServices = new MathServices(); // Gör till interface - sätta som property och skicka med - se richards projekt
        var loop = true;
        while (loop)
            switch (selectedFromMenu)
            {
                case 1:
                    {
                        //add
                        Console.Clear();
                        Console.Write(" Write number 1 to add: ");
                        var userInputNumberToAdd1 = ErrorHandling.TryInt();
                        Console.Write(" Write number 2 to add: ");
                        var userInputNumberToAdd2 = ErrorHandling.TryInt();
                        var resultAddedNumbers = mathServices.Addition(userInputNumberToAdd1, userInputNumberToAdd2);
                        Console.Write($" Result: 1 + 2 = {resultAddedNumbers}");
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