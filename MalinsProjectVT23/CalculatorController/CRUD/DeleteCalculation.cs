using ClassLibraryCalculations.Interface;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using Microsoft.EntityFrameworkCore;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController.CRUD
{
    public class DeleteCalculation : ICrudCalculation
    {
        public DeleteCalculation(ApplicationDbContext dbContext, ReadCalculation readCalculation)
        {
            DbContext = dbContext;
            ReadCalculation = readCalculation;
        }
        public ApplicationDbContext DbContext { get; set; }
        public ReadCalculation ReadCalculation { get; set; }

        public void RunCrud(int selectedFromMenu, ApplicationDbContext dbContext, ICalculateStrategy calculateStrategy)
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
                Console.Write(" Select calculation by Id: ");
                var calculationIdToFind = ErrorHandling.TryInt();
                var calculationFoundById = DbContext.Calculations.FirstOrDefault(s => s.CalculationId == calculationIdToFind);

                DbContext.Calculations.Remove(calculationFoundById);
                DbContext.SaveChanges();
                Action.Successful(" Calculation deleted");
                Action.PressEnterToContinue();
            }
        }
    }
}
