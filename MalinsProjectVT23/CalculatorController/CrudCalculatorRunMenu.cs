using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.CalculatorController.CRUD;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.CalculatorController;

public class CrudCalculatorRunMenu
{
    public CrudCalculatorRunMenu(ApplicationDbContext dbContext, ReadCalculation readCalculation, 
        UpdateCalculation updateCalculation, ICalculateStrategy calculateStrategy)
    {
        DbContext = dbContext;
        CalculateStrategy = calculateStrategy;
        ReadCalculation = readCalculation;
        UpdateCalculation = updateCalculation;
    }

    public ApplicationDbContext DbContext { get; set; }
    public ReadCalculation ReadCalculation { get; set; }
    public UpdateCalculation UpdateCalculation { get; set; }
    public ICalculateStrategy CalculateStrategy { get; set; }
    public ICrudCalculation CrudCalculation { get; set; } 

    public void RunMenuOptions(int selectedFromMenu)
    {
        Console.Clear();
        switch (selectedFromMenu)
        {
            case 1:
            {
                CrudCalculation = new CreateCalculation(DbContext, CalculateStrategy);
                break;
            }
            case 2:
            {
                CrudCalculation = ReadCalculation;
                break;
            }
            case 3:
            {
                CrudCalculation = UpdateCalculation;
                break;
            }
            case 4:
            {
                CrudCalculation = new DeleteCalculation(DbContext, ReadCalculation, UpdateCalculation, CalculateStrategy);
                break;
            }
        }
        CrudCalculation.RunCrud(selectedFromMenu);
    }
}