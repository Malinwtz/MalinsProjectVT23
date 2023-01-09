namespace MalinsProjectVT23;

internal class Application
{
    public void Run()
    {
        var builder = new Builder();
        builder.BuildProject();
        var dbContext = builder.ConnectProject();

        while (true)
        {
            var mainMenu = new MainMenu();
            var inputFromMainMenu = mainMenu.ReturnSelectionFromMenu();
            mainMenu.LoopMenu(inputFromMainMenu);
        }
    }
}