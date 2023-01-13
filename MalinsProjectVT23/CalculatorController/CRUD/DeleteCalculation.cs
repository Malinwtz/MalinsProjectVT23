using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.CalculatorController.CRUD
{
    public class DeleteCalculation : ICrud
    {
        public DeleteCalculation(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public ApplicationDbContext DbContext { get; set; }
        public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext)
        {
            throw new NotImplementedException();
        }
    }
}
