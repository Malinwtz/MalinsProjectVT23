using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.ShapeController;

public class Rhombus : IShape
{
    public decimal CalculateArea(decimal length, decimal height)
    {
        var rArea = length * height;
        return rArea;
    }

    public decimal CalculateCircumference(decimal length, decimal height)
    {
        var rCircumference = length * 4;
        return rCircumference;
    }
}