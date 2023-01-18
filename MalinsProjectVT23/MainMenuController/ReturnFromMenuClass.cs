using ClassLibraryErrorHandling;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.MainMenuController;

public class ReturnFromMenuClass
{
    public static int ReturnFromMenu(int max)
    {
        var sel = -1;
        while (true)
        {
            try
            {
                sel = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (sel >= 0 && sel <= max) return sel;
            ErrorHandling.WrongInputMessage();
        }
    }
    public static void ExitMenu()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n 0 = Exit\n");
        Action.White(" Write input: ");
    }
}