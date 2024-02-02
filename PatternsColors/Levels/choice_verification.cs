using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsColors.Levels
{
    public class choice_verification
    {
        public static int choice(IEnumerable enumerable)
        {
            int maxAttempts = 3000;

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int CHOICE) && CHOICE >= 1 && CHOICE <= enumerable.Cast<object>().Count())
                {
                    return CHOICE - 1;
                }

                Console.WriteLine($"Invalid input. Please enter a valid integer between 1 and {enumerable.Cast<object>().Count()}");
            }

            Console.WriteLine("You've exceeded the maximum number of attempts. Exiting...");
            Environment.Exit(0);
            return -1; 
        }
    }
}

