using ClassLibraryCalculations;
using ClassLibraryCalculations.Interface;
using ClassLibraryErrorHandling;
using MalinsProjectVT23.Data;

namespace MalinsProjectVT23.CalculatorController;

public class CreateCalculation
{
    public CreateCalculation(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ICalculateStrategy CalculateStrategy { get; set; }
    public decimal CalculatedResult { get; set; }
    public ApplicationDbContext DbContext { get; set; }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        Console.Clear();
        Console.Write(" Write number to calculate: ");
        var userInputNumberToAdd1 = ErrorHandling.TryInt();
        var userInputNumberToAdd2 = 0;
        if (selectedFromMenu != 5)
        {
            Console.Write(" Write number 2 to calculate: ");
            userInputNumberToAdd2 = ErrorHandling.TryInt();
        }

        switch (selectedFromMenu)
        {
            case 1:
            {
                CalculateStrategy = new AdditionCalculateStrategy();
                break;
            }
            case 2:
            {
                CalculateStrategy = new SubtractCalculateStrategy();
                break;
            }
            case 3:
            {
                CalculateStrategy = new MultiplyCalculateStrategy();
                break;
            }
            case 4:
            {
                CalculateStrategy = new DivideCalculateStrategy();
                break;
            }
            case 5:
            {
                CalculateStrategy = new SquareRootCalculateStrategy();
                break;
            }
            case 6:
            {
                CalculateStrategy = new ModulusCalculateStrategy();
                break;
            }
        }

        if (selectedFromMenu == 5)
        {
            CalculatedResult = CalculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
            Console.Write($" Result: {CalculateStrategy.CalculationMethod} {userInputNumberToAdd1} " +
                          $"= {CalculatedResult}");
        }
        else
        {
            CalculatedResult = CalculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
            Console.Write(
                $" Result: {userInputNumberToAdd1} {CalculateStrategy.CalculationMethod} {userInputNumberToAdd2} " +
                $"= {CalculatedResult}");
        }

        DbContext.Calculations.Add(new Calculation
        {
            Input1 = userInputNumberToAdd1,
            Input2 = userInputNumberToAdd2,
            Result = CalculatedResult,
            Date = DateTime.Now
        });
        DbContext.SaveChanges();
    }
}