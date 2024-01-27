using PatternsColors.Colors;
using PatternsColors.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsColors.Levels
{
    public interface IBase
    {
        public IColors Colorr { get; set; }
        public IShape Shapee { get; set; }
        public Color color { get; set; }

        public Shape shape { get; set; }
    }
}
