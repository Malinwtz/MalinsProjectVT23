using ClassLibraryCalculations.Interface;

namespace ClassLibraryCalculations;

public class SquareRootCalculateStrategy : ICalculateStrategy
{
    public string CalculationMethod { get; set; } = "Square root of";

    public decimal Calculate(decimal numberToCalculateSquareRoot, decimal numberToNotUse)
    {
        var numberToSquareRoot = Convert.ToDouble(numberToCalculateSquareRoot);
        var calculatedSquareRoot = Math.Sqrt(numberToSquareRoot);

        return Convert.ToInt32(Math.Round(calculatedSquareRoot, 6, MidpointRounding.AwayFromZero));
    }
}