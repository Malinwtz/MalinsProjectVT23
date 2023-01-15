namespace ClassLibraryStrings;

public class Action
{
    public static void PressEnterToContinue()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\n\n Tryck på enter för att fortsätta...");
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

    public static void Winner(string text)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void Input(string text)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}