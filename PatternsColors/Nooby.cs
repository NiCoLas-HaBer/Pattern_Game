using PatternsColors.Colors;
using PatternsColors.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PatternsColors
{
    internal class Nooby : IBase
    {
        public IColors Color { get; set; }
        public IShape Shape { get; set; }
        public int score {  get; set; }

        public Color color { get; set; } = new Color(new List<IColors> { new Red(), new White() });

        public Shape shape { get; set; } = new Shape(new List<IShape> { new Square(), new Circle() });

        public Nooby()
        {
            Random rnd = new Random();
            Color = color[rnd.Next(0,color.Counting())];
            Shape = shape[rnd.Next(0,shape.Counting())];
            score = this.GetType().GetProperties().Count()-1;
            //Console.WriteLine(score);
        }
        public virtual bool Game()
        {
            Console.WriteLine("You're in the nooby level");
            Console.WriteLine(new string('-', "You're in the nooby level".Length));
            Console.WriteLine();
            Console.WriteLine("Shapes:");
            Console.WriteLine();

            int index = 0;
            foreach (IShape shape_ in shape)
            {
                Console.WriteLine($"{index + 1}-{shape_.name}");
            }

            Console.WriteLine("Colors:");
            Console.WriteLine();

            index = 0;
            foreach (IColors color_ in color)
            {
                Console.WriteLine($"{index + 1}-{color_.name}");
            }

            
            do
            {
                int ScOrE = 0;
                Console.Write("Shape choice:");
                int shapeChoice_ = Convert.ToInt32(Console.ReadLine())-1;
                
                Console.Write("Color choice:");
                int colorChoice_ = Convert.ToInt32(Console.ReadLine())-1;
                Console.WriteLine();
                if (shape[shapeChoice_] == Shape)
                {
                    ScOrE++;
                }
                if (color[colorChoice_] == Color)
                {
                    ScOrE ++;
                }
                Console.WriteLine($"You chose: {shape[shapeChoice_].name}-{color[colorChoice_].name}\n You were right on {ScOrE} of your choices");
                if(ScOrE == score)
                {
                    Console.WriteLine("Congrats");
                    Console.WriteLine("Next level");
                    Thread.Sleep(1000);
                    
                    return true;
                    
                }

            } while (true);
        }

        public void kk()
        {

            Type classType = this.GetType();
            Console.WriteLine($"Directly implemented interfaces by {classType.Name}:");


            var directlyImplementedInterfaces = classType.GetInterfaces()  //Gets the interface that is directly implemented by the class "this"
                .Except(classType.GetInterfaces().SelectMany(interfaceType => interfaceType.GetInterfaces())).FirstOrDefault();

            if (directlyImplementedInterfaces !=null)
            {
                Type interfaceType = (Type)directlyImplementedInterfaces; 
            }


            //Type interfaceType = (Type)directlyImplementedInterfaces;

            var SeriesOfCharaterstics = directlyImplementedInterfaces.GetProperties()
                .Where(prop => typeof(IEnumerable).IsAssignableFrom(prop.PropertyType));


            foreach (var series in SeriesOfCharaterstics)
            {
                Console.WriteLine(series.Name);
            }

        }
    }
}

