using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.CalculatorController.CRUD
{
    public class ReadCalculation : ICrudCalculation
    {
        public ReadCalculation(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public ApplicationDbContext DbContext { get; set; }
       
        public void RunCrud(int selectedFromMenu, ApplicationDbContext dbContext, ICalculateStrategy calculateStrategy)
        {
            Console.WriteLine(" Read Calculation");
            Console.ReadKey();
        }
    }
}
