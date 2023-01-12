using System.ComponentModel.DataAnnotations;

namespace MalinsProjectVT23.Data;

public class RockScissorPaperGameResult
{
    [Key] public int GameId { get; set; }
    [Required] public bool Winner { get; set; }
    [Required] public bool Looser { get; set; }
    [Required] public int NumberOfWins { get; set; }
    [Required] public int NumberOfLosses { get; set; }
    [Required] public bool Tie { get; set; }
}