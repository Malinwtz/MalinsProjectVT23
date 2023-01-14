using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalinsProjectVT23.Data;

public class ShapeResult
{
    [Key] public int ShapeResultId { get; set; }
    [Required][Column("HeightInCentimeter", TypeName = "decimal(38, 38)")] public decimal Height { get; set; }
    [Required][Column("LengthInCentimeter", TypeName = "decimal(38, 38)")] public decimal Length { get; set; }
    [Required][Column("CircumferenceInCentimeter", TypeName = "decimal(38, 38)")] public decimal Circumference { get; set; }
    [Required][Column("AreaInSquareCentimeter", TypeName = "decimal(38, 38)")] public decimal Area { get; set; }
    [Required] public DateTime ResultDate { get; set; }
    [Required] public Shape Shape { get; set; }
}