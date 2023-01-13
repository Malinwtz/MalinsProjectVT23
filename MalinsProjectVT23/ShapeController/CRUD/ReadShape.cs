using MalinsProjectVT23.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryStrings;
using MalinsProjectVT23.Interface;
using Microsoft.EntityFrameworkCore;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.ShapeController.CRUD
{
    public class ReadShape : ICrudShape
    {
        public ReadShape(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public ApplicationDbContext DbContext { get; set; }

        public void RunCrud(IShape shape)
        {
            if (!DbContext.ShapeResults.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" The list of shapes is empty");
                Console.ForegroundColor = ConsoleColor.Gray;
                Action.PressEnterToContinue();
            }
            else if (DbContext.ShapeResults.Any())
            {
                View();
                Action.PressEnterToContinue();
            }
        }

        private void View()
        {
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}",
                "ShapeResultId", "Name", "Height", "Length", "Area", "Circumference", "CreatedDate");
            foreach (var shape in DbContext.ShapeResults.Include(s => s.Shape))
            {
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}",
                    $"{shape.ShapeResultId}", $"{shape.Shape.Name}", $"{shape.Height}",
                    $"{shape.Length}", $"{shape.Area}", $"{shape.Circumference}", $"{shape.Shape.Date}");
            }
        }
    }
}
