using ClassLibraryStrings;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.RockScissorPaperGameController
{
    public class DisplayRSPGameMenu : IDisplayMenu
    {
        public int ReturnSelectionFromMenu()
        {
            Console.Clear();
            var endAlternative = 2;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Rock Scissor Paper RunMenu");
            Line.LineThreeStar();
            Console.WriteLine(" 1. Play game");
            Console.WriteLine($" {endAlternative}. Show statistics");
            Console.ForegroundColor = ConsoleColor.Gray;
            ReturnFromMenuClass.ExitMenu();
            var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
            return sel;
        }
    }
}
