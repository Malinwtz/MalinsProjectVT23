using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using Microsoft.EntityFrameworkCore;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.ShapeController.CRUD;

public class UpdateShape : ICrudShape
{
    public UpdateShape(ApplicationDbContext dbContext, ReadShape readShape)
    {
        DbContext = dbContext;
        Read = readShape;
    }

    public ApplicationDbContext DbContext { get; set; }
    public ReadShape Read { get; set; }
    public void RunCrud(IShape shape)
    {
        Console.Clear();
        if (!DbContext.ShapeResults.Where(s => s.Shape.Name == shape.Name)
                .Include(s => s.Shape)
                .Any())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" The list of shapes does not contain ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{shape.Name}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Action.PressEnterToContinue();
        }
        else if (DbContext.ShapeResults.Any())
        {
            Read.View(shape);
            Line.LineOneHyphen();
            Console.Write(" Select shape by Id: ");
            var shapeIdToFind = ErrorHandling.TryInt();
            var shapeFoundById = DbContext.ShapeResults
                    .Include(s => s.Shape)
                    .FirstOrDefault(s => s.ShapeResultId == shapeIdToFind);




            Action.Successful($"\n Chosen shape:\n Id {shapeFoundById.ShapeResultId}, {shapeFoundById.Shape.Name} " +
                              $"\n Height: {shapeFoundById.Height}\n Length: {shapeFoundById.Length}\n");

            var endAlternative = 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Select what you want to change ");
            Console.WriteLine(" 1. Height");
            Console.WriteLine($" {endAlternative}. Length");
            Console.ForegroundColor = ConsoleColor.Gray;
            ReturnFromMenuClass.ExitMenu();
            var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);

            if (sel == 0) return;

            Console.Write(" Set a new value: ");
            var newValue = ErrorHandling.TryDecimal();
            switch (sel)
            {
                case 1:
                {
                    shapeFoundById.Height = newValue;
                    break;
                }
                case 2:
                {
                    shapeFoundById.Length = newValue;
                    break;
                }
            }

            shapeFoundById.Circumference = shape.CalculateCircumference(shapeFoundById.Length, shapeFoundById.Height);
            shapeFoundById.Area = shape.CalculateArea(shapeFoundById.Length, shapeFoundById.Height);
            DbContext.SaveChanges();
            Action.Successful(" Value changed!");
            Action.PressEnterToContinue();
        }
    }
}