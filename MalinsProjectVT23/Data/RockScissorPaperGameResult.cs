using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalinsProjectVT23.Data;

public class RockScissorPaperGameResult
{
    [Key][Column(Order = 0)] public int GameId { get; set; }
    [Required][Column(Order = 1)] public string Winner { get; set; }
    [Required][Column(Order = 2)] public int NumberOfUserWins { get; set; }
    [Required][Column(Order = 3)] public int NumberOfComputerWins { get; set; }
    [Required][Column(Order = 4)] public decimal AverageUserWins { get; set; }
    [Required][Column(Order = 5)] public DateTime Date { get; set; }
}