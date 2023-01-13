using MalinsProjectVT23.CalculatorController;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.RockScissorPaperGameController;
using MalinsProjectVT23.ShapeController;

namespace MalinsProjectVT23.MainMenuController;

public class RunMainMenu
{
    public IRunSecondMenu RunMenu { get; set; }
    public IDisplayMenu DisplayMenu { get; set; }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        switch (selectedFromMenu)
        {
            case 1:
            {
                DisplayMenu = new DisplayShapeMenu();
                RunMenu = new ShapeRunMenu();
                break;
            }
            case 2:
            {
                DisplayMenu = new DisplayCalculatorMenu();
                RunMenu = new CalculatorRunMenu();
                break;
            }
            case 3:
            {
                DisplayMenu = new DisplayRSPGameMenu();
                RunMenu = new RockScissorPaperRunMenu();
                break;
            }
        }

        while (true)
        {
            var inputFromChosenMenu = DisplayMenu.ReturnSelectionFromMenu(); //visar räknesätt
            if (inputFromChosenMenu == 0) break;
            RunMenu.RunMenuOptions(inputFromChosenMenu, dbContext);
        }
    }
}