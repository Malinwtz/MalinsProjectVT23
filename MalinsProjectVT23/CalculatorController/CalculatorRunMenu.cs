using ClassLibraryCalculations;
using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.CalculatorController.CRUD;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.CalculatorController;

public class CalculatorRunMenu : IRunSecondMenu
{
    public CalculatorRunMenu(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }
    public ICalculateStrategy CalculateStrategy { get; set; }

    public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        switch (selectedFromMenu)
        {
            case 1:
            {
                CalculateStrategy = new AdditionCalculateStrategy();
                break;
            }
            case 2:
            {
                CalculateStrategy = new SubtractCalculateStrategy();
                break;
            }
            case 3:
            {
                CalculateStrategy = new MultiplyCalculateStrategy();
                break;
            }
            case 4:
            {
                CalculateStrategy = new DivideCalculateStrategy();
                break;
            }
            case 5:
            {
                CalculateStrategy = new SquareRootCalculateStrategy();
                break;
            }
            case 6:
            {
                CalculateStrategy = new ModulusCalculateStrategy();
                break;
            }
        }
        
        while (true)
        {
            var displayCrudCalculatorMenu = new DisplayCrudCalculatorMenu();
            var selectedFromCrudCalculationMenu = displayCrudCalculatorMenu.ReturnSelectionFromMenu();
            if (selectedFromCrudCalculationMenu == 0) break;

            var readCalculation = new ReadCalculation(DbContext, CalculateStrategy);
            var crudCalculatorRunMenu = new CrudCalculatorRunMenu(DbContext, readCalculation, CalculateStrategy);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            crudCalculatorRunMenu.RunMenuOptions(selectedFromCrudCalculationMenu);
        }
    }
}