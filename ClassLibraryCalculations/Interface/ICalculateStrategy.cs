namespace ClassLibraryCalculations.Interface;

public interface ICalculateStrategy
{
    public string CalculationMethod { get; set; }
    decimal Calculate(decimal num1, decimal num2);
}