using ClassLibraryStrings;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.ShapeController
{
    public class DisplayShapeMenu : IDisplayMenu
    {
        public int ReturnSelectionFromMenu()
        {
            Console.Clear();
            var endAlternative = 4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Shape Menu");
            Line.LineThreeStar();
            Console.WriteLine(" 1. Rectangle");
            Console.WriteLine(" 2. Parallelogram");
            Console.WriteLine(" 3. Equilateral triangle");
            Console.WriteLine($" {endAlternative}. Rhombus");
            Console.ForegroundColor = ConsoleColor.Gray;
            ReturnFromMenuClass.ExitMenu();
            var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
            return sel;
        }
    }
}
