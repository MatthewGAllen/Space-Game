using System;

namespace SpaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Character player = new Character();
            player.Sprite();

            Enemy badGuy = new Enemy();
            badGuy.Sprite();

            //var place = Console.ReadKey().Key;

            bool truther = true;
            while (truther)
            {
                string place = Console.ReadKey().Key.ToString();
                Console.WriteLine($"{place}");
                if (place == "Enter")
                {
                    truther = false;
                }
            }
        }
    }
}
