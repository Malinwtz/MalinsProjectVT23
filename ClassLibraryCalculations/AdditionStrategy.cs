using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculations
{
    public class AdditionStrategy : IStrategy
    {
        public decimal Addition(decimal num1, decimal num2)
        {
            return num1 + num2;
        }
    }
}
