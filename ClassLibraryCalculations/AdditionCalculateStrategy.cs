using ClassLibraryCalculations.Interface;

namespace ClassLibraryCalculations;

public class AdditionCalculateStrategy : ICalculateStrategy
{
    public string CalculationMethod { get; set; } = "+";

    public decimal Calculate(decimal num1, decimal num2)
    {
        return Math.Round(num1+num2, 6, MidpointRounding.AwayFromZero);
    }
}