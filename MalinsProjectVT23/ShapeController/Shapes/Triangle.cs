using MalinsProjectVT23.Interface;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.ShapeController.Shapes;

public class Triangle : IShape
{
    public string Name { get; set; } = ShapeEnum.TypeOfShape.Triangle.ToString();

    public decimal CalculateCircumference(decimal length, decimal height)
    {
        var tCircumference = length * 3;
        return tCircumference;
    }

    public decimal CalculateArea(decimal length, decimal height)
    {
        try
        {
            height = CalculateHeight(length);
            var tArea = length * height / 2;
            return tArea;
        }
        catch (Exception e)
        {
            Action.NotSuccessful(" It was not possible to calculate area");
            throw;
        }
    }

    public decimal CalculateHeight(decimal length)
    {
        try
        {
            var lengthConvertedToDouble = Convert.ToDouble(length);
            var sideA = lengthConvertedToDouble * lengthConvertedToDouble;
            var sideB = (lengthConvertedToDouble / 2) * (lengthConvertedToDouble / 2);
            sideB = (lengthConvertedToDouble * lengthConvertedToDouble)/ 2;

            var tHeight = Math.Sqrt(sideA - sideB);

            return Convert.ToDecimal(tHeight);
        }
        catch (Exception e)
        {
            Action.NotSuccessful(" It was not possible to calculate height");
            throw;
        }
    }
}