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

    public void RunCrud(int selectedFromCalculateMenu)
    {
        Console.Clear();
        Action.White(" Write number to calculate: ");
        var userInputNumberToAdd1 = ErrorHandling.TryInt();
        var userInputNumberToAdd2 = 0;

        if (CalculateStrategy.CalculationMethod == "Square root of")
        {
            CalculatedResult = CalculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
            Console.Write($"\n Result: {CalculateStrategy.CalculationMethod} {userInputNumberToAdd1} " +
                          $"= {CalculatedResult}\n");
        }
        else if (CalculateStrategy.CalculationMethod != "Square root of")
        {
            Action.White(" Write number 2 to calculate: ");
            userInputNumberToAdd2 = ErrorHandling.TryInt();

            CalculatedResult = CalculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
            Console.Write(
                $"\n Result: {userInputNumberToAdd1} {CalculateStrategy.CalculationMethod} {userInputNumberToAdd2} " +
                $"= {CalculatedResult}\n");
        }

        Action.PressEnterToContinue();

        DbContext.Calculations.Add(new Calculation
        {
            Input1 = userInputNumberToAdd1,
            Input2 = userInputNumberToAdd2,
            Result = CalculatedResult,
            CalculationDate = DateTime.Now,
            CalculationStrategy = CalculateStrategy.CalculationMethod
        });
        DbContext.SaveChanges();
        Action.Successful(" Saved");
        Action.PressEnterToContinue();
    }
}