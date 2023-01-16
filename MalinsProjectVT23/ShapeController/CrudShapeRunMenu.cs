using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.ShapeController.CRUD;

namespace MalinsProjectVT23.ShapeController;

public class CrudShapeRunMenu
{
    public ICrudShape CrudShape { get; set; }
    public ApplicationDbContext DbContext { get; set; }
    public ReadShape ReadShape { get; set; }
    public UpdateShape UpdateShape { get; set; }
    public CrudShapeRunMenu(ApplicationDbContext dbContext, ReadShape read, UpdateShape updateShape)
    {
        DbContext = dbContext;
        ReadShape = read;
        UpdateShape = updateShape;
    }
    public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext, IShape shape)
    {
        Console.Clear();
            switch (selectedFromMenu)
            {
                case 1:
                {
                    CrudShape = new CreateShape(dbContext);
                    break;
                }
                case 2:
                {
                    CrudShape = ReadShape;
                    break;
                }
                case 3:
                {
                    CrudShape = UpdateShape;
                    break;
                }
                case 4:
                {
                    CrudShape = new DeleteShape(dbContext, ReadShape, UpdateShape);
                    break;
                }
            }
            CrudShape.RunCrud(shape);
    }
}