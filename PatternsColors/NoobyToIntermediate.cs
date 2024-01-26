using PatternsColors.Colors;
using PatternsColors.Patterns;
using PatternsColors.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsColors
{
    public class NoobyToIntermediate:Nooby,IBaseToIntermediate
    {
        public IColors Colorr { get; set; }
        public IShape Shapee { get; set; }
        public IPattern Patternn { get; set; }
        public int score { get; set; }

        public Color color { get; set; } = new Color(new List<IColors> { new Red(), new White(),new Brown() });

        public Shape shape { get; set; } = new Shape(new List<IShape> { new Square(), new Circle() , new Rectangle()});
        public Pattern pattern { get; set; } = new Pattern(new List<IPattern> { new Vertical_Lines(), new Horizontal_Lines(), new Mesh() });

    }
}
