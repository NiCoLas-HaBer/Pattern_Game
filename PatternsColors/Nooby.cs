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

namespace PatternsColors
{
    public class Nooby : IBase
    {
        public IColors Colorr { get; set; }
        public IShape Shapee { get; set; }
        public int score {  get; set; }

        public Color color { get; set; } = new Color(new List<IColors> { new Red(), new White() });

        public Shape shape { get; set; } = new Shape(new List<IShape> { new Square(), new Circle() });

        public Nooby()
        {
            //Random rnd = new Random();
            //Color = color[rnd.Next(0,color.Counting())];
            //Shape = shape[rnd.Next(0,shape.Counting())];
            score = this.GetType().GetProperties().Where(propa => !(propa.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)))).Count()-1;

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
                if (shape[shapeChoice_] == Shapee)
                {
                    ScOrE++;
                }
                if (color[colorChoice_] == Colorr)
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
            Random rnd =new Random();

            Type classType = this.GetType();


            var directlyImplementedInterfaces = classType.GetInterfaces()  //Gets the interface that is directly implemented by the class "this"
                .Except(classType.GetInterfaces().SelectMany(interfaceType => interfaceType.GetInterfaces())).FirstOrDefault();

            if (directlyImplementedInterfaces !=null)
            {
                //Type interfaceType = (Type)directlyImplementedInterfaces; 
            }


            //Type interfaceType = (Type)directlyImplementedInterfaces;

            IEnumerable<PropertyInfo> InterfaceProperties = classType.GetProperties()//directlyImplementedInterfaces.GetProperties() //Series of properties implemented by the interface that are not IEnumerable
                .Where(prop => !typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(int));

            IEnumerable<PropertyInfo> SeriesOfPropertiese = classType.GetProperties() //Series of properties implemented by the interface that are not IEnumerable
                .Where(prop => typeof(IEnumerable).IsAssignableFrom(prop.PropertyType));

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
                    //Console.WriteLine(series.Name);
                    //Console.WriteLine(prop.PropertyType.Name + "55555555555555555555555555555");

                    foreach (PropertyInfo series in SeriesOfPropertiese)
                    {

                        //Console.WriteLine(series.PropertyType.Name);
                        var seriesValue = series.GetValue(this);
                        if (seriesValue != null && seriesValue is IEnumerable enumerable)
                        {
                            if (enumerable.Cast<object>().Any())
                            {
                                var randomIndex = rnd.Next(0, enumerable.Cast<object>().Count());
                                var randomElement = enumerable.Cast<object>().ElementAt(randomIndex);
                                //Console.WriteLine(randomIndex + "''''''''''''''''''''''''''''''''''''''''''''''''''''''''");
                                //Console.WriteLine(randomElement.ToString() + "lllllllllllllllllllllll");
                                ////Console.WriteLine(randomElement.GetType().GetInterfaces()+ "hhhhhhhhhhhhhhhh" + prop.PropertyType);
                                //Console.WriteLine(randomElement.GetType().GetInterfaces()[0] + "###" + prop.PropertyType);
                                //Console.WriteLine(enumerable.GetType().Name + "###" + prop.PropertyType);
                                //Console.WriteLine(randomElement.GetType().GetInterfaces()[0] == prop.PropertyType);

                                if (randomElement.GetType().GetInterfaces()[0] == prop.PropertyType)//randomElement.GetType().Equals(prop.PropertyType))//randomElement is IColors && randomElement.GetType() == prop.PropertyType)
                                {
                                    //Console.WriteLine($"{randomElement.GetType().GetInterfaces()[0]}");

                                    if (prop.GetValue(this) == null)
                                    {
                                        prop.SetValue(this, randomElement, null); 
                                    }

                                    Console.WriteLine($"Choose the {enumerable.GetType().Name}");
                                    int CHOICE = Convert.ToInt32(Console.ReadLine());
                                    if (prop.GetValue(this) == enumerable.Cast<object>().ElementAt(CHOICE-1))
                                    {
                                        SCORING++;
                                        Console.WriteLine("Voila");
                                        //var propValue = prop.GetValue(this);
                                       // var enumerableElement = enumerable.Cast<object>().ElementAt(CHOICE);

                                        //Console.WriteLine($"{propValue?.GetType().Name} &&&&&&&&&&&&&&&&&&FFFFFFFFFFFFFFFFFF&&&&&&&&&&&& {enumerableElement?.GetType().Name}");

                                        //Console.WriteLine(prop.GetValue(this).GetType().Name+"&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&"+ enumerable.Cast<object>().ElementAt(0).GetType().Name);
                                    }
                                }
                            }

                        }

                    }
                } 
                if(SCORING == this.score)
                {
                    Console.WriteLine("Congrats, you passed the level");
                }
                if (SCORING != this.score)
                {
                    Console.WriteLine("You've failed. Repeat");
                }
            } while (SCORING != this.score);
            //foreach (var series in SeriesOfPropertiese)
            //{
            //    Console.WriteLine(series.Name);
            //}

        }
    }
}

