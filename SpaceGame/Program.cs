using System;

namespace SpaceGame
{
    class Program
    {
        static string[,] fieldDisplay = new string[24, 18];//[rows,columns]
        static void Main(string[] args)
        {
           

            DisplaySetUp();
            DisplayOutput();

            SpaceShip Ship = new SpaceShip();
            Ship.Spaceship();

            //Console.WriteLine("The current buffer height is {0} rows.",
            //                   Console.BufferHeight);
            //Console.WriteLine("The current buffer width is {0} columns.",
            //                  Console.BufferWidth);



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

      
    }
}
