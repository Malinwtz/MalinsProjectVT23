using System.ComponentModel.DataAnnotations;

namespace MalinsProjectVT23.Data;

public class Shape
{
    [Key] public int ShapeId { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; }
}