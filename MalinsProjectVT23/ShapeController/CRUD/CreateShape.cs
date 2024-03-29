﻿using ClassLibraryErrorHandling;
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
    public Shape ShapeFoundInDatabase { get; set; }
    public void RunCrud(IShape shape)
    {
        Console.Clear();
        Action.Yellow($" Create shape: {shape.Name}\n");

        FindShapeInDataBase(shape);

        decimal height = 0;
        if (shape.Name != ShapeEnum.TypeOfShape.Triangle.ToString())
        {
            height = GetHeightInputFromUser();
        }
        
        decimal length = 0;
        decimal pArea = 0;
        while (true)
        {
            Action.White(" Write length (cm): ");
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
        
        AddShapeResultAndShapeToDatabase(pArea, pCircumference, height, length, ShapeFoundInDatabase); 
        DbContext.SaveChanges();
        Action.Successful($" Saved!\n\n");
        Action.Yellow($" {shape.Name}\n Height: {height}cm,\n Length: {length}cm" +
                          $"\n Area: {pArea}cm2,\n Circumference: {pCircumference}cm");
        Action.PressEnterToContinue();
    }

    private static decimal GetHeightInputFromUser()
    {
        decimal height;
        Action.White(" Write height (cm): ");
        height = ErrorHandling.TryDecimal();
        return height;
    }

    private void FindShapeInDataBase(IShape shape)
    {
        switch (shape)
        {
            case Rectangle:
            {
                ShapeFoundInDatabase = DbContext.Shapes.First(s => s.Name == shape.Name);
                break;
            }
            case Triangle:
            {
                ShapeFoundInDatabase = DbContext.Shapes.First(s => s.Name == shape.Name);
                break;
            }
            case Parallelogram:
            {
                ShapeFoundInDatabase = DbContext.Shapes.First(s => s.Name == shape.Name);
                break;
            }
            case Rhombus:
            {
                ShapeFoundInDatabase = DbContext.Shapes.First(s => s.Name == shape.Name);
                break;
            }
        }
    }

    private void AddShapeResultAndShapeToDatabase(decimal pArea, decimal pCircumference, decimal height, decimal length,
        Shape shape)
    {
        DbContext.ShapeResults.Add(new ShapeResult
        {
            Area = pArea,
            Circumference = pCircumference,
            Height = height,
            Length = length,
            ResultDate = DateTime.Now,
            Shape = shape
        });
    }
}