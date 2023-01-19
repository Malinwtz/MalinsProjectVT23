using ClassLibraryCalculations.Interface;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController.CRUD;

public class ReadCalculation : ICrudCalculation
{
    public ReadCalculation(ApplicationDbContext dbContext, CreateCalculation create, ICalculateStrategy calculateStrategy)
    {
        DbContext = dbContext;
        CalculateStrategy = calculateStrategy;
        Create = create;
    }

    public CreateCalculation Create { get; set; }
    public ApplicationDbContext DbContext { get; set; }
    public ICalculateStrategy CalculateStrategy { get; set; }

    public void RunCrud(int selectedFromMenu)
    {
        if (!DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod).Any())
        {
            ListOfCalculationIsEmpty();
        }
        else if (DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod).Any()) 
        {
            View();
        }
        Action.PressEnterToContinue();
    }

    public void ListOfCalculationIsEmpty()
    {
        Action.Red(" The list of calculation does not contain the ");
        Action.White($"({CalculateStrategy.CalculationMethod}) ");
        Action.Red("method");
    }

    public void View()
    {
        if (CalculateStrategy.CalculationMethod == Create.StringSquareRootOf)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("{0,-8} {1,-18} {2,-18} {3,-25} {4,-15}",
                " CalcId", "CalcMethod", "Input1", "Result", "Date");
            Line.LineTwoEqual();
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var calculation in DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod))
                Console.WriteLine("{0,-8} {1,-18} {2,-18} {3,-25} {4,-15}",
                    $" {calculation.CalculationId}", $"{calculation.CalculationStrategy}",
                    $"{calculation.Input1:0.00}", $"{calculation.Result:0.00}", $"{calculation.CalculationDate}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("{0,-8} {1,-18} {2,-18} {3,-18} {4,-25} {5,-15}",
                " CalcId", "Input1", "CalcMethod", "Input2", "Result", "Date");
            Line.LineTwoEqual();
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var calculation in DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod))
                Console.WriteLine("{0,-8} {1,-18} {2,-18} {3,-18} {4,-25} {5,-15}",
                    $" {calculation.CalculationId}", $"{calculation.Input1:0.00}", $"{calculation.CalculationStrategy}",
                    $"{calculation.Input2:0.00}", $"{calculation.Result:0.00}", $"{calculation.CalculationDate}");
        }
    }
}