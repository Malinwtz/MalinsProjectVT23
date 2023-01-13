using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.ShapeController.CRUD;

namespace MalinsProjectVT23.ShapeController
{
    public class CrudShapeRunMenu //ISecondMenu
    {
        public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext, IShape shape)
        {
            var create = new CreateShape(dbContext);
            var read = new ReadShape(dbContext);
            // var update = new UpdateShape(dbContext);
            //var delete = new DeleteShape(dbContext);
            switch (selectedFromMenu)
            {
                case 1:
                {
                    create.Create(shape);
                    break;
                }
                case 2:
                {
                    read.Read();
                    break;
                }
                case 3:
                {
                    //update.Update(shape);
                    Console.WriteLine("Update shape not finished");
                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    //delete.Delete(shape);
                    Console.WriteLine("Delete shape not finished");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
