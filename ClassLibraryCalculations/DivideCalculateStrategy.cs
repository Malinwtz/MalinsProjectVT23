using ClassLibraryCalculations.Interface;
using ClassLibraryErrorHandling;

namespace ClassLibraryCalculations;

public class DivideCalculateStrategy : ICalculateStrategy
{
    public string CalculationMethod { get; set; } = "/";

    public decimal Calculate(decimal num1, decimal num2)
    {
        while (true)
        {
            if (num2 != 0)
                return Math.Round(num1 / num2, 2, MidpointRounding.AwayFromZero);

            Console.WriteLine(" The number to divide with can not be zero. Try again");
            Console.Write(" Number to be divided: ");
            num1 = ErrorHandling.TryIntAboveZero();
            Console.Write(" Number to divide with: ");
            num2 = ErrorHandling.TryIntAboveZero();
        }
    }
}