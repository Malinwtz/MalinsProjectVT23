using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.CalculatorController.CRUD
{
    public class UpdateCalculation : ICrudCalculation
    {
        public UpdateCalculation(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public ApplicationDbContext DbContext { get; set; }
       
        public void RunCrud(int selectedFromMenu, ApplicationDbContext dbContext, ICalculateStrategy calculateStrategy)
        {
            Console.WriteLine(" Update Calculation");
            Console.ReadKey();
        }
    }
}
