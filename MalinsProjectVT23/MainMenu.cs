using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23
{
    public class MainMenu
    {
        public int ReturnSelectionFromMenu()
            {
                Console.Clear();
                var endAlternative = 3;
                Console.WriteLine(" START MENU");
                Console.WriteLine("*********");//Lines.LineThreeStar();
                Console.WriteLine(" 1. Shapes");
                Console.WriteLine(" 2. Calculator");
                Console.WriteLine($" {endAlternative}. Rock, Scissors, Paper");
                ReturnFromMenuClass.ExitMenu();
                var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
                return sel;
            }

            public void LoopMenu(int selectedFromMenu) //ApplicationDbContext dbContext)
            {
                var loop = true;
                while (loop)
                    switch (selectedFromMenu)
                    {
                        case 1:
                        {
                            //shapesmenu
                            //var customerMenu = new CustomerMenu();
                            //var selectedFromCustomerMenu = customerMenu.ReturnSelectionFromMenu();
                            //if (selectedFromCustomerMenu == 0) loop = false;
                            //customerMenu.LoopMenu(selectedFromCustomerMenu, dbContext);
                            break;
                        }
                        case 2:
                        {
                            var calculatorMenu = new CalculatorMenu();
                            var inputFromCalculatorMenu = calculatorMenu.ReturnSelectionFromMenu();
                            if (inputFromCalculatorMenu == 0) loop = false;
                            calculatorMenu.LoopMenu(inputFromCalculatorMenu); //, dbContext);
                            break;
                        }
                        case 3:
                            //rock scissors paper
                            //var bookingMenu = new BookingMenu();
                            //var selectedFromBookingMenu = bookingMenu.ReturnSelectionFromMenu();
                            //if (selectedFromBookingMenu == 0) loop = false;
                            //bookingMenu.LoopMenu(selectedFromBookingMenu, dbContext);
                            break;
                    }
            }
    }
}
