using ClassLibraryStrings;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.CalculatorController
{
    public class DisplayCrudCalculatorMenu : IDisplayMenu
    {
        public int ReturnSelectionFromMenu()
        {
            Console.Clear();
            var endAlternative = 4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Calculator Crud Menu - Choose CRUD operation");
            Line.LineThreeStar();
            Console.WriteLine(" 1. Create calculation");
            Console.WriteLine(" 2. Read calculations");
            Console.WriteLine(" 3. Update calculation");
            Console.WriteLine($" {endAlternative}. Delete calculation");
            Console.ForegroundColor = ConsoleColor.Gray;
            ReturnFromMenuClass.ExitMenu();
            var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
            return sel;
        }
    }
}
