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
    public class DisplayCrudShapeMenu : IDisplayMenu
    {
        public int ReturnSelectionFromMenu()
        {
            Console.Clear();
            var endAlternative = 4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Crud Shape RunMenu");
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
    }
}
