using ClassLibraryCalculations.Interface;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController.CRUD;

public class ReadCalculation : ICrudCalculation
{
    public ReadCalculation(ApplicationDbContext dbContext, ICalculateStrategy calculateStrategy)
    {
        DbContext = dbContext;
        CalculateStrategy = calculateStrategy;
    }

    public ApplicationDbContext DbContext { get; set; }
    public ICalculateStrategy CalculateStrategy { get; set; }

    public void RunCrud(int selectedFromMenu)
    {
        if (!DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod).Any())
        {
            Action.NotSuccessful(" The list of calculations is empty ");
        }
        else if (DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod).Any()) 
        {
            View();
        }
        Action.PressEnterToContinue();
    }

    public void View()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}",
            "CalcId", "Input1", "CalcMethod", "Input2", "Result", "Date");
        Line.LineTwoEqual();
        Console.ForegroundColor = ConsoleColor.Magenta;
        foreach (var calculation in DbContext.Calculations.Where(c=>c.CalculationStrategy == CalculateStrategy.CalculationMethod))
            Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}",
                $"{calculation.CalculationId}", $"{calculation.Input1}", $"{calculation.CalculationStrategy}", 
                $"{calculation.Input2}", $"{calculation.Result}", $"{calculation.CalculationDate}");
    }
}