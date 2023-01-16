using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.ShapeController.Shapes;

public class Rhombus : IShape
{
    public string Name { get; set; } = ShapeEnum.TypeOfShape.Rhombus.ToString();

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

    public decimal CalculateHeight(decimal length)
    {
        throw new NotImplementedException();
    }
}