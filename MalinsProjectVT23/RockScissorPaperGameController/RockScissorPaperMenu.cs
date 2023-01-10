using ClassLibraryCalculations;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using MalinsProjectVT23.CalculatorController;
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
            var endAlternative = 2;
            Console.WriteLine(" Rock Scissor Paper Menu");
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
                            var playGameMenu = new PlayGameMenu();
                            var inputFromPlayGameMenu = playGameMenu.ReturnSelectionFromMenu();
                            if (inputFromPlayGameMenu == 0) loop = false;
                            else playGameMenu.LoopMenu(inputFromPlayGameMenu, dbContext);
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
