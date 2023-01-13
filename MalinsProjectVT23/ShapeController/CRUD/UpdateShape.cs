using ClassLibraryErrorHandling;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
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
            //linje
            Console.Write(" Select shape by Id: ");
            var shapeIdToFind = ErrorHandling.TryInt();
            var shapeFoundById = DbContext.ShapeResults
                    .Include(s => s.Shape)
                    .FirstOrDefault(s => s.ShapeResultId == shapeIdToFind);

            Console.WriteLine($" Vald shape är: Id {shapeFoundById.ShapeResultId}");
            Console.ReadLine();
        }
    }
}