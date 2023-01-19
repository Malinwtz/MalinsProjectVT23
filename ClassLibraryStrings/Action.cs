using System.Drawing;
using Console = System.Console;

namespace ClassLibraryStrings;

public class Action
{
    public static void PressEnterToContinue()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n\n Press enter to continue...");
        Console.ReadKey();
    }

    public static void Successful(string text)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" {text}");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void NotSuccessful(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void Red(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void Blue(string text)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void DarkCyan(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void Cyan(string text)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void White(string text)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void DarkYellow(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void Yellow(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void DarkMagenta(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void Magenta(string text)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void BlueGradient(string text)
    {
        var chars = text.ToCharArray();
            Colorful.Console.WriteWithGradient(chars, Color.RoyalBlue,
                Color.AntiqueWhite, 5);
            Console.ResetColor();
    }
    public static void YellowGradient(string text)
    {
        var chars = text.ToCharArray();
            Colorful.Console.WriteWithGradient(chars, Color.AntiqueWhite,
                Color.OrangeRed, 5);

        Colorful.Console.ReplaceAllColorsWithDefaults();
    }
    public static void PurpleGradient(string text)
    {
        var chars = text.ToCharArray();
            Colorful.Console.WriteWithGradient(chars, Color.BlueViolet,
                Color.AntiqueWhite, 5);
    }
}