using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryCalculations;
using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.CalculatorController
{
    public class CalculatorRunMenu : IRunSecondMenu 
    {
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
            //ta med räknesättet och gå vidare och välj crudtyp  - Runcrudmenu
            while (true)
            {
                var displayCrudCalculatorMenu = new DisplayCrudCalculatorMenu();
                var selectedFromCrudCalculationMenu = displayCrudCalculatorMenu.ReturnSelectionFromMenu();
                if (selectedFromCrudCalculationMenu == 0) break;
                var crudCalculatorRunMenu = new CrudCalculatorRunMenu();
                crudCalculatorRunMenu.RunMenuOptions(selectedFromCrudCalculationMenu, dbContext, CalculateStrategy);
            }
        }
    }
}
