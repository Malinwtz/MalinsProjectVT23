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
        Console.WriteLine($" Create shape: {shape}");
        Console.WriteLine(" Write length");
        var length = ErrorHandling.TryDecimal();
        Console.WriteLine(" Write height");
        var height = ErrorHandling.TryDecimal();
        switch (shape)
        {
            case Rectangle:
                {
                    var pCircumference = shape.CalculateCircumference(length, height);
                    var pArea = shape.CalculateArea(length, height);
                    AddShapeResultAndShapeToDatabase(pArea, pCircumference, height, length, "Rectangle"); //gör om till enum
                    DbContext.SaveChanges();
                    Action.Successful(" Saved");
                    Action.PressEnterToContinue();
                    break;
                }
            case Triangle:
                {
                    var pCircumference = shape.CalculateCircumference(length, height);
                    var pArea = shape.CalculateArea(length, height);
                    AddShapeResultAndShapeToDatabase(pArea, pCircumference, height, length, "Triangle"); //gör om till enum
                    DbContext.SaveChanges();
                    Action.Successful(" Saved");
                    Action.PressEnterToContinue();
                    break;
                }
            case Parallelogram:
                {
                    var pCircumference = shape.CalculateCircumference(length, height);
                    var pArea = shape.CalculateArea(length, height);
                    AddShapeResultAndShapeToDatabase(pArea, pCircumference, height, length, "Parallelogram"); //gör om till enum
                    DbContext.SaveChanges();
                    Action.Successful(" Saved");
                    Action.PressEnterToContinue();
                    break;
                }
            case Rhombus:
                {
                    var pCircumference = shape.CalculateCircumference(length, height);
                    var pArea = shape.CalculateArea(length, height);
                    AddShapeResultAndShapeToDatabase(pArea, pCircumference, height, length, "Rhombus"); //gör om till enum
                    DbContext.SaveChanges();
                    Action.Successful(" Saved");
                    Action.PressEnterToContinue();
                    break;
                }
        }
    }

    private void AddShapeResultAndShapeToDatabase(decimal pArea, decimal pCircumference, decimal height, decimal length, string shapeName)
    {
        DbContext.ShapeResults.Add(new ShapeResult
        {
            Area = pArea,
            Circumference = pCircumference,
            Height = height,
            Length = length,
            Shape = new Shape
            {
                Date = DateTime.Now,
                Name = shapeName // - enum?
            }
        });
    }
}