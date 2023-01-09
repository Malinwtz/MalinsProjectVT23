using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.Data
{
    public class ShapeResult
    {
        [Key] public int ShapeResultId { get; set; }
        [Required] public decimal Heigth { get; set; }
        [Required] public decimal Length { get; set; }
        [Required] public decimal Circumference { get; set; }
        [Required] public decimal Area { get; set; }
        [Required] public Shape Shape { get; set; }
    }
}
