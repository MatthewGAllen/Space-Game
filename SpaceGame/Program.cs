using System;


namespace SpaceGame
{
    class Program
    {
        
        
        static bool truther = true;
        //^^^^^^^^^^^^^^^^^^^^^^^^Game Loop variable

        static int xPos = 35;
        static int yPos = 39;
        //^^^^^^User position on screen 

        static Random rand = new Random();
        //^^^^^Used to create random x position for the enemies

        static int xPosEn;
        static int yPosEn = 2;

        static int bullXpos;
        static int bullYpos;
        static void Main(string[] args)
        {
            //Sets the default console window height and width
            Console.WindowHeight = 42;
            Console.WindowWidth = 75;

            //game loop for all methods needed in this program
            do
            {

                xPosEn = rand.Next(69);  //gets random number for position of the enemy
                DisplaySetUp(); // sets up the screen for the player
                EnemyMaker();
                UserControl(); // gets the users input and prints the users character and the enemy
                Shooter();

            } while (truther);



        }

        public static void DisplaySetUp()
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("^");

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

        }

        public static void EnemyMaker()
        {

            Console.SetCursorPosition(xPosEn, yPosEn);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("V");


        }

        public static void UserControl()
        {
            do
            {
                Boundries(); // sets the boundries for the user and checks if the enemy made it to the bottom

                ConsoleKey command = Console.ReadKey().Key;
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPos, yPos);
                        Console.Write(" ");
                        xPos--;
                        Console.SetCursorPosition(xPosEn, yPosEn);
                        Console.Write(" ");
                        yPosEn++;
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPos, yPos);
                        Console.Write(" ");
                        xPos++;
                        Console.SetCursorPosition(xPosEn, yPosEn);
                        Console.Write(" ");
                        yPosEn++;
                        break;
                    case ConsoleKey.Spacebar:
                        
                        break;
                    case ConsoleKey.Escape:
                        truther = false;
                        break;
                }

                EnemyMaker();

                

                Console.SetCursorPosition(xPos, yPos);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("^");

                Console.SetCursorPosition(bullXpos, bullYpos);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("^");

            } while (truther);

        }

        public static void Boundries()
        {
            if (yPosEn == 39)
            {
                yPosEn--;
            }

            if (xPos == 2)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write(" ");
                xPos++;
            }
            else if (xPos == 69)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write(" ");
                xPos--;
            }

            Console.SetCursorPosition(xPos, yPos);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("^");
        }

        public static void Shooter()
        {
            
            Console.SetCursorPosition(bullXpos, bullYpos);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("^" + "\n" + "|");
            
            
        }

    }
}
