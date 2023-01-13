using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.ShapeController.Shapes;

public class Parallelogram : IShape
{
    public string Name { get; set; } = "Parallellogram";

    public decimal CalculateArea(decimal length, decimal height)
    {
        var areaOfParallelogram = length * height;
        return areaOfParallelogram;
    }

    public decimal CalculateCircumference(decimal length, decimal height)
    {
        var circumferenceOfParallelogram = (length + height) * 2;
        return circumferenceOfParallelogram;
    }
}