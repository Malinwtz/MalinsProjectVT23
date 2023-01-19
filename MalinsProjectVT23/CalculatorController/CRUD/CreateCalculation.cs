using ClassLibraryCalculations.Interface;
using ClassLibraryErrorHandling;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController.CRUD;

public class CreateCalculation : ICrudCalculation
{
    public CreateCalculation(ApplicationDbContext dbContext, ICalculateStrategy calculateStrategy)
    {
        DbContext = dbContext;
        CalculateStrategy = calculateStrategy;
    }

    public ICalculateStrategy CalculateStrategy { get; set; }
    public decimal CalculatedResult { get; set; }
    public ApplicationDbContext DbContext { get; set; }

    public readonly string StringSquareRootOf = "Square root of";
    public void RunCrud(int selectedFromCalculateMenu)
    {
        Console.Clear();
        
        decimal userInputNumberToAdd2 = 0;
        decimal userInputNumberToAdd1 = 0;
        if (CalculateStrategy.CalculationMethod == StringSquareRootOf)
        {
            Action.White(" Write number to calculate: ");
            userInputNumberToAdd1 = ErrorHandling.TryPositiveDecimal();

            CalculatedResult = CalculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
            Action.Magenta($"\n Result: {CalculateStrategy.CalculationMethod} {userInputNumberToAdd1} " +
                                 $"= {CalculatedResult}\n");
        }
        else if (CalculateStrategy.CalculationMethod != StringSquareRootOf)
        {
            Action.White(" Write number to calculate: ");
            userInputNumberToAdd1 = ErrorHandling.TryDecimal();

            Action.White(" Write number 2 to calculate: ");
            userInputNumberToAdd2 = ErrorHandling.TryDecimal();

            CalculatedResult = CalculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
            Action.Magenta(
                $"\n Result: {userInputNumberToAdd1} {CalculateStrategy.CalculationMethod} {userInputNumberToAdd2} " +
                $"= {CalculatedResult}\n");
        }

        Action.PressEnterToContinue();

        AddNewCalculationToDatabase(userInputNumberToAdd1, userInputNumberToAdd2);
        DbContext.SaveChanges();
        Action.Successful(" Saved");
        Action.PressEnterToContinue();
    }

    private void AddNewCalculationToDatabase(decimal userInputNumberToAdd1, decimal userInputNumberToAdd2)
    {
        DbContext.Calculations.Add(new Calculation
        {
            Input1 = userInputNumberToAdd1,
            Input2 = userInputNumberToAdd2,
            Result = CalculatedResult,
            CalculationDate = DateTime.Now,
            CalculationStrategy = CalculateStrategy.CalculationMethod
        });
    }
}