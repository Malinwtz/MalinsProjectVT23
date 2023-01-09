using MalinsProjectVT23.Data;
using Microsoft.EntityFrameworkCore;
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

            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            MainMenu mainMenu = new MainMenu();
            var inputFromMainMenu = mainMenu.ReturnSelectionFromMenu();
            mainMenu.LoopMenu(inputFromMainMenu);
        }
    }
}
