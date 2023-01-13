using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;
using ClassLibraryCalculations;
using MalinsProjectVT23.CalculatorController.CRUD;
using MalinsProjectVT23.ShapeController.CRUD;

namespace MalinsProjectVT23;

public class Application
{

    public void Run()
    {
        var builder = new Builder();
        builder.BuildProject();
        var dbContext = builder.ConnectProject(); 
        var readShape = new ReadShape(dbContext);
        var mainMenu = new MainMenu();
        var runMainMenu = new RunMainMenu(dbContext, readShape);

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