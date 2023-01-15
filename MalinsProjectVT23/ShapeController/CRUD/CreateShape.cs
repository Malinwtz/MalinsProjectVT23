using ClassLibraryErrorHandling;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.ShapeController.Shapes;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.ShapeController.CRUD;

public class CreateShape : ICrudShape
{
    public CreateShape(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud(IShape shape)
    {
        Console.Clear();
        Console.WriteLine($" Create shape: {shape.Name}");
        Console.WriteLine(" Write length (cm)");
        var length = ErrorHandling.TryDecimal();
        Console.WriteLine(" Write height (cm)");
        var height = ErrorHandling.TryDecimal();

        switch (shape)
        {
            case Rectangle:
            {
                shape = new Rectangle();
                break;
            }
            case Triangle:
            {
                shape = new Triangle();
                break;
            }
            case Parallelogram:
            {
                shape = new Parallelogram();
                break;
            }
            case Rhombus:
            {
                shape = new Rhombus();

                break;
            }
        }

        var pCircumference = shape.CalculateCircumference(length, height);
        var pArea = shape.CalculateArea(length, height);
        AddShapeResultAndShapeToDatabase(pArea, pCircumference, height, length, shape.Name);
        DbContext.SaveChanges();
        Action.Successful(" Saved");
        Action.PressEnterToContinue();
    }

    private void AddShapeResultAndShapeToDatabase(decimal pArea, decimal pCircumference, decimal height, decimal length,
        string shapeName)
    {
        DbContext.ShapeResults.Add(new ShapeResult
        {
            Area = pArea,
            Circumference = pCircumference,
            Height = height,
            Length = length,
            ResultDate = DateTime.Now,
            Shape = new Shape
            {
                Name = shapeName,
            }
        });
    }
}