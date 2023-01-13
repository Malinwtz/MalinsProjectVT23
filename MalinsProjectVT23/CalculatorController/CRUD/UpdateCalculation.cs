using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.CalculatorController.CRUD
{
    public class UpdateCalculation : ICrudCalculation
    {
        public UpdateCalculation(ApplicationDbContext dbContext, ICalculateStrategy calculateStrategy)
        {
            DbContext = dbContext;
            CalculateStrategy = calculateStrategy;
        }
        public ApplicationDbContext DbContext { get; set; }
        public ICalculateStrategy CalculateStrategy { get; set; }
        public void RunCrud(int selectedFromMenu)
        {
            Console.WriteLine(" Update Calculation");
            Console.ReadKey();
            //om det är roten ur blir det en annan beräkning. Annars är det bara att räkna om
        }
    }
}
