using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.CalculatorController.CRUD;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.CalculatorController;

public class CrudCalculatorRunMenu
{
    public CrudCalculatorRunMenu(ApplicationDbContext dbContext, ReadCalculation readCalculation, ICalculateStrategy calculateStrategy)
    {
        DbContext = dbContext;
        CalculateStrategy = calculateStrategy;
        ReadCalculation = readCalculation;
    }

    public ApplicationDbContext DbContext { get; set; }
    public ReadCalculation ReadCalculation { get; set; }
    public ICalculateStrategy CalculateStrategy { get; set; }
    public ICrudCalculation CrudCalculation { get; set; } //set to an instance?

    public void RunMenuOptions(int selectedFromMenu)
    {
        switch (selectedFromMenu)
        {
            case 1:
            {
                CrudCalculation = new CreateCalculation(DbContext, CalculateStrategy);
                break;
            }
            case 2:
            {
                CrudCalculation = new ReadCalculation(DbContext, CalculateStrategy);
                break;
            }
            case 3:
            {
                CrudCalculation = new UpdateCalculation(DbContext, ReadCalculation, CalculateStrategy);
                break;
            }
            case 4:
            {
                CrudCalculation = new DeleteCalculation(DbContext, ReadCalculation, CalculateStrategy);
                break;
            }
        }
        CrudCalculation.RunCrud(selectedFromMenu);
    }
}