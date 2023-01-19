using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalinsProjectVT23.Data;

public class Calculation
{
    [Key] public int CalculationId { get; set; }
    [Required][Column(Order = 2)] public decimal Input1 { get; set; }
    [Required][Column(Order = 4)] public decimal Input2 { get; set; }
    [Required][Column(Order = 5)] public decimal Result { get; set; }
    [Required][Column(Order = 3)] public string CalculationStrategy { get; set; }
    [Required][Column(Order = 6)] public DateTime CalculationDate { get; set; }
}