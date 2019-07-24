using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class SpaceShip
    {
         public void Spaceship()
        {
            String[] Ship;
            Ship = new string[]
            {
                "   _ ^ _   ",
                "<<||ooo||>>",
                "  ||ooo||  ",
                "    ---    ",
                "    VvV    "
            };

            foreach (string shipPart in Ship)
            {
                Console.WriteLine($"{shipPart}");
            }
        }
    }
}
