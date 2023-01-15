﻿using System.Globalization;

namespace ClassLibraryErrorHandling;

public class ErrorHandling
{
    public static void WrongInputMessage()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" Wrong input");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static DateTime TryDate()
    {
        while (true)
            try
            {
                var date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.CurrentCulture);
                if (date > DateTime.Now) return date;
                Console.Write(" Incorrect date, try again ");
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
                int.TryParse(Console.ReadLine(), out var integer);
                if (integer > 0)
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
                decimal.TryParse(Console.ReadLine(), out var decimalNumber);
                if (decimalNumber > 0)
                    return decimalNumber;
            }
            catch
            {
                WrongInputMessage();
            }
    }
}