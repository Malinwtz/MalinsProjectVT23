using MalinsProjectVT23.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using Action = ClassLibraryStrings.Action;
using MalinsProjectVT23.Data;
using Microsoft.EntityFrameworkCore;

namespace MalinsProjectVT23.ShapeController.CRUD
{
    public class DeleteShape : ICrudShape
    {
        public DeleteShape(ApplicationDbContext dbContext, ReadShape readShape)
        {
            DbContext = dbContext;
            Read = readShape;
        }

        public ApplicationDbContext DbContext { get; set; }
        public ReadShape Read { get; set; }

        public void RunCrud(IShape shape)
        {
            Console.Clear();
            if (!DbContext.ShapeResults.Where(s => s.Shape.Name == shape.Name)
                    .Include(s => s.Shape)
                    .Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" The list of shapes does not contain ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{shape.Name}\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Action.PressEnterToContinue();
            }
            else if (DbContext.ShapeResults.Any())
            {
                Read.View(shape);
                Line.LineOneHyphen();
                Console.Write(" Select shape by Id: ");
                var shapeIdToFind = ErrorHandling.TryInt();
                var shapeFoundById = DbContext.ShapeResults
                    .Include(s => s.Shape)
                    .FirstOrDefault(s => s.ShapeResultId == shapeIdToFind);

                DbContext.ShapeResults.Remove(shapeFoundById);
                DbContext.SaveChanges();
                Action.Successful(" Shape deleted");
                Action.PressEnterToContinue();

            }
        }
    }
}
