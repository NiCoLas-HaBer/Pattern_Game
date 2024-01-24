using PatternsColors.Colors;
using PatternsColors.Shapes;
using System;
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

        public Color color = new Color(new List<IColors> { new Red(), new White() });

        public Shape shape = new Shape(new List<IShape> { new Square(), new Circle() });

        public Nooby()
        {
            Random rnd = new Random();
            Color = color[rnd.Next(0,color.Counting())];
            Shape = shape[rnd.Next(0,shape.Counting())];
            score = this.GetType().GetProperties().Count() -1;
            Console.WriteLine(score);
        }
        public virtual void Game()
        {
            Console.WriteLine("You're in the nooby level");
            //foreach(IShape shape_  in shape)
            //{

            //}
        }
    }
}
