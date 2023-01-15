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

    public ShapeResult ShapeFoundById { get; set; }
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
            Console.WriteLine(" Select shape by Id \n");
            FindShapeById(shape);

            Action.Successful($"\n Chosen shape:\n Id {ShapeFoundById.ShapeResultId}, {ShapeFoundById.Shape.Name} " +
                              $"\n Height: {ShapeFoundById.Height}cm\n Length: {ShapeFoundById.Length}cm\n");

            var endAlternative = 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Select what you want to change ");
            Console.WriteLine(" 1. Height (cm)");
            Console.WriteLine($" {endAlternative}. Length (cm)");
            Console.ForegroundColor = ConsoleColor.Gray;
            ReturnFromMenuClass.ExitMenu();
            var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);

            if (sel == 0) return;

            Action.Input(" Set a new value: ");
            var newValue = ErrorHandling.TryDecimal();
            switch (sel)
            {
                case 1:
                {
                    ShapeFoundById.Height = newValue;
                    break;
                }
                case 2:
                {
                    ShapeFoundById.Length = newValue;
                    break;
                }
            }

            ShapeFoundById.Circumference = shape.CalculateCircumference(ShapeFoundById.Length, ShapeFoundById.Height);
            ShapeFoundById.Area = shape.CalculateArea(ShapeFoundById.Length, ShapeFoundById.Height);
            DbContext.SaveChanges();
            Action.Successful(" Value changed!");
            Action.PressEnterToContinue();
        }
    }

    public ShapeResult FindShapeById(IShape shape)
    {
        while (true)
            try
            {
                Action.Input(" Write id:");
                var shapeIdToFind = Convert.ToInt32(Console.ReadLine());
                ShapeFoundById = DbContext.ShapeResults.Where(s=>s.Shape.Name == shape.Name)
                    .Include(s => s.Shape)
                    .FirstOrDefault(s => s.ShapeResultId == shapeIdToFind);

                if (ShapeFoundById != null) return ShapeFoundById;
                Action.NotSuccessful(" Id does not exist");
            }
            catch 
            {
                Action.NotSuccessful(" Wrong input");
            }
    }
}