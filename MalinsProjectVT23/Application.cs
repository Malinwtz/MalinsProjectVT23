using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;
using ClassLibraryCalculations;

namespace MalinsProjectVT23;

public class Application
{
    public void Run()
    {
        var builder = new Builder();
        builder.BuildProject();
        var dbContext = builder.ConnectProject(); //Här skapas dbContext  - ska skickas med i hela programmet

        while (true)
        {
            var mainMenu = new MainMenu();
            var selectionFromMainMenu = mainMenu.ReturnSelectionFromMenu();
            if (selectionFromMainMenu == 0) break;
            {
                var runMainMenu = new RunMainMenu();
                runMainMenu.LoopMenu(selectionFromMainMenu, dbContext);
            }
        }
    }
}