using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaddersAndSnakes
{
    public class Player
    {
        public string name = "";
        public int points = 0;
        public int throwDice()
        {
            int diceSum;
            Random rnd = new Random();
            int num1 = rnd.Next(1,6);
            int num2 = rnd.Next(1,6);
            diceSum = num1 + num2;
            return diceSum;
        }
    }

    
}
