using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalinsProjectVT23.Data;

public class ShapeResult
{
    [Key] public int ShapeResultId { get; set; }
    [Required][Column("HeightInCentimeter")] public decimal Height { get; set; }
    [Required][Column("LengthInCentimeter")] public decimal Length { get; set; }
    [Required][Column("CircumferenceInCentimeter")] public decimal Circumference { get; set; }
    [Required][Column("AreaInSquareCentimeter")] public decimal Area { get; set; }
    [Required] public DateTime ResultDate { get; set; }
    [Required] public Shape Shape { get; set; }
}