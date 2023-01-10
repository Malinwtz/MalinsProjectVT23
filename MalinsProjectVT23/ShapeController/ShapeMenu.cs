using ClassLibraryCalculations;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.ShapeController
{
    public class ShapeMenu
    {
        public int ReturnSelectionFromMenu()
        {
            Console.Clear();
            var endAlternative = 4;
            Console.WriteLine(" Shape Menu");
            Line.LineThreeStar();
            Console.WriteLine(" 1. Rectangle");
            Console.WriteLine(" 2. Parallelogram");
            Console.WriteLine(" 3. Triangle");
            Console.WriteLine($" {endAlternative}. Rhombus");
            ReturnFromMenuClass.ExitMenu();
            var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
            return sel;
        }

        public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
        {
            var loop = true;
            while (loop)
                switch (selectedFromMenu)
                {
                    case 1:
                        {
                            //visa shape
                            break;
                        }
                    case 2:
                        {
                            //skapa shape
                            break;
                        }
                    case 3:
                        {
                            //ändra shape
                            break;
                        }
                    case 4:
                    {
                        //ta bort shape
                    }
                        break;
                }
        }
    }
}
