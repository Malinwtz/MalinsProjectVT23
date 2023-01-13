using ClassLibraryCalculations;
using ClassLibraryCalculations.Interface;
using ClassLibraryErrorHandling;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.CalculatorController.CRUD;

public class CreateCalculation : ICrudCalculation
{
    public CreateCalculation(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public decimal CalculatedResult { get; set; }
    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud(int selectedFromCalculateMenu, ApplicationDbContext dbContext, ICalculateStrategy calculateStrategy)
    {
        Console.Clear();
        Console.Write(" Write number to calculate: ");
        var userInputNumberToAdd1 = ErrorHandling.TryInt();
        var userInputNumberToAdd2 = 0;
        if (selectedFromCalculateMenu != 5)
        {
            Console.Write(" Write number 2 to calculate: ");
            userInputNumberToAdd2 = ErrorHandling.TryInt();
        }

        if (selectedFromCalculateMenu == 5)
        {
            CalculatedResult = calculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
            Console.Write($" Result: {calculateStrategy.CalculationMethod} {userInputNumberToAdd1} " +
                          $"= {CalculatedResult}");
        }
        else
        {
            CalculatedResult = calculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
            Console.Write(
                $" Result: {userInputNumberToAdd1} {calculateStrategy.CalculationMethod} {userInputNumberToAdd2} " +
                $"= {CalculatedResult}");
        }

        DbContext.Calculations.Add(new Calculation
        {
            Input1 = userInputNumberToAdd1,
            Input2 = userInputNumberToAdd2,
            Result = CalculatedResult,
            CalculationDate = DateTime.Now
        });
        DbContext.SaveChanges();
    }
}