using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalinsProjectVT23.Data;

public class Calculation
{
    [Key] public int CalculationId { get; set; }
    [Required] [Column] public decimal Input1 { get; set; }
    [Required] [Column] public decimal Input2 { get; set; }
    [Required] [Column] public decimal Result { get; set; }
}