using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalinsProjectVT23.Data;

public class ShapeResult
{
    [Key] public int ShapeResultId { get; set; } //input properties om det inte funkar
    [Required][Column] public decimal Height { get; set; }
    [Required][Column] public decimal Length { get; set; }
    [Required][Column] public decimal Circumference { get; set; }
    [Required][Column] public decimal Area { get; set; }
    [Required] public Shape Shape { get; set; }
}