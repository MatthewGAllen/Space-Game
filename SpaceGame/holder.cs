using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class holder
    {
        public static void holdit()
        {
            int xPosition = 35;
            int yposition = 39;
            bool truther = true;
            bool isEnemyThrough = false;

            Console.SetCursorPosition(xPosition, yposition);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("^");

            BuildWall();



            do
            {
                ConsoleKey command = Console.ReadKey().Key;
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPosition, yposition);
                        Console.Write(" ");
                        xPosition--;
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition, yposition);
                        Console.Write(" ");
                        xPosition++;
                        break;
                    case ConsoleKey.Spacebar:
                        Console.SetCursorPosition(xPosition, yposition);
                        Console.Write(" ");
                        xPosition--;
                        break;
                    case ConsoleKey.Escape:
                        truther = false;
                        break;
                }

                Console.SetCursorPosition(xPosition, yposition);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("^");

                isEnemyThrough = DidEnemyMakeIt(xPosition, yposition);

                if (isEnemyThrough)
                {
                    truther = false;
                    Console.SetCursorPosition(39, 2);
                    Console.WriteLine("The enemy made it through");
                }

                if (Console.KeyAvailable)
                {
                    command = Console.ReadKey().Key;
                }


            } while (truther);






        }

        public static bool DidEnemyMakeIt(int xPosition, int yPosition)
        {
            if (yPosition == 40)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void BuildWall()
        {
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("|");
                Console.SetCursorPosition(70, i);
                Console.Write("|");
            }

            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write("*");
                Console.SetCursorPosition(i, 40);
                Console.Write("*");

            }










            /*
            for (int i = 1; i < 17; i++)
            {
                fieldDisplay[0, i] = "^";


            }
            for (int i = 1; i < 24; i++)
            {
                for (int j = 1; j < 18; j++)
                {
                    fieldDisplay[i, j] = " ";
                }
            }


            for (int j = 0; j < 24; j++)
            {
                fieldDisplay[j, 0] = "|";

                fieldDisplay[j, 17] = "|";
            }

            fieldDisplay[23, xAxis] = "V";
            */
        }
    }

    /*while(truther)
            {
                //userKey = Console.ReadKey();

                ConsoleKey command = Console.ReadKey().Key;

                switch (command)
                {
                    case ConsoleKey.RightArrow:
                        return xPos++;
                        
                        break;
                    case ConsoleKey.LeftArrow:
                        return xPos--;
                        
                        break;
                    case ConsoleKey.Spacebar:
                        Console.WriteLine("User hit the SpaceBar");
                        return xPos += 0;
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("User Quit");
                        return xPos += 0;
                        truther = false;
                        break;
                    default:
                        Console.WriteLine("Unrecognized key press");
                        return xPos += 0;
                        break;
                }
            }*/

}
