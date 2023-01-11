using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.ShapeController
{
    public class Parallelogram : IShape
    {
        public decimal CalculateArea(decimal length, decimal height)
        {
            var areaOfParallelogram = (length * height);
            return areaOfParallelogram;
        }

        public decimal CalculateCircumference(decimal length, decimal height)
        {
            var circumferenceOfParallelogram = (length + height) * 2;
            return circumferenceOfParallelogram;
        }
    }
}
