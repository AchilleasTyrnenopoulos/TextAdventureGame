using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * "An abduction in the night"
 * by Achilles Tyrnenopoulos, 2020
 *  
 * This work is a derivative of 
 * "C# Adventure Game" by http://programmingisfun.com, used under CC BY.
 * https://creativecommons.org/licenses/by/4.0/
 */

namespace TextAdventureGame
{

    class Program
    {
        public static bool gameOVer = false;
        static void Main()
        {
            
            Game game = new Game();   
            //bool gameRunning = true;
            if (!gameOVer)
            {
                Game.StartGame();
                Console.WriteLine("Press any key to continue\n");
                Console.ReadKey();
                game.Beginning();
                game.ActI();
            }
            Console.ReadKey();
        }
    }
}
