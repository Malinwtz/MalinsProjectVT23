using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;
using ClassLibraryCalculations;
using MalinsProjectVT23.ShapeController.CRUD;

namespace MalinsProjectVT23;

public class Application
{

    public void Run()
    {
        var builder = new Builder();
        builder.BuildProject();
        var dbContext = builder.ConnectProject(); //Här skapas dbContext  - ska skickas med i hela programmet
        var readShape = new ReadShape(dbContext);
        
        while (true)
        {
            var mainMenu = new MainMenu();
            var selectionFromMainMenu = mainMenu.ReturnSelectionFromMenu();
            if (selectionFromMainMenu == 0) break;
            {
                var runMainMenu = new RunMainMenu(dbContext, readShape);
                runMainMenu.LoopMenu(selectionFromMainMenu, dbContext);
            }
        }
    }
}