using System.ComponentModel.DataAnnotations;

namespace MalinsProjectVT23.Data;

public class RockScissorPaperGameResult
{
    [Key] public int GameId { get; set; }
}