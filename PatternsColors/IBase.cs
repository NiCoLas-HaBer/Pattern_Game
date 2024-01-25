using PatternsColors.Colors;
using PatternsColors.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsColors
{
    public interface IBase
    {
        public IColors Color { get; set; }
        public IShape Shape { get; set; }
        public Color color { get; set; }

        public Shape shape { get; set; }
    }
}
