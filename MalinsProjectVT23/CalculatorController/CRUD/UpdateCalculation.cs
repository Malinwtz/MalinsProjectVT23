using ClassLibraryCalculations.Interface;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using Microsoft.EntityFrameworkCore;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController.CRUD
{
    public class UpdateCalculation : ICrudCalculation
    {
        public UpdateCalculation(ApplicationDbContext dbContext, ReadCalculation readCalculation,
            ICalculateStrategy calculateStrategy)
        {
            DbContext = dbContext;
            CalculateStrategy = calculateStrategy;
            ReadCalculation = readCalculation;
        }

        public ApplicationDbContext DbContext { get; set; }
        public ICalculateStrategy CalculateStrategy { get; set; }
        public ReadCalculation ReadCalculation { get; set; }
        public decimal CalculatedResult { get; set; }
        public void RunCrud(int selectedFromMenu)
        {
            Console.Clear();
            if (!DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod).Any())
            {
                Action.NotSuccessful(" The list of calculation does not contain ");
                Action.Magenta($"{CalculateStrategy.CalculationMethod}\n");
                Action.PressEnterToContinue();
            }
            else if (DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod)
                     .Any())
            {
                ReadCalculation.View();
                Line.LineOneHyphen();
                Action.Magenta(" Select calculation by Id \n");

                var calculationFoundById = FindCalculationById(CalculateStrategy);

                decimal newValue;
                int selectionFromUser = 0;
                if (CalculateStrategy.CalculationMethod != "Square root of")
                {
                    Action.Successful($"\n Chosen calculation Id {calculationFoundById.CalculationId}: " +
                                      $"{calculationFoundById.Input1} {calculationFoundById.CalculationStrategy} {calculationFoundById.Input2} = {calculationFoundById.Result}\n");

                    var endAlternative = 2;
                    Action.Magenta(" Select what you want to change ");
                    Action.Magenta(" 1. Input 1");
                    Action.Magenta($" {endAlternative}. Input 2");
                    ReturnFromMenuClass.ExitMenu();
                    selectionFromUser = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
                    
                    if (selectionFromUser == 0) return;
                    newValue = SetANewValueToCalculation();

                    switch (selectionFromUser)
                    {
                        case 1:
                        {
                            calculationFoundById.Input1 = newValue;
                            break;
                        }
                        case 2:
                        {
                            calculationFoundById.Input2 = newValue;
                            break;
                        }
                    }

                    CalculatedResult = CalculateStrategy.Calculate(calculationFoundById.Input1, calculationFoundById.Input2);
                    Action.Magenta(
                        $"\n New result: {calculationFoundById.Input1} {CalculateStrategy.CalculationMethod} {calculationFoundById.Input2} = {CalculatedResult}\n");
                }
                else if (CalculateStrategy.CalculationMethod == "Square root of")
                {
                    Action.Successful($"\n Chosen calculation Id {calculationFoundById.CalculationId}: " +
                                      $" {calculationFoundById.CalculationStrategy} {calculationFoundById.Input1} = {calculationFoundById.Result}\n");

                    Action.Magenta(" 1. Set a new value");
                    ReturnFromMenuClass.ExitMenu();
                    selectionFromUser = ReturnFromMenuClass.ReturnFromMenu(1);
                    
                    if (selectionFromUser == 0) return;
                    newValue = SetANewValueToCalculation();
                    calculationFoundById.Input1 = newValue;
                    
                    CalculatedResult = CalculateStrategy.Calculate(calculationFoundById.Input1, 0);
                    Action.Magenta(
                        $"\n New result: {CalculateStrategy.CalculationMethod} {calculationFoundById.Input1} = {CalculatedResult}\n");
                }

                DbContext.SaveChanges();
                Action.Successful(" Value changed!");
                Action.PressEnterToContinue();
            }
        }

        public Calculation FindCalculationById(ICalculateStrategy calculateStrategy)
        {
            while (true)
                try
                {
                    Action.White(" Write id:");
                    var calculationIdToFind = Convert.ToInt32(Console.ReadLine());
                    if (calculationIdToFind == 0) return null;

                    var calculationFoundById = DbContext.Calculations
                        .Where(c=>c.CalculationStrategy == calculateStrategy.CalculationMethod)
                        .FirstOrDefault(s => s.CalculationId == calculationIdToFind);

                    if (calculationFoundById != null) return calculationFoundById;
                    Action.NotSuccessful(" Id does not exist");
                }
                catch
                {
                    Action.NotSuccessful(" Wrong input");
                }
        }

        private static decimal SetANewValueToCalculation()
        {
            Action.White(" Set a new value: ");
            var newValue = ErrorHandling.TryDecimal();
            return newValue;
        }
    }
}
