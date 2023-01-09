namespace ClassLibraryCalculations
{
    public class Calculate
    {
        public class MathServices
        {
            public decimal Addition(decimal num1, decimal num2) 
            {
                return num1 + num2;
            }
            public decimal Subtraction(decimal num1, decimal num2) 
            {
                return num1 - num2;
            }
            public decimal Multiplication(decimal num1, decimal num2) 
            {
                return num1 * num2;
            }
            public decimal Division(decimal num1, decimal num2) 
            {
                while (true)
                {
                    if (num2 != 0) return num1 / num2;
                    Console.WriteLine("The number to divide with can not be zero. Try again");
                    Console.Write("Number to be divided: ");
                    num1 = Convert.ToInt32(Console.ReadLine()); //errorhandling
                    Console.Write("Number to divide with: ");
                    num2 = Convert.ToInt32(Console.ReadLine()); //errorhandling
                }
            }
            //design pattern strategy pattern: byta ut en viss operation(metoderna ovan) mot en klass istället. 
        }
    }
}