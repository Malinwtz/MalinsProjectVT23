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
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
