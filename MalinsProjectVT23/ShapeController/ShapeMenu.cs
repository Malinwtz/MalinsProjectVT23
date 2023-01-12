using ClassLibraryStrings;
using MalinsProjectVT23.CalculatorController;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;

namespace MalinsProjectVT23.ShapeController;

public class ShapeMenu : IMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 4;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Shape Menu");
        Line.LineThreeStar();
        Console.WriteLine(" 1. Rectangle");
        Console.WriteLine(" 2. Parallelogram");
        Console.WriteLine(" 3. Equilateral triangle");
        Console.WriteLine($" {endAlternative}. Rhombus");
        Console.ForegroundColor = ConsoleColor.Gray;
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }

    public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        var crudShape = new CrudShapeMenu(); 
        var inputFromCrudShapeMenu = crudShape.ReturnSelectionFromMenu();
        if (inputFromCrudShapeMenu != 0)
            switch (selectedFromMenu)
            {
                case 1:
                {
                    crudShape.LoopMenu(inputFromCrudShapeMenu, dbContext, new Rectangle());
                    break;
                }
                case 2:
                {
                    crudShape.LoopMenu(inputFromCrudShapeMenu, dbContext, new Parallelogram());
                    break;
                }
                case 3:
                {
                    crudShape.LoopMenu(inputFromCrudShapeMenu, dbContext, new Triangle());
                    break;
                }
                case 4:
                {
                    crudShape.LoopMenu(inputFromCrudShapeMenu, dbContext, new Rhombus());
                    break;
                }
            }
    }
}