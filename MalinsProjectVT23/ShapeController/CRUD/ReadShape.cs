using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using Microsoft.EntityFrameworkCore;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.ShapeController.CRUD;

public class ReadShape : ICrudShape
{
    public ReadShape(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud(IShape shape)
    {
        if (!DbContext.ShapeResults.Where(s => s.Shape.Name == shape.Name)
                                    .Include(s => s.Shape)
                                    .Any())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($" The list of shapes does not contain ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{shape.Name}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Action.PressEnterToContinue();
        }
        else if (DbContext.ShapeResults.Any())
        {
            View(shape);
            Action.PressEnterToContinue();
        }
    }

    private void View(IShape shapeToShow)
    {
        Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}",
            "ShapeResultId", "Name", "Height", "Length", "Area", "Circumference", "CreatedDate");

        foreach (var shape in DbContext.ShapeResults.Where(s => s.Shape.Name == shapeToShow.Name)
                                                    .Include(s => s.Shape))
        {
            Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}",
                $"{shape.ShapeResultId}", $"{shape.Shape.Name}", $"{shape.Height}",
                $"{shape.Length}", $"{shape.Area}", $"{shape.Circumference}", $"{shape.Shape.Date}");
        }
    }
}