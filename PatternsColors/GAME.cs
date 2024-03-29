﻿using PatternsColors.Levels;
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
        public List<ILevels> Levels { get; } = LoadLevels(); // Load all the classes that implements ILevels in a List

        private static List<ILevels> LoadLevels()
        {
            List<ILevels> levels = new List<ILevels>();

            // Get all classes in the assembly that implement ILevels
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

        public void game()
        {
            ILevels currentLevel = Levels[Niveau];

            do
            {
                if (currentLevel.GameLogic())
                {
                    Niveau++;
                    if (Niveau < Levels.Count)
                    {
                        // Increase the difficulty level if the player succeeds
                        currentLevel = Levels[Niveau]; 
                    }
                    else
                    {
                        // The case when allt he levels are completed
                        break;
                    }
                }

            } while (!currentLevel.GameLogic());
        }
    }
}
