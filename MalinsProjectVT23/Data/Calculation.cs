using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalinsProjectVT23.Data;

public class Calculation
{
    [Key] public int CalculationId { get; set; }
    [Required][Column(TypeName = "decimal(38, 2)")] public decimal Input1 { get; set; }
    [Required][Column(TypeName = "decimal(38, 2)")] public decimal Input2 { get; set; }
    [Required] [Column(TypeName = "decimal(38, 2)")] public decimal Result { get; set; }
    [Required] public string CalculationStrategy { get; set; }
    [Required] public DateTime CalculationDate { get; set; }
}