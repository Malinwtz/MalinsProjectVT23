using ClassLibraryCalculations.Interface;
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" The list of calculations is empty ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Action.PressEnterToContinue();
        }
        else if (DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod).Any()) 
        {
            View();
            Action.PressEnterToContinue();
        }
    }

    public void View()
    {
        Console.WriteLine("{0,-20}{1,-15}{2,-20}{3,-15}{4,-15}{5,-15}",
            "CalculationId", "Input1", "CalculationMethod", "Input2", "Result", "Date");

        foreach (var calculation in DbContext.Calculations.Where(c=>c.CalculationStrategy == CalculateStrategy.CalculationMethod))
            Console.WriteLine("{0,-20}{1,-15}{2,-20}{3,-15}{4,-15}{5,-15}",
                $"{calculation.CalculationId}", $"{calculation.Input1}", $"{calculation.CalculationStrategy}", $"{calculation.Input2}",
                $"{calculation.Result:0.000000}", $"{calculation.CalculationDate}");
    }
}