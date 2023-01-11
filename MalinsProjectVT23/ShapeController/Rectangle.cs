﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.ShapeController
{
    public class Rectangle : IShape
    {

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
    }
}
