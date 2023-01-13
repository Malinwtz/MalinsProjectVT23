using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.ShapeController.CRUD;

namespace MalinsProjectVT23.ShapeController;

public class CrudShapeRunMenu
{
    public ICrudShape CrudShape { get; set; }
    public ApplicationDbContext DbContext { get; set; }
    public ReadShape ReadShape { get; set; }
    public CrudShapeRunMenu(ApplicationDbContext dbContext, ReadShape read)
    {
        DbContext = dbContext;
        ReadShape = read;
    }
    public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext, IShape shape)
    {
        
            switch (selectedFromMenu)
            {
                case 1:
                {
                    CrudShape = new CreateShape(dbContext);
                    break;
                }
                case 2:
                {
                    Console.Clear();
                    CrudShape = ReadShape;
                    break;
                }
                case 3:
                {
                    CrudShape = new UpdateShape(dbContext, ReadShape);
                    break;
                }
                case 4:
                {
                    CrudShape = new DeleteShape(dbContext, ReadShape);
                    break;
                }
            }
            CrudShape.RunCrud(shape);
        
    }
}