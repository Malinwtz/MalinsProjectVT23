using ClassLibraryErrorHandling;

namespace ClassLibraryCalculations
{
    public class MathServices
    {
            
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
                    if (num2 != 0) 
                        return num1 / num2;

                    Console.WriteLine(" The number to divide with can not be zero. Try again");
                    Console.Write(" Number to be divided: ");
                    num1 = ErrorHandling.TryInt(); 
                    Console.Write(" Number to divide with: ");
                    num2 = ErrorHandling.TryInt(); 
                }
            }
            public int Modulus(int num1, int num2)
            {
                while (true)
                {
                    if (num2 != 0)
                    {
                        return (Math.Abs(num1 + num2) + num1) % num2; ///trycatch?
                    }

                    Console.WriteLine(" The number to divide with can not be zero. Try again");
                    Console.Write(" Number to be divided: ");
                    num1 = ErrorHandling.TryInt();
                    Console.Write(" Number to divide with: ");
                    num2 = ErrorHandling.TryInt();
                }
            }
            public double SquareRoot(double numberToCalculateSquareRoot)
            {
                var num = Math.Sqrt(numberToCalculateSquareRoot);
                return numberToCalculateSquareRoot;
            }
            //design pattern strategy pattern: byta ut en viss operation(metoderna ovan) mot en klass istället. 
        
    }
}