using ClassLibraryCalculations.Interface;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController.CRUD;

public class DeleteCalculation : ICrudCalculation
{
    public DeleteCalculation(ApplicationDbContext dbContext, ReadCalculation readCalculation,
        ICalculateStrategy calculateStrategy)
    {
        DbContext = dbContext;
        ReadCalculation = readCalculation;
        CalculateStrategy = calculateStrategy;
    }

    public ApplicationDbContext DbContext { get; set; }
    public ReadCalculation ReadCalculation { get; set; }
    public ICalculateStrategy CalculateStrategy { get; set; }

    public void RunCrud(int selectedFromMenu)
    {
        Console.Clear();
        if (!DbContext.Calculations.Any())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" The list of calculations is empty ");
            Action.PressEnterToContinue();
        }
        else if (DbContext.ShapeResults.Any())
        {
            // ReadCalculation.View();
            Line.LineOneHyphen();
            Action.White(" Select calculation by Id: ");
            var calculationIdToFind = ErrorHandling.TryInt();
            var calculationFoundById =
                DbContext.Calculations.FirstOrDefault(s => s.CalculationId == calculationIdToFind);

            DbContext.Calculations.Remove(calculationFoundById);
            DbContext.SaveChanges();
            Action.Successful(" Calculation deleted");
            Action.PressEnterToContinue();
        }
    }
}