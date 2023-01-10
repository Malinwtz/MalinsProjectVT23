using ClassLibraryStrings;
using MalinsProjectVT23.CalculatorController;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
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
                    //shapesmenu
                    //var customerMenu = new CustomerMenu();
                    //var selectedFromCustomerMenu = customerMenu.ReturnSelectionFromMenu();
                    //if (selectedFromCustomerMenu == 0) loop = false;
                    //customerMenu.LoopMenu(selectedFromCustomerMenu, dbContext);

                    //0. Exit
                    //1. Rectangle
                    //2. Parallelogram
                    //3. Triangle
                    //4. Rhombus
                    break;
                }
                case 2:
                {
                    var calculatorMenu = new CalculatorMenu();
                    var inputFromCalculatorMenu = calculatorMenu.ReturnSelectionFromMenu();
                    if (inputFromCalculatorMenu == 0) loop = false;
                    calculatorMenu.LoopMenu(inputFromCalculatorMenu, dbContext);
                    break;
                }
                case 3:
                    //rock scissors paper
                    //var bookingMenu = new BookingMenu();
                    //var selectedFromBookingMenu = bookingMenu.ReturnSelectionFromMenu();
                    //if (selectedFromBookingMenu == 0) loop = false;
                    //bookingMenu.LoopMenu(selectedFromBookingMenu, dbContext);

                    //0. Exit
                    //1. Play game
                    //2. Show statistics
                    break;
            }
    }
}