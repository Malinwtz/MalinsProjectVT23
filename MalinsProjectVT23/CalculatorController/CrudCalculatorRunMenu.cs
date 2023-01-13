using MalinsProjectVT23.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryCalculations;
using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.CalculatorController.CRUD;
using MalinsProjectVT23.Data;

namespace MalinsProjectVT23.CalculatorController
{
    public class CrudCalculatorRunMenu 
    {
        public ReadCalculation ReadCalculation { get; set; }
        public ICalculateStrategy CalculateStrategy { get; set; }
        public ICrudCalculation CrudCalculation { get; set; }
        public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext, ICalculateStrategy calculateStrategy)
        {
            switch (selectedFromMenu)
            {
                case 1:
                {
                    CrudCalculation = new CreateCalculation(dbContext);
                    break;
                }
                case 2:
                {
                    CrudCalculation = ReadCalculation;
                    break;
                }
                case 3:
                {
                    CrudCalculation = new UpdateCalculation(dbContext);
                    break;
                }
                case 4:
                {
                    CrudCalculation = new DeleteCalculation(dbContext, ReadCalculation);
                    break;
                }
            }
            //ta med räknesätt och typ av crud och gå vidare till cruddandet av uträkningen
            CrudCalculation.RunCrud(selectedFromMenu, dbContext, CalculateStrategy);
        }
    }
}
