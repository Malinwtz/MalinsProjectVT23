using Microsoft.Extensions.Configuration;
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
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();


            MainMenu mainMenu = new MainMenu();
            var inputFromMainMenu = mainMenu.ReturnSelectionFromMenu();
            mainMenu.LoopMenu(inputFromMainMenu);
        }
    }
}
