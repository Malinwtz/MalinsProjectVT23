using ClassLibraryCalculations.Interface;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController.CRUD;

public class DeleteCalculation : ICrudCalculation
{
    public DeleteCalculation(ApplicationDbContext dbContext, ReadCalculation readCalculation, UpdateCalculation updateCalculation,
        ICalculateStrategy calculateStrategy)
    {
        DbContext = dbContext;
        ReadCalculation = readCalculation;
        CalculateStrategy = calculateStrategy;
        UpdateCalculation = updateCalculation;
    }

    public ApplicationDbContext DbContext { get; set; }
    public ReadCalculation ReadCalculation { get; set; }
    public UpdateCalculation UpdateCalculation { get; set; }
    public ICalculateStrategy CalculateStrategy { get; set; }

    public void RunCrud(int selectedFromMenu)
    {
        Console.Clear();
        if (!DbContext.Calculations.Any())
        {
            Action.NotSuccessful(" The list of calculations is empty ");
            Action.PressEnterToContinue();
        }
        else if (DbContext.ShapeResults.Any())
        {
            ReadCalculation.View();
            Line.LineOneHyphen();
            Action.White(" Select calculation by Id \n");

            var calculationFoundById = UpdateCalculation.FindCalculationById(CalculateStrategy);
            DbContext.Calculations.Remove(calculationFoundById);
            DbContext.SaveChanges();
            Action.Successful(" Calculation deleted");
            Action.PressEnterToContinue();
        }
    }
}