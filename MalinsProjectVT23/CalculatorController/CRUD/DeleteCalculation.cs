﻿using ClassLibraryCalculations.Interface;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.CalculatorController.CRUD;

public class DeleteCalculation : ICrudCalculation
{
    public DeleteCalculation(ApplicationDbContext dbContext, ReadCalculation readCalculation,
        UpdateCalculation updateCalculation, ICalculateStrategy calculateStrategy)
    {
        DbContext = dbContext;
        ReadCalculation = readCalculation;
        CalculateStrategy = calculateStrategy;
        UpdateCalculation = updateCalculation;
    }

    public ApplicationDbContext DbContext { get; set; }
    public ReadCalculation ReadCalculation { get; set; }
    public UpdateCalculation UpdateCalculation { get; set; }
    public ICalculateStrategy CalculateStrategy { get; set; }

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
            var calculationFoundById = UpdateCalculation.FindCalculationById(CalculateStrategy);
            UpdateCalculation.ShowChosenCalculation(calculationFoundById);

            var userInputDelete = AskIfDeleteCalculation();

            if (userInputDelete.ToUpper() == "Y")
            {
                DbContext.Calculations.Remove(calculationFoundById);
                DbContext.SaveChanges();
                Action.Successful(" Calculation deleted");
            }
            else
            {
                Action.Magenta(" Calculation not deleted");
            }
        }

        Action.PressEnterToContinue();
    }

    private static string? AskIfDeleteCalculation()
    {
        Action.Red("\n\n Delete calculation? Press");
        Action.White(" Y");
        Action.Red(" to delete.\n" + " Press any other key to continue without deleting calculation.\n");
        Action.White(" Write input: ");
        var userInputDelete = Console.ReadLine();
        return userInputDelete;
    }
}