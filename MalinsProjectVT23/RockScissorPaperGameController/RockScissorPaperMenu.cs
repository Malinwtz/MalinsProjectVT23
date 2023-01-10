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

namespace MalinsProjectVT23.RockScissorPaperGameController
{
    public class RockScissorPaperMenu
    {
        public int ReturnSelectionFromMenu()
        {
            Console.Clear();
            var endAlternative = 6;
            Console.WriteLine(" Game Menu");
            Line.LineThreeStar();
            Console.WriteLine(" 1. Play game");
            Console.WriteLine($" {endAlternative}. Show statistics");
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
                           //gamemenu
                            break;
                        }
                    case 2:
                        {
                            //stats
                            break;
                        }
                }
        }
    }
}
