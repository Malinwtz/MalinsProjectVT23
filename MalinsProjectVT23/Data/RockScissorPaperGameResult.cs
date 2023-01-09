using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.Data
{
    public class RockScissorPaperGameResult
    {
        [Key] public int GameId { get; set; }
    }
}
