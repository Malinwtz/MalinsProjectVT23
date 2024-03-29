﻿using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;
using ClassLibraryCalculations;
using MalinsProjectVT23.CalculatorController.CRUD;
using MalinsProjectVT23.ShapeController.CRUD;
using MalinsProjectVT23.ShapeController.Shapes;

namespace MalinsProjectVT23;

public class Application
{

    public void Run()
    {
        var shapeEnum = new ShapeEnum();
        var builder = new Builder(shapeEnum);
        builder.BuildProject();
        var dbContext = builder.ConnectProject(); 
        var readShape = new ReadShape(dbContext);
        var updateShape = new UpdateShape(dbContext, readShape);
        var mainMenu = new MainMenu();
        var runMainMenu = new RunMainMenu(dbContext, readShape, updateShape);

        while (true)
        {
            var selectionFromMainMenu = mainMenu.ReturnSelectionFromMenu();
            if (selectionFromMainMenu == 0) break;
            {
                runMainMenu.LoopMenu(selectionFromMainMenu, dbContext);
            }
        }
    }
}