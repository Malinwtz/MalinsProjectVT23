using System.Globalization;
using Action = ClassLibraryStrings.Action;

namespace ClassLibraryErrorHandling;

public class ErrorHandling
{
    public static void WrongInputMessage()
    {
        Action.NotSuccessful(" Wrong input");
    }

    public static DateTime TryFutureDate()
    {
        while (true)
            try
            {
                var date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.CurrentCulture);
                if (date > DateTime.Now) return date;

                Action.NotSuccessful(" Incorrect date, try again ");
            }
            catch
            {
                WrongInputMessage();
            }
    }

    public static int TryIntAboveZero()
    {
        while (true)
            try
            {
                int.TryParse(Console.ReadLine(), out var integer);
                if (integer > 0)
                    return integer;
                Console.WriteLine(" The number must be higher than 0");
            }
            catch
            {
                WrongInputMessage();
            }
    }
    public static int TryIntIncludeNegative()
    {
        while (true)
            try
            {
                int.TryParse(Console.ReadLine(), out var integer);
                return integer;
            }
            catch
            {
                WrongInputMessage();
            }
    }

    public static decimal TryDecimal()
    {
        while (true)
            try
            {
                var inputString = Console.ReadLine();
                if (inputString.Length > 0)
                    if (inputString.StartsWith("-") || inputString.StartsWith("+") || inputString.StartsWith("1") ||
                        inputString.StartsWith("2") || inputString.StartsWith("3") || inputString.StartsWith("4") || 
                        inputString.StartsWith("5") || inputString.StartsWith("6") || inputString.StartsWith("7") ||
                        inputString.StartsWith("8") || inputString.StartsWith("9") || inputString.StartsWith("0"))
                    {
                        var decimalNumber = Convert.ToDecimal(inputString);
                        return decimalNumber;
                    }
                    else
                    {
                        WrongInputMessage();
                    }
            }
            catch
            {
                WrongInputMessage();
            }
    }

    public static decimal TryPositiveDecimal()
    {
        while (true)
            try
            {
                var inputString = Console.ReadLine();
                if (inputString.Length > 0)
                    if (inputString.StartsWith("+") || inputString.StartsWith("1") ||
                        inputString.StartsWith("2") || inputString.StartsWith("3") || inputString.StartsWith("4") ||
                        inputString.StartsWith("5") || inputString.StartsWith("6") || inputString.StartsWith("7") ||
                        inputString.StartsWith("8") || inputString.StartsWith("9") || inputString.StartsWith("0"))
                    {
                        var decimalNumber = Convert.ToDecimal(inputString);
                        return decimalNumber;
                    }
                    else
                    {
                        WrongInputMessage();
                    }
            }
            catch
            {
                WrongInputMessage();
            }
    }
}