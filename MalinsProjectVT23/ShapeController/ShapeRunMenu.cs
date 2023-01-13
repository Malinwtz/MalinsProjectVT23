using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using MalinsProjectVT23.ShapeController.Shapes;

namespace MalinsProjectVT23.ShapeController;

public class ShapeRunMenu : IRunMenu
{
    public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        var displayCrudShapeMenu = new DisplayCrudShapeMenu();
        var runCrudShapeMenu = new CrudShapeRunMenu();
        var inputFromCrudShapeMenu = displayCrudShapeMenu.ReturnSelectionFromMenu();
        if (inputFromCrudShapeMenu != 0)
            switch (selectedFromMenu)
            {
                case 1:
                {
                    runCrudShapeMenu.RunMenuOptions(inputFromCrudShapeMenu, dbContext, new Rectangle());
                    break;
                }
                case 2:
                {
                    runCrudShapeMenu.RunMenuOptions(inputFromCrudShapeMenu, dbContext, new Parallelogram());
                    break;
                }
                case 3:
                {
                    runCrudShapeMenu.RunMenuOptions(inputFromCrudShapeMenu, dbContext, new Triangle());
                    break;
                }
                case 4:
                {
                    runCrudShapeMenu.RunMenuOptions(inputFromCrudShapeMenu, dbContext, new Rhombus());
                    break;
                }
            }
    }
}