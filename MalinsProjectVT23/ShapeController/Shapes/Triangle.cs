using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.ShapeController.Shapes;

public class Triangle : IShape
{
    public string Name { get; set; } = ShapeEnum.TypeOfShape.Triangle.ToString();

    public decimal CalculateArea(decimal length, decimal height)
    {
        var tArea = length * height / 2;
        return tArea;
    }

    public decimal CalculateCircumference(decimal length, decimal height)
    {
        var tCircumference = length * 3;
        return tCircumference;
    }
}