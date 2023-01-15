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
            //om det är roten ur blir det en annan beräkning. Annars är det bara att räkna om
            Console.Clear();
            if (!DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod).Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" The list of calculation does not contain ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{CalculateStrategy.CalculationMethod}\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Action.PressEnterToContinue();
            }
            else if (DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod)
                     .Any())
            {
                ReadCalculation.View();
                Line.LineOneHyphen();
                Console.Write(" Select calculation by Id: ");
                var calculationIdToFind = ErrorHandling.TryInt();
                var calculationFoundById = DbContext.Calculations
                    .FirstOrDefault(s => s.CalculationId == calculationIdToFind);

                decimal newValue;
                int selectionFromUser = 0;
                if (CalculateStrategy.CalculationMethod != "Square root of")
                {
                    Action.Successful($"\n Chosen calculation Id {calculationFoundById.CalculationId}: " +
                                      $"{calculationFoundById.Input1} {calculationFoundById.CalculationStrategy} {calculationFoundById.Input2} = {calculationFoundById.Result}\n");

                    var endAlternative = 2;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" Select what you want to change ");
                    Console.WriteLine(" 1. Input 1");
                    Console.WriteLine($" {endAlternative}. Input 2");
                    Console.ForegroundColor = ConsoleColor.Gray;
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
                    Console.Write(
                        $"\n New result: {calculationFoundById.Input1} {CalculateStrategy.CalculationMethod} {calculationFoundById.Input2} = {CalculatedResult}\n");
                }
                else if (CalculateStrategy.CalculationMethod == "Square root of")
                {
                    Action.Successful($"\n Chosen calculation Id {calculationFoundById.CalculationId}: " +
                                      $" {calculationFoundById.CalculationStrategy} {calculationFoundById.Input1} = {calculationFoundById.Result}\n");

                    Console.WriteLine("1. Set a new value");
                    ReturnFromMenuClass.ExitMenu();
                    selectionFromUser = ReturnFromMenuClass.ReturnFromMenu(1);
                    
                    if (selectionFromUser == 0) return;
                    newValue = SetANewValueToCalculation();
                    calculationFoundById.Input1 = newValue;
                    
                    CalculatedResult = CalculateStrategy.Calculate(calculationFoundById.Input1, 0);
                    Console.Write(
                        $"\n New result: {CalculateStrategy.CalculationMethod} {calculationFoundById.Input1} = {CalculatedResult}\n");
                }

                DbContext.SaveChanges();
                Action.Successful(" Value changed!");
                Action.PressEnterToContinue();
            }
        }

        private static decimal SetANewValueToCalculation()
        {
            Console.Write(" Set a new value: ");
            var newValue = ErrorHandling.TryDecimal();
            return newValue;
        }
    }
}
