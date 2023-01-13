using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.ShapeController.CRUD;

namespace MalinsProjectVT23.ShapeController;

public class CrudShapeRunMenu
{
    public ICrudShape CrudShape { get; set; }

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
                CrudShape = new ReadShape(dbContext);
                break;
            }
            case 3:
            {
                //CrudShape = new UpdateShape(dbContext);
                Console.WriteLine("Update shape not finished");
                Console.ReadKey();
                break;
            }
            case 4:
            {
                //CrudShape = new DeleteShape(dbContext);
                Console.WriteLine("Delete shape not finished");
                Console.ReadKey();
                break;
            }
        }

        CrudShape.RunCrud(shape);
    }
}