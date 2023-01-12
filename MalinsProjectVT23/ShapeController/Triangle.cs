using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.ShapeController;

public class Triangle : IShape
{
    public decimal CalculateArea(decimal length, decimal height)
    {
        var tArea = (length * height)/2;
        return tArea;
    }

    public decimal CalculateCircumference(decimal length, decimal height)
    {
        var tCircumference = length * 3; /// bara rätvinklig
        return tCircumference;
    }
}