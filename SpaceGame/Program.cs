using System;

namespace SpaceGame
{
    class Program
    {
        static string[,] fieldDisplay = new string[18, 24];
        static void Main(string[] args)
        {


            Display();

        }

        public static void Display()
        {
            for (int i = 0; i < 24; i++)
            {
                fieldDisplay[0, i] = "|";
                fieldDisplay[18, i] = "|";
            }
        }
    }
}
