using PatternsColors.Colors;
using PatternsColors.Patterns;
using PatternsColors.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsColors
{
    public interface IBaseToIntermediate : IBase
    {
        public IPattern Patternn { get; set; }
        public Pattern pattern { get; set; }
    }
}
