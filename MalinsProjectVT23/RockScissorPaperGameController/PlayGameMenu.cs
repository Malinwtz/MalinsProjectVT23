using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.MainMenuController;

namespace MalinsProjectVT23.RockScissorPaperGameController
{
    public class PlayGameMenu
    {
        public int ReturnSelectionFromMenu()
        {
            Console.Clear();
            var endAlternative = 3;
            Console.WriteLine(" Select option: ");
            Line.LineThreeStar();
            Console.WriteLine(" 1. Rock");
            Console.WriteLine(" 2. Scissor");
            Console.WriteLine($" {endAlternative}. Paper");
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

