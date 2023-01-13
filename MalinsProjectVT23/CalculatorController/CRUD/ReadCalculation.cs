using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using Microsoft.EntityFrameworkCore;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController.CRUD
{
    public class ReadCalculation : ICrudCalculation
    {
        public ReadCalculation(ApplicationDbContext dbContext, ICalculateStrategy calculateStrategy)
        {
            DbContext = dbContext;
        }
        public ApplicationDbContext DbContext { get; set; }
        public ICalculateStrategy CalculateStrategy { get; set; }
       
        public void RunCrud(int selectedFromMenu)
        {
            if (!DbContext.Calculations.Any()) //visa utifrån calcstrategy
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" The list of calculations is empty ");
                ClassLibraryStrings.Action.PressEnterToContinue();
            }
            else if (DbContext.Calculations.Any())//specifik calc
            {
                View();
                Action.PressEnterToContinue();
            }
        }
        public void View() //visa utifrån calcstrategy . lägg till calcstrategy i calculation
        {
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}",
                "CalculationId", "Input1", "Input2", "Result", "Date");

            foreach (var calculation in DbContext.Calculations)
            {
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}",
                    $"{calculation.CalculationId}", $"{calculation.Input1}", $"{calculation.Input2}", $"{calculation.Result}", $"{calculation.CalculationDate}");
            }
        }
    }
}
