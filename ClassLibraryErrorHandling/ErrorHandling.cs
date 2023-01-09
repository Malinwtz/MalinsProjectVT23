using System.Globalization;

namespace ClassLibraryErrorHandling;

public class ErrorHandling
{
    public static void WrongInputMessage()
    {
        Console.WriteLine(" Felaktig input");
    }

    public static DateTime TryDate()
    {
        while (true)
            try
            {
                var date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.CurrentCulture);
                if (date > DateTime.Now) return date;
                Console.Write(" Felaktigt datum. Försök igen: ");
            }
            catch
            {
                WrongInputMessage();
            }
    }

    public static int TryInt()
    {
        while (true)
            try
            {
                int.TryParse(Console.ReadLine(), out var saldo);
                if (saldo > 0)
                    return saldo;
            }
            catch
            {
                WrongInputMessage();
            }
    }
}