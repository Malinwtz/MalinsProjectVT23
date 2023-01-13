using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.CalculatorController.CRUD
{
    public class DeleteCalculation : ICrudCalculation
    {
        public DeleteCalculation(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public ApplicationDbContext DbContext { get; set; }
       

        public void RunCrud(int selectedFromMenu, ApplicationDbContext dbContext, ICalculateStrategy calculateStrategy)
        {
            Console.WriteLine(" Delete Calculation");
            Console.ReadKey();
        }
    }
}
