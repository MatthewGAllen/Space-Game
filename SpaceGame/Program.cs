using System;

namespace SpaceGame
{
    class Program
    {
        static string[,] fieldDisplay = new string[24, 18];//[rows,columns]
        static ConsoleKeyInfo userKey;
        static string userMove;
        static bool truther = true;
        static void Main(string[] args)
        {
           

            DisplaySetUp();
            DisplayOutput();
            UserControl();
            
            
            //SpaceShip Ship = new SpaceShip();
            //Ship.Spaceship();

            



        }

        


        public static void DisplaySetUp()
        {
            for (int i = 1; i < 17; i++)
            {
                fieldDisplay[0, i ] = "^";
                

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
        }

        public static void DisplayOutput()
        {
            int rowLeng = fieldDisplay.GetLength(1);
            int colLeng = fieldDisplay.GetLength(0);
            for (int j = 0; j < colLeng; j++)
            {
                for ( int i = 0; i < rowLeng; i++)
                {
                    Console.Write(string.Format("{0} ", fieldDisplay[j, i]));
                }
                Console.WriteLine();
            }
        }

        public static void UserControl()
        {
            

            while(truther)
            {
                userKey = Console.ReadKey();

                Console.WriteLine(userKey.Key.ToString());
                userMove = userKey.Key.ToString();

                if (userMove == "RightArrow")
                {
                    Console.WriteLine("User moved right");
                }
                else if (userMove == "LeftArrow")
                {
                    Console.WriteLine("User moved left");
                }
                else if (userMove == "Escape")
                {
                    Console.WriteLine("User Quit");
                    truther = false;
                }
                else if (userMove == "SpaceBar")
                {
                    Console.WriteLine("User hit the SpaceBar");

                }
                else
                {
                    Console.WriteLine("Unrecognized button press");
                }
            }
            
        }

      
    }
}
