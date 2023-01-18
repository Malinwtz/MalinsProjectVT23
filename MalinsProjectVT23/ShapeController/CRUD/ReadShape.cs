using ClassLibraryStrings;
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
            ListOfShapeIsEmpty(shape);
        }
        else if (DbContext.ShapeResults.Any())
        {
            View(shape);
            Action.PressEnterToContinue();
        }
    }

    public void View(IShape shapeToShow)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("{0,-10}{1,-15}{2,-16}{3,-16}{4,-16}{5,-10}{6,-20}",
            " ResultId", "Name", "HeightCm", "LengthCm", "AreaCm2", "CircumCm", "CreatedDate");
        Line.LineTwoEqual();

        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (var shape in DbContext.ShapeResults.Where(s => s.Shape.Name == shapeToShow.Name)
                     .Include(s => s.Shape))
            Console.WriteLine("{0,-10}{1,-15}{2,-16}{3,-16}{4,-16}{5,-10}{6,-20}",
                $" {shape.ShapeResultId}", $"{shape.Shape.Name}", $"{shape.Height:0.00##}",
                $"{shape.Length:0.00##}", $"{shape.Area:0.00##}", $"{shape.Circumference:0.00##}",
                $"{shape.ResultDate}");
    }

    public void ListOfShapeIsEmpty(IShape shape)
    {
        Action.Red(" The list of shapes does not contain ");
        Action.Yellow($"{shape.Name}\n");
        Action.PressEnterToContinue();
    }
}