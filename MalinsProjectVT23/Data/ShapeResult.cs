using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalinsProjectVT23.Data;

public class ShapeResult
{
    [Key] public int ShapeResultId { get; set; } //input properties om det inte funkar
    [Required][Column("HeightInCentimeter", TypeName = "decimal(38, 2)")] public decimal Height { get; set; }
    [Required][Column("LengthInCentimeter", TypeName = "decimal(38, 2)")] public decimal Length { get; set; }
    [Required][Column("CircumferenceInCentimeter", TypeName = "decimal(38, 2)")] public decimal Circumference { get; set; }
    [Required][Column("AreaInSquareCentimeter", TypeName = "decimal(38, 2)")] public decimal Area { get; set; }
    [Required] public DateTime ResultDate { get; set; }
    [Required] public Shape Shape { get; set; }
}