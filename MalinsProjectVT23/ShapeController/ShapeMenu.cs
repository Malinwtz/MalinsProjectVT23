using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;

namespace MalinsProjectVT23.ShapeController;

public class ShapeMenu
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
        Console.WriteLine(" 3. Triangle");
        Console.WriteLine($" {endAlternative}. Rhombus");
        Console.ForegroundColor = ConsoleColor.Gray;
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        var crudShape =
            new CrudShapeMenu(); //Skickar in en IShape i varje menyalternativ för att det ska skapas olika former.
        var inputFromCrudShapeMenu = crudShape.ReturnSelectionFromMenu();
        if (inputFromCrudShapeMenu != 0)
            switch (selectedFromMenu)
            {
                case 1:
                {
                    //var inputFromCrudShapeMenu = crudShape.ReturnSelectionFromMenu(); //flytta kod till innan switch?
                    //if (inputFromCrudShapeMenu != 0)
                    crudShape.LoopMenu(inputFromCrudShapeMenu, dbContext, new Rectangle());
                    break;
                }
                case 2:
                {
                    //var inputFromCrudShapeMenu = crudShape.ReturnSelectionFromMenu();
                    //if (inputFromCrudShapeMenu != 0)
                    crudShape.LoopMenu(inputFromCrudShapeMenu, dbContext, new Parallelogram());
                    break;
                }
                case 3:
                {
                    //var inputFromCrudShapeMenu = crudShape.ReturnSelectionFromMenu();
                    //if (inputFromCrudShapeMenu != 0)
                    crudShape.LoopMenu(inputFromCrudShapeMenu, dbContext, new Triangle());
                    break;
                }
                case 4:
                {
                    //var inputFromCrudShapeMenu = crudShape.ReturnSelectionFromMenu();
                    //if (inputFromCrudShapeMenu != 0)
                    crudShape.LoopMenu(inputFromCrudShapeMenu, dbContext, new Rhombus());
                    break;
                }
            }
    }
}