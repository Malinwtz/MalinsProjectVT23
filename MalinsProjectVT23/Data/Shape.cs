using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.Data
{
    public class Shape
    {
        [Key] public int ShapeId { get; set; }
        [Required][MaxLength(100)] public string Name { get; set; }
        [Required] public DateTime Date { get; set; }
    }
}
