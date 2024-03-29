﻿using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.ShapeController.Shapes;

public class Rectangle : IShape
{
    public string Name { get; set; } = ShapeEnum.TypeOfShape.Rectangle.ToString();

    public decimal CalculateArea(decimal length, decimal height)
    {
        var rectangleArea = length * height;
        return Math.Round(rectangleArea, 6, MidpointRounding.AwayFromZero);
    }

    public decimal CalculateCircumference(decimal length, decimal height)
    {
        var circumferenceOfRectangle = (length + height) * 2;
        return Math.Round(circumferenceOfRectangle,6, MidpointRounding.AwayFromZero);
    }

    public decimal CalculateHeight(decimal length)
    {
        throw new NotImplementedException();
    }
}