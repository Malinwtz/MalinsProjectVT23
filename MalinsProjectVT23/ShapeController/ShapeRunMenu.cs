using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using MalinsProjectVT23.ShapeController.CRUD;
using MalinsProjectVT23.ShapeController.Shapes;

namespace MalinsProjectVT23.ShapeController;

public class ShapeRunMenu : IRunSecondMenu
{
    public ApplicationDbContext DbContext { get; set; }
    public ReadShape ReadShape { get; set; }

    public ShapeRunMenu(ApplicationDbContext dbContext, ReadShape readShape)
    {
        DbContext = dbContext;
        ReadShape = readShape;
    }
    public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        var displayCrudShapeMenu = new DisplayCrudShapeMenu();
        var runCrudShapeMenu = new CrudShapeRunMenu(DbContext, ReadShape);
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