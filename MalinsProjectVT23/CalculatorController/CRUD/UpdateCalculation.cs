using ClassLibraryCalculations.Interface;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController.CRUD;

public class UpdateCalculation : ICrudCalculation
{
    public UpdateCalculation(ApplicationDbContext dbContext, ReadCalculation readCalculation,
        CreateCalculation create, ICalculateStrategy calculateStrategy)
    {
        DbContext = dbContext;
        CalculateStrategy = calculateStrategy;
        ReadCalculation = readCalculation;
        Create = create;
    }

    public ApplicationDbContext DbContext { get; set; }
    public ICalculateStrategy CalculateStrategy { get; set; }
    public ReadCalculation ReadCalculation { get; set; }
    public CreateCalculation Create { get; set; }
    public decimal CalculatedResult { get; set; }

    public void RunCrud(int selectedFromMenu)
    {
        Console.Clear();
        if (!DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod).Any())
        {
            ReadCalculation.ListOfCalculationIsEmpty();
        }
        else if (DbContext.Calculations.Where(c => c.CalculationStrategy == CalculateStrategy.CalculationMethod).Any())
        {
            ReadCalculation.View();
            Line.LineOneHyphen();

            Action.Magenta("\n Select calculation by Id \n");
            var calculationFoundById = FindCalculationById(CalculateStrategy);
            ShowChosenCalculation(calculationFoundById);

            decimal newValue;
            var selectionFromUser = 0;
            if (CalculateStrategy.CalculationMethod != Create.StringSquareRootOf)
            {
                selectionFromUser = MiniMenuSelectChangeOfInput();
                if (selectionFromUser == 0) return;

                newValue = SetANewValueToCalculation();
                SetNewValueToCalculationInputOneOrTwo(selectionFromUser, calculationFoundById, newValue);

                CalculatedResult =
                    CalculateStrategy.Calculate(calculationFoundById.Input1, calculationFoundById.Input2);
                Action.Magenta($"\n New result: {calculationFoundById.Input1} {CalculateStrategy.CalculationMethod} " +
                               $"{calculationFoundById.Input2} = {CalculatedResult}\n");
            }
            else if (CalculateStrategy.CalculationMethod == Create.StringSquareRootOf)
            {
                selectionFromUser = MiniMenuSelectChangeOfSecondInput();
                if (selectionFromUser == 0) return;

                newValue = SetANewValueToCalculation();
                calculationFoundById.Input1 = newValue;

                CalculatedResult = CalculateStrategy.Calculate(calculationFoundById.Input1, 0);
                Action.Magenta(
                    $"\n New result: {CalculateStrategy.CalculationMethod} {calculationFoundById.Input1} = {CalculatedResult}\n");
            }

            Action.PressEnterToContinue();
            Console.Clear();
            Create.SaveChangesToDataBase();
        }

        Action.PressEnterToContinue();
    }

    private static void SetNewValueToCalculationInputOneOrTwo(int selectionFromUser, Calculation calculationFoundById,
        decimal newValue)
    {
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
    }

    private static int MiniMenuSelectChangeOfSecondInput()
    {
        int selectionFromUser;
        Action.Magenta("\n 1. Set a new value");
        ReturnFromMenuClass.ExitMenu();
        selectionFromUser = ReturnFromMenuClass.ReturnFromMenu(1);
        return selectionFromUser;
    }

    private static int MiniMenuSelectChangeOfInput()
    {
        int selectionFromUser;
        var endAlternative = 2;
        Action.Magenta("\n\n Select what you want to change\n");
        Action.White(" 1. Input 1\n");
        Action.White($" {endAlternative}. Input 2\n");
        ReturnFromMenuClass.ExitMenu();
        selectionFromUser = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return selectionFromUser;
    }

    public Calculation FindCalculationById(ICalculateStrategy calculateStrategy)
    {
        while (true)
            try
            {
                Action.White(" Write id: ");
                var calculationIdToFind = Convert.ToInt32(Console.ReadLine());

                var calculationFoundById = DbContext.Calculations
                    .Where(c => c.CalculationStrategy == calculateStrategy.CalculationMethod)
                    .FirstOrDefault(s => s.CalculationId == calculationIdToFind);

                if (calculationFoundById != null) return calculationFoundById;
                Action.NotSuccessful(" Id does not exist");
            }
            catch
            {
                Action.NotSuccessful(" Wrong input");
            }
    }

    public void ShowChosenCalculation(Calculation foundCalculation)
    {
        Console.Clear();
        Action.DarkMagenta(
            $"\n Chosen calculation:\n\n Id {foundCalculation.CalculationId}, Date {foundCalculation.CalculationDate}\n");
        if (foundCalculation.CalculationStrategy == Create.StringSquareRootOf)
            Action.Magenta(
                $" {foundCalculation.CalculationStrategy} {foundCalculation.Input1} = {foundCalculation.Result} ");
        else
            Action.Magenta(
                $" {foundCalculation.Input1} {foundCalculation.CalculationStrategy} {foundCalculation.Input2} = {foundCalculation.Result} \n");
    }

    private static decimal SetANewValueToCalculation()
    {
        Action.White(" Set a new value: ");
        var newValue = ErrorHandling.TryDecimal();
        return newValue;
    }
}