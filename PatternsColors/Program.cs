using System;
using System.Net;
using PatternsColors.Levels;
using System.IO;

namespace PatternsColors
{
    public class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Guessing Game!");
            Console.WriteLine("This game challenges the user to select criteria and match them with hidden criteria randomly chosen by the machine. The criteria include shape, color, and pattern.");
            Console.WriteLine("Each correct match increments the score by one. If the player fails, their score is displayed to guide their next step.");
            Console.WriteLine("To advance to the next level, the player must successfully complete the current level.");
            Console.WriteLine("The game is designed to be fully extensible and dynamically built. You can easily add more shapes, colors, or patterns as you wish. Additionally, you can extend the number of criteria and create new levels without modifying the existing code.");
            Console.WriteLine("The game adheres to SOLID principles, ensuring a robust and scalable design.");
            Console.WriteLine("");

            Console.Write("Start the game?[y/n]?");
            Console.Write("");

            if (Console.ReadLine() == "y")
            {
                GAME gAME = new GAME();
                gAME.game(); 
            }

        }
    }
}
