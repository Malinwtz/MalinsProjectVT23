using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalinsProjectVT23.CalculatorController;
using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.RockScissorPaperGameController;
using MalinsProjectVT23.ShapeController;

namespace MalinsProjectVT23.MainMenuController
{
    public class RunMainMenu
    {
        public IRunMenu RunMenu { get; set; }
        public IDisplayMenu DisplayMenu { get; set; }
        public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
        {
            var loop = true;
            while (loop)
                switch (selectedFromMenu)
                {
                    case 1:
                    {
                        DisplayMenu = new DisplayShapeMenu();
                        RunMenu = new ShapeRunMenu();
                        break;
                    }
                    case 2:
                    {
                        DisplayMenu = new DisplayCalculatorMenu();
                        //RunMenu = new 
                        break;
                    }
                    case 3:
                    {
                        RunMenu = new RockScissorPaperRunMenu();
                        DisplayMenu = new DisplayRSPGameMenu();
                        break;
                    }
                }

            var inputFromChosenMenu = DisplayMenu.ReturnSelectionFromMenu();
            if (inputFromChosenMenu == 0) loop = false;
            else RunMenu.RunMenuOptions(inputFromChosenMenu, dbContext);
        }
    }
}
