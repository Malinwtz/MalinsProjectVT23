using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23
{
    internal class Application
    {
        public void Run()
        {
           

            MainMenu mainMenu = new MainMenu();
            var inputFromMainMenu = mainMenu.ReturnSelectionFromMenu();
            mainMenu.LoopMenu(inputFromMainMenu);
        }
    }
}
