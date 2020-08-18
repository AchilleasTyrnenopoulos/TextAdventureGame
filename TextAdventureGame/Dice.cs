using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame
{
    public class Dice
    {
        //public static Random r = new Random();

        //public static int d6 = r.Next(1, 7);

        //public static int d10 = r.Next(1, 11);

        //public static int d20 = r.Next(1, 21);



        //make methods to call the dice/ roll the dice
        public static int RollDice(int _dX)
        {
            
            Random random = new Random();
            int newValue = random.Next(1, _dX + 1);
            Game.Dialog($"\nRolled a {newValue} on a  d{_dX} \n");
            return newValue;
        }

        //method for giving information on the check roll 
    }

}

