using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.Data
{
    public class Calculation
    {
        [Key] public int CalculationId { get; set; }
        public decimal Input1 { get; set; }
        public decimal Input2 { get; set; }
        public decimal Result { get; set; }
    }
}
