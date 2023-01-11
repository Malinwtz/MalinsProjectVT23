using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.RockScissorPaperGameController
{
    public class Player
    {
        private int userPoints { get; set; }
        private int computerPoints { get; set; }

        public Player()
        {
            userPoints = 0;
            computerPoints = 0;
        }

        public int UserPoints
        {
            get { return userPoints; }
            set { userPoints = value; }
        }

        public int ComputerPoints
        {
            get { return computerPoints; }
            set { computerPoints = value; }
        }
    }
}
