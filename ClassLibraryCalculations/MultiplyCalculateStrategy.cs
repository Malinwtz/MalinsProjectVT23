using ClassLibraryCalculations.Interface;

namespace ClassLibraryCalculations;

public class MultiplyCalculateStrategy : ICalculateStrategy
{
    public string CalculationMethod { get; set; } = "*";

    public decimal Calculate(decimal num1, decimal num2)
    {
        return Math.Round(num1 * num2, 2, MidpointRounding.AwayFromZero);
    }
}