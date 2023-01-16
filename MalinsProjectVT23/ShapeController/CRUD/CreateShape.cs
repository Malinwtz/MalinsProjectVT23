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

        decimal height = 0;
        if (shape.Name != ShapeEnum.TypeOfShape.Triangle.ToString())
        {
            Action.Input(" Write height (cm): ");
            height = ErrorHandling.TryDecimal();

        }
        
        decimal length = 0;
        decimal pArea = 0;
        while (true)
        {
            Action.Input(" Write length (cm): ");
            try
            {
                length = ErrorHandling.TryDecimal();
                if(shape.Name == ShapeEnum.TypeOfShape.Triangle.ToString()) height = shape.CalculateHeight(length);
                pArea = shape.CalculateArea(length, height);
                break;
            }
            catch (Exception e)
            {
                Action.NotSuccessful(e.Message);
                throw;
            }
           
        }

        var pCircumference = shape.CalculateCircumference(length, height);
        
        AddShapeResultAndShapeToDatabase(pArea, pCircumference, height, length, shape.Name);
        DbContext.SaveChanges();
        Action.Successful($"Saved!\n\n {shape.Name}\n Height: {height:0.000}cm,\n Length: {length}cm" +
                          $"\n Area: {pArea:0.000}cm2,\n Circumference: {pCircumference:0.000}cm");
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