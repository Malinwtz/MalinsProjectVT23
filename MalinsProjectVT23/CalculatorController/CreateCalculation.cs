using ClassLibraryCalculations.Interface;
using ClassLibraryCalculations;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.CalculatorController
{
    public class CreateCalculation
    {
        public ICalculateStrategy CalculateStrategy { get; set; }
        public decimal CalculatedResult { get; set; }
        public ApplicationDbContext DbContext { get; set; }
        public CreateCalculation(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
        {
            Console.Clear();
            Console.Write(" Write number to calculate: ");
            var userInputNumberToAdd1 = ErrorHandling.TryInt();
            var userInputNumberToAdd2 = 0;
            if (selectedFromMenu != 5)
            {
                Console.Write(" Write number 2 to calculate: ");
                userInputNumberToAdd2 = ErrorHandling.TryInt();
            }

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

            if (selectedFromMenu == 5)
            {
                CalculatedResult = CalculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
                Console.Write($" Result: {CalculateStrategy.CalculationMethod} {userInputNumberToAdd1} " +
                              $"= {CalculatedResult}");
            }
            else
            {
                CalculatedResult = CalculateStrategy.Calculate(userInputNumberToAdd1, userInputNumberToAdd2);
                Console.Write($" Result: {userInputNumberToAdd1} {CalculateStrategy.CalculationMethod} {userInputNumberToAdd2} " +
                              $"= {CalculatedResult}");
            }

            DbContext.Calculations.Add(new Calculation
            {
                Input1 = userInputNumberToAdd1,
                Input2 = userInputNumberToAdd2,
                Result = CalculatedResult,
                Date = DateTime.Now
            });
            DbContext.SaveChanges();
        }
    }
}
