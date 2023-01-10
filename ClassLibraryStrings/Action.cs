namespace ClassLibraryStrings;

public class Action
{
    public static void PressEnterToContinue()
    {
        Console.Write("\n Tryck på enter för att fortsätta...");
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
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}