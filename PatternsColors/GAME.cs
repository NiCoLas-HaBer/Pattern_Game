using PatternsColors.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatternsColors
{
    public class GAME
    {
        public int Niveau { get; set; } = 0;
        public List<ILevels> Levels { get; } = LoadLevels();

        private static List<ILevels> LoadLevels()
        {
            List<ILevels> levels = new List<ILevels>();

            // Get all types in the assembly that implement IBase
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(ILevels).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            // Create instances and add them to the list
            foreach (var type in types)
            {
                var instance = (ILevels)Activator.CreateInstance(type);
                levels.Add(instance);
            }

            return levels;
        }

        public void gg()
        {
            foreach (var level in Levels)
            {
                Console.WriteLine(level);
            }
        }

        public void game()
        {
            ILevels currentLevel = Levels[Niveau];

            do
            {
                if (currentLevel.kk())
                {
                    Niveau++;
                    if (Niveau < Levels.Count)
                    {
                        currentLevel = Levels[Niveau];
                    }
                    else
                    {
                        // Handle the case where all levels are completed
                        break;
                    }
                }

            } while (!currentLevel.kk());
        }
    }
}
