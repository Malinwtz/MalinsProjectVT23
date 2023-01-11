using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.Interface
{
    public interface IShape
    {
        decimal CalculateArea(decimal length, decimal height);
        decimal CalculateCircumference(decimal length, decimal height);
    }
}
