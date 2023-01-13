using MalinsProjectVT23.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryStrings;
using Microsoft.EntityFrameworkCore;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.ShapeController.CRUD
{
    public class ReadShape
    {
        public ReadShape(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public ApplicationDbContext DbContext { get; set; }

        public void Read()
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
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-10}",
                "ShapeResultId", "Name", "Height", "Length", "Area", "Circumference", "CreatedDate");
            foreach (var shape in DbContext.ShapeResults.Include(s => s.Shape))
            {
                Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-10}",
                    $"{shape.ShapeResultId}", $"{shape.Shape.Name}", $"{shape.Height}",
                    $"{shape.Length}", $"{shape.Area}", $"{shape.Circumference}", $"{shape.Shape.Date}");
            }
        }
    }
}
