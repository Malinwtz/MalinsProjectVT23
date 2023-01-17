using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.ShapeController.Shapes;

public class Parallelogram : IShape
{
    public string Name { get; set; } = ShapeEnum.TypeOfShape.Parallelogram.ToString();

    public decimal CalculateArea(decimal length, decimal height)
    {
        var areaOfParallelogram = length * height;
        return Math.Round(areaOfParallelogram, 3, MidpointRounding.AwayFromZero);
    }

    public decimal CalculateCircumference(decimal length, decimal height)
    {
        var circumferenceOfParallelogram = (length + height) * 2;
        return Math.Round(circumferenceOfParallelogram,6, MidpointRounding.AwayFromZero);
    }

    public decimal CalculateHeight(decimal length)
    {
        throw new NotImplementedException();
    }
}