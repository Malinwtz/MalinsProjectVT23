using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;

namespace MalinsProjectVT23.ShapeController
{
    public class CrudShapeMenu
    {
        public int ReturnSelectionFromMenu()
        {
            Console.Clear();
            var endAlternative = 4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Crud Shape Menu");
            Line.LineThreeStar();
            Console.WriteLine(" 1. Create shape");
            Console.WriteLine(" 2. Show list of saved shapes");
            Console.WriteLine(" 3. Update shape");
            Console.WriteLine($" {endAlternative}. Delete shape");
            Console.ForegroundColor = ConsoleColor.Gray;
            ReturnFromMenuClass.ExitMenu();
            var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
            return sel;
        }

        public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext, IShape shape)
        {
            CreateShape create = new CreateShape(dbContext);
            
                switch (selectedFromMenu)
                {
                    case 1:
                    {
                        create.Create(shape);
                        Console.ReadKey(); //flyttta denna
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Read Shape");
                        Console.ReadKey();
                        //gör en klass där man kan visa shape.
                            //beroende på vilken shape - olika listor
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Update shape");
                        Console.ReadKey();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Delete shape");
                        Console.ReadKey();
                        break;
                    }
                }
        }
    }
}
