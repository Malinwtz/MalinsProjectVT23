using System.ComponentModel.DataAnnotations;

namespace MalinsProjectVT23.Data;

public class RockScissorPaperGameResult
{
    [Key] public int GameId { get; set; }
    [Required] public decimal AverageUserWins { get; set; }
    [Required] public string Winner { get; set; }
    [Required] public int NumberOfComputerWins { get; set; }
    [Required] public int NumberOfUserWins { get; set; }
    [Required] public DateTime Date { get; set; }
}