using System;


namespace SpaceGame
{
    class Program
    {

        static bool shootActive = false;
        static bool truther = true;
        //^^^^^^^^^^^^^^^^^^^^^^^^Game Loop variable

        static int xPos = 35;   // User starting x position
        static int yPos = 39;   // User starting y position
        //^^^^^^User position on screen 

        static Random rand = new Random();
        //^^^^^Used to create random x position for the enemies

        static int xPosEn = 1;  // Enemys sarting x position. instantiated by rand in the main method
        static int yPosEn = 2;  // Enemys starting y position

        static int bullXpos;    // bullets x starting position. Instantiated by the users x Pos at the time of spacebar pushed
        static int bullYpos = 38;   // bullets starting y position

        static int enemyKills = 0;
        static int lifeCount = 5;
        static void Main(string[] args)
        {
            //Sets the default console window height and width
           // Console.WindowHeight = 42;
           // Console.WindowWidth = 75;
            
            //game loop for all methods needed in this program
            do
            {

                xPosEn = rand.Next(69);  //gets random number for position of the enemy
                DisplaySetUp(); // sets up the screen for the player
                EnemyMaker(); //prints the enemy to the toop of the screen at a random x position
                UserControl(); // gets the users input and prints the users character and the enemy
                Shooter(); // Coming soon.... hopefully
                
            } while (truther);



        }

        public static void DisplaySetUp()
        {
            // Prints the users character to the screen at the starting x,y coordinates
            Console.SetCursorPosition(xPos, yPos);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("^");
            // Prints the walls of the game field
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("|");
                Console.SetCursorPosition(70, i);
                Console.Write("|");
            }
            // Prints the ceiling and floor of the game field
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
            // Prints the enemy at the starting position
            Console.SetCursorPosition(xPosEn, yPosEn);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("V");
            Lives();

        }

        public static void KillCount()
        {
            if (bullXpos == xPosEn && bullYpos == yPosEn)
            {
                Console.SetCursorPosition(bullXpos, bullYpos);
                Console.Write(" ");
                bullYpos = 38;
                yPosEn = 2;
                xPosEn = rand.Next(69);
                enemyKills++;
                Console.SetCursorPosition(30, 42);
                Console.Write($"Enemies killed: {enemyKills}");
            }
        }

        public static void Lives()
        {
            if (yPosEn == 39)
            {
                Console.SetCursorPosition(xPosEn, yPosEn);
                Console.Write(" ");
                yPosEn = 2;
                xPosEn = rand.Next(69);
                lifeCount--;
                Console.SetCursorPosition(30, 48);
                Console.Write($"Lives left: {lifeCount}");
            }
        }

        public static void UserControl()
        {
            do
            {
                Boundries(); // sets the boundries for the user and checks if the enemy made it to the bottom
                KillCount();
                //Lives();
                ConsoleKey command = Console.ReadKey().Key;//waits for the user to press a key and assigns that value to the command variable
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPos, yPos);//brings cursor back to the users current position
                        Console.Write(" ");//erases the character at its current x,y 
                        xPos--;//increments the users x value by -1
                        Console.SetCursorPosition(xPosEn, yPosEn);//brings the cursor to the enemys current positon
                        Console.Write(" ");//erases enemy at current x,y
                        yPosEn++;//increments the enemys y position by +1
                        break;//breaks back out to the game loop

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPos, yPos);
                        Console.Write(" ");
                        xPos++;
                        Console.SetCursorPosition(xPosEn, yPosEn);
                        Console.Write(" ");
                        yPosEn++;
                        break;

                    case ConsoleKey.Spacebar:
                        Console.SetCursorPosition(bullXpos, bullYpos);//Sets the cursor at bullets starting position
                        Console.Write(" ");//clears the cursor at that point
                        bullXpos = xPos;//Sets the bullets x pos equal to the users xpos at the time of firing
                        shootActive = true;//tracks that the spacebar has been pressed
                        break;

                    case ConsoleKey.Escape:
                        truther = false;//Allows the user to exit the game loop
                        break;
                }

                EnemyMaker();//Prints the enemy to the screen
                //Prints the user character tot he screen
                Console.SetCursorPosition(xPos, yPos);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("^");

                if (shootActive)//only starts if the shootActive has been set to true
                {
                    if (bullYpos > 1)//makes sure the bullet hasn't hit the ceiling
                    {
                        //sets cursor to the bullets position erases whatevers there increments the bullets y ->
                        //pos and prints the bullet tot he screen again
                        Console.SetCursorPosition(bullXpos, bullYpos);
                        Console.Write(" ");
                        bullYpos--;
                        Console.SetCursorPosition(bullXpos, bullYpos);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("^");
                    }
                    else if (bullYpos == 1)//checks if the bllet y pos is equal to the ceiling y pos
                    {
                        //sets cursor to the bullets pos and replaces the hole in the ceiling with an *. sets shoot active to false
                        // and resets the bullets y pos to the bottom of the screen
                        //Console.Write("User hit ceiling");
                        Console.SetCursorPosition(bullXpos, bullYpos);
                        Console.Write("*");
                        shootActive = false;
                        
                        bullYpos = 38;
                    }
                }

            } while (truther);

        }

        public static void Boundries()
        {
            if (yPosEn == 39)//checks if the enemy has made it to the bottom
            {
                yPosEn--;// decrements the enemys y pos so it stays there at the screen.
                        // NEEDS TO ALSO GET RID OF THE ENEMY CHARACTER AND RESET THE X AND Y POS
                        //TO POPULATE A NEW ENEMY
            }

            if (xPos == 1)//checks to see if the user has gone to far left
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("|");
                xPos++;//resets the user back to the right by one so it looks like he never actually went into the wall
            }
            else if (xPos == 70)// checks to see if the user has gone to far right
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("|");
                xPos--;
            }

            //Sets the new enemy up in case the random x pos is outside the bounds of the pipes 
            if (xPosEn <= 1)
            {
                Console.SetCursorPosition(xPosEn, yPosEn);
                Console.Write(" ");
                xPosEn = rand.Next(69);
                Console.SetCursorPosition(xPosEn, yPosEn);
                Console.Write("V");
            }
            else if (xPosEn >= 70)
            {
                Console.SetCursorPosition(xPosEn, yPosEn);
                Console.Write(" ");
                xPosEn = rand.Next(69);
                Console.SetCursorPosition(xPosEn, yPosEn);
                Console.Write("V");
            }
            //prints the user character again since it hit the wall and was erased

            
            Console.SetCursorPosition(xPos, yPos);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("^");
        }

        public static void Shooter()
        {
            //prints the bullet. is called by the switch statement when spacebar is pressed
            Console.SetCursorPosition(bullXpos, bullYpos);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("^");
            
        }

    }
}
