using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using MalinsProjectVT23.ShapeController.Shapes;
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

            Read.ListOfShapeIsEmpty(shape);
        }
        else if (DbContext.ShapeResults.Any())
        {
            Read.View(shape);
            Line.LineOneHyphen();

            Action.Yellow(" Select shape by Id \n");
            ShapeFoundById = FindShapeById(shape);

            ShowChosenShape();

            if (shape.Name != ShapeEnum.TypeOfShape.Triangle.ToString())
            {
                var sel = ChangeHeightOrLengthMenu();
                if (sel == 0) return;

                var newValue = GetNewValueFromUser();
                SetNewValueToShapeHeightOrLength(sel, newValue);
            }
            else if (shape.Name == ShapeEnum.TypeOfShape.Triangle.ToString())
            {
                SetNewLengthValueToShape();
                ShapeFoundById.Height = shape.CalculateHeight(ShapeFoundById.Length);
            }

            ShapeFoundById.Circumference = shape.CalculateCircumference(ShapeFoundById.Length, ShapeFoundById.Height);
            ShapeFoundById.Area = shape.CalculateArea(ShapeFoundById.Length, ShapeFoundById.Height);
            DbContext.SaveChanges();
            Action.Successful(" Value changed!");
            Action.PressEnterToContinue();
        }
    }

    private void SetNewLengthValueToShape()
    {
        Action.Yellow(" Set new length\n");
        Action.White(" Value: ");
        ShapeFoundById.Length = ErrorHandling.TryDecimal();
    }

    private void SetNewValueToShapeHeightOrLength(int sel, decimal newValue)
    {
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
    }

    private static decimal GetNewValueFromUser()
    {
        Action.White(" Set a new value: ");
        var newValue = ErrorHandling.TryDecimal();
        return newValue;
    }

    public void ShowChosenShape()
    {
        Console.Clear();
        Action.DarkYellow($"\n Chosen shape:\n Id {ShapeFoundById.ShapeResultId}, {ShapeFoundById.Shape.Name}\n");
        Action.Yellow($" Height: {ShapeFoundById.Height}cm\n Length: {ShapeFoundById.Length}cm\n\n");
    }

    private static int ChangeHeightOrLengthMenu()
    {
        var endAlternative = 2;
        Action.Yellow(" Select what you want to change\n");
        Action.Yellow(" 1. Height (cm)\n");
        Action.Yellow($" {endAlternative}. Length (cm)\n");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }

    public ShapeResult FindShapeById(IShape shape)
    {
        while (true)
            try
            {
                Action.White(" Write id: ");
                var shapeIdToFind = Convert.ToInt32(Console.ReadLine());
               
                ShapeFoundById = DbContext.ShapeResults.Where(s=>s.Shape.Name == shape.Name).Include(s => s.Shape)
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