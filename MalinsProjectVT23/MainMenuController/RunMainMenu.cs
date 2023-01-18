using MalinsProjectVT23.CalculatorController;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.RockScissorPaperGameController;
using MalinsProjectVT23.ShapeController;
using MalinsProjectVT23.ShapeController.CRUD;

namespace MalinsProjectVT23.MainMenuController;

public class RunMainMenu
{
    public RunMainMenu(ApplicationDbContext dbContext, ReadShape readShape, UpdateShape updateShape)
    {
        DbContext = dbContext;
        ReadShape = readShape;
        UpdateShape = updateShape;
    }

    public ApplicationDbContext DbContext { get; set; }
    public ReadShape ReadShape { get; set; }
    public UpdateShape UpdateShape { get; set; }
    public IRunSecondMenu RunMenu { get; set; }
    public IDisplayMenu DisplayMenu { get; set; }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        Console.Clear();
        switch (selectedFromMenu)
        {
            case 1:
            {
                DisplayMenu = new DisplayShapeMenu();
                RunMenu = new ShapeRunMenu(DbContext, ReadShape, UpdateShape);
                break;
            }
            case 2:
            {
                DisplayMenu = new DisplayCalculatorMenu();
                RunMenu = new CalculatorRunMenu(DbContext);
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
            var inputFromChosenMenu = DisplayMenu.ReturnSelectionFromMenu();
            if (inputFromChosenMenu == 0) break;
            Console.Clear();
            RunMenu.RunMenuOptions(inputFromChosenMenu, dbContext);
        }
    }
}