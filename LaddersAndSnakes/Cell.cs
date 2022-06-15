using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaddersAndSnakes
{
    public class Cell
    {
        public int number;
        public Ladder ladder = new Ladder();
        public Snake snake = new Snake();
        public Player player1 = new Player();
        public Player player2 = new Player();
        public bool isGolden = false;
    }
    
}
