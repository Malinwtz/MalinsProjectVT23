﻿using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.ShapeController.Shapes;

public class Rectangle : IShape
{
    public string Name { get; set; } = ShapeEnum.TypeOfShape.Rectangle.ToString();

    public decimal CalculateArea(decimal length, decimal height)
    {
        var rectangleArea = length * height;
        return rectangleArea;
    }

    public decimal CalculateCircumference(decimal length, decimal height)
    {
        var circumferenceOfRectangle = (length + height) * 2;
        return circumferenceOfRectangle;
    }

    public decimal CalculateHeight(decimal length)
    {
        throw new NotImplementedException();
    }
}