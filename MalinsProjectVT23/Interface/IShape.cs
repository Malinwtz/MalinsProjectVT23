namespace MalinsProjectVT23.Interface;

public interface IShape
{
    public string Name { get; set; }
    decimal CalculateArea(decimal length, decimal height);
    decimal CalculateCircumference(decimal length, decimal height);
    public decimal CalculateHeight(decimal length);
}