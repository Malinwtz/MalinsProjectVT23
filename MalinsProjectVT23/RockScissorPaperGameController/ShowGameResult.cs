using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryStrings;
using MalinsProjectVT23.Data;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.RockScissorPaperGameController
{
    public class ShowGameResult
    {
        public ShowGameResult(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public ApplicationDbContext DbContext { get; set; }
        public void GameResults()
        {
            if (!DbContext.RockScissorPaperGameResults.Any())
            {
                Action.NotSuccessful(" There are no game results yet");
            }
            else if (DbContext.RockScissorPaperGameResults.Any())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0,-20}{1,-15}{2,-20}{3,-15}{4,-15}{5,-20}",
                    " GameId", "Winner", "ComputerPoints", "UserPoints", "Tie", "Date");
                Console.ForegroundColor = ConsoleColor.Gray;
                Line.LineTwoEqual();
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var result in DbContext.RockScissorPaperGameResults)
                {
                    Console.WriteLine("{0,-20}" +
                                      "{1,-15}" +
                                      "{2,-20}" +
                                      "{3,-15}" +
                                      "{4,-15}" +
                                      "{5,-20}", 
                        $" {result.GameId}",
                        $"{result.Winner}",
                        $"{result.NumberOfComputerWins}", 
                        $"{result.NumberOfUserWins}",
                        $"{result.Tie}", 
                        $"{result.Date}");
                }
            }
        }

    }
}
