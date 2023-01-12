using ClassLibraryCalculations.Interface;
using ClassLibraryStrings;
using MalinsProjectVT23.CalculatorController;
using MalinsProjectVT23.Data;
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

    public IMenu Menu { get; set; }
    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        var chosenMenu = new ShapeMenu();
        var loop = true;
        while (loop)
            switch (selectedFromMenu)
            {
                case 1:
                {
                    chosenMenu = new ShapeMenu();
                    break;
                }
                case 2:
                {
                    var calculatorMenu = new CalculatorMenu();
                    var inputFromCalculatorMenu = calculatorMenu.ReturnSelectionFromMenu();
                    if (inputFromCalculatorMenu == 0) loop = false;
                    else Menu.RunMenuOptions(inputFromCalculatorMenu, dbContext);
                    break;
                }
                case 3:
                {
                    chosenMenu = new RockScissorPaperMenu();
                    break;
                }
            }
        var inputFromChosenMenu = chosenMenu.ReturnSelectionFromMenu();
        if (inputFromChosenMenu == 0) loop = false;
        else chosenMenu.RunMenuOptions(inputFromChosenMenu, dbContext);
    }
}