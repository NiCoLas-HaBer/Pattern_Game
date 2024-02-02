using PatternsColors.Colors;
using PatternsColors.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PatternsColors.Levels
{
    public class Nooby : IBase, ILevels
    {
        public IColors Colorr { get; set; }
        public IShape Shapee { get; set; }
        public int score { get; set; }

        public Color color { get; set; } = new Color(new List<IColors> { new Red(), new White() });

        public Shape shape { get; set; } = new Shape(new List<IShape> { new Square(), new Circle() });

        public Nooby()
        {
            score = GetType().GetProperties().Where(propa => !propa.PropertyType.GetInterfaces().Contains(typeof(IEnumerable))).Count() - 1;
        }

        public bool GameLogic()
        {
            Random rnd = new Random();

            Type classType = GetType();

            //Gets the interface that is directly implemented by the class instance, IBase in this case
            var directlyImplementedInterfaces = classType.GetInterfaces()
                .Except(classType.GetInterfaces().SelectMany(interfaceType => interfaceType.GetInterfaces())).FirstOrDefault();

            //Gets the properties that the types aren't implementing IEnumerable nor int type
            IEnumerable<PropertyInfo> InterfaceProperties = classType.GetProperties()
                .Where(prop => !typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(int));

            //Gets the properties that their types implements an IEnumerable
            IEnumerable<PropertyInfo> SeriesOfPropertiese = classType.GetProperties()
                .Where(prop => typeof(IEnumerable).IsAssignableFrom(prop.PropertyType));

            Console.WriteLine($"\x1B[4m{classType.Name} level:\x1B[0m");
            Console.WriteLine("");

            //List all the game criteria and choices
            foreach (PropertyInfo series in SeriesOfPropertiese) 
            {
                object seriesValue = series.GetValue(this);
                if (seriesValue != null && seriesValue is IEnumerable enumerable)
                {
                    

                    Console.WriteLine($"{series.Name}:");
                    Console.WriteLine("");
                    int indexer = 0;
                    foreach (var item in enumerable)
                    {
                        indexer++;
                        Console.WriteLine($"{indexer}-{item.GetType().Name}");
                    }
                    Console.WriteLine("");
                }
            }
            int SCORING;
            do
            {
                SCORING = 0;
                foreach (PropertyInfo prop in InterfaceProperties)
                {
                    foreach (PropertyInfo series in SeriesOfPropertiese)
                    {
                        var seriesValue = series.GetValue(this);
                        if (seriesValue != null && seriesValue is IEnumerable enumerable)
                        {
                            if (enumerable.Cast<object>().Any())
                            {
                                var randomIndex = rnd.Next(0, enumerable.Cast<object>().Count());
                                var randomElement = enumerable.Cast<object>().ElementAt(randomIndex);

                                //All the Game logic is inside this if statement. When the property is a container class, and the content implements the same interface as one of the other properties: The outcome is true  
                                if (randomElement.GetType().GetInterfaces()[0] == prop.PropertyType)
                                {
                                    //this if statement is ti get sure that we assign a value to the variable only once each level
                                    if (prop.GetValue(this) == null)
                                    {
                                        prop.SetValue(this, randomElement, null);
                                    }

                                    Console.WriteLine("");
                                    Console.WriteLine($"Choose the {enumerable.GetType().Name}");
                                    if (prop.GetValue(this) == enumerable.Cast<object>().ElementAt(choice_verification.choice(enumerable)))
                                    {
                                        SCORING++;
                                    }
                                }
                            }
                        }
                    }
                }
                if (SCORING == score)
                {
                    Console.WriteLine("_____________________Congrats, you passed the level_______________________\n");
                    return true;
                }
                if (SCORING != score)
                {
                    Console.WriteLine("");
                    Console.WriteLine("┌─────────────────┐");
                    Console.WriteLine($"      Score:{SCORING}");
                    Console.WriteLine("└─────────────────┘");

                    Console.WriteLine("________________________You've failed. Repeat_________________________\n");
                }
            } while (SCORING != score);
            return false;

        }
    }
}

