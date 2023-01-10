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
        Console.WriteLine(" START MENU");
        Line.LineThreeStar();
        Console.WriteLine(" 1. Shapes");
        Console.WriteLine(" 2. Calculator");
        Console.WriteLine($" {endAlternative}. Rock, Scissors, Paper");
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
                    var shapesMenu = new ShapeMenu();
                    var inputFromShapeMenu = shapesMenu.ReturnSelectionFromMenu();
                    if (inputFromShapeMenu == 0) loop = false;
                    else shapesMenu.LoopMenu(inputFromShapeMenu, dbContext);
                    break;
                }
                case 2:
                {
                    var calculatorMenu = new CalculatorMenu();
                    var inputFromCalculatorMenu = calculatorMenu.ReturnSelectionFromMenu();
                    if (inputFromCalculatorMenu == 0) loop = false;
                    else calculatorMenu.LoopMenu(inputFromCalculatorMenu, dbContext);
                    break;
                }
                case 3:
                {
                    var rockScissorPaperMenu = new RockScissorPaperMenu();
                    var selectedFromRockScissorPaperMenu = rockScissorPaperMenu.ReturnSelectionFromMenu();
                    if (selectedFromRockScissorPaperMenu == 0) loop = false;
                    rockScissorPaperMenu.LoopMenu(selectedFromRockScissorPaperMenu, dbContext);
                    break;
                    }
            }
    }
}