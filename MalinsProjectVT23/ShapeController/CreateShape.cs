using ClassLibraryErrorHandling;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.ShapeController;

public class CreateShape
{
    public CreateShape(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void Create(IShape shape)
    {
        switch (shape)
        {
            case Rectangle:
            {
                Console.WriteLine("Create Rectangle");
                break;
            }
            case Triangle:
            {
                Console.WriteLine("Create Triangle");
                break;
            }
            case Parallelogram:
            {
                Console.WriteLine("Create Parallelogram");
                //flytta inmatningen eftersom det är för alla shapes
                Console.WriteLine(" Write length");
                var pLength = ErrorHandling.TryDecimal();
                Console.WriteLine(" Write height");
                var pHeight = ErrorHandling.TryDecimal();

                var pCircumference = shape.CalculateCircumference(pLength, pHeight);
                var pArea = shape.CalculateArea(pLength, pHeight);

                DbContext.ShapeResults.Add(new ShapeResult
                {
                    Area = pArea,
                    Circumference = pCircumference,
                    Height = pHeight,
                    Length = pLength,
                    Shape = new Shape //hamnar denna i rätt tabell???
                    {
                        Date = DateTime.Now,
                        Name = "Parallelogram" //parallelogram - enum?
                    }
                });
                DbContext.SaveChanges(); //invalid column names
                Console.WriteLine("Saved");
                Action.PressEnterToContinue();
                break;
            }
            case Rhombus:
            {
                Console.WriteLine("Create Rhombus");
                break;
            }
        }
    }
}