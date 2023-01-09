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
            catch
            {
                Console.WriteLine("Fel");
            } //ErrorHandling.WrongInputMessage(); }

            if (sel >= 0 && sel <= max) return sel;
            Console.WriteLine("Fel");
            //ErrorHandling.WrongInputMessage();
        }
    }
    public static void ExitMenu()
    {
        Console.WriteLine("\n 0 = Avbryt");
    }
}