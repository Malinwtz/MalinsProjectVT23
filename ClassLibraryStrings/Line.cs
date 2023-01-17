namespace ClassLibraryStrings
{
    public class Line
    {
        public static void LineOneHyphen()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("------------------------------------------------------" +
                              "-----------------------------------------------------------------");
        }

        public static void LineTwoEqual()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("======================================================" +
                              "==================================================================");
        }

        
        public static void LineThreeStar()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * " +
                              "* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *" +
                              Environment.NewLine);
        }
    }
}