using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsColors.Colors
{
    public class Color
    {
        private List<IColors> TheColors;

        public Color(IEnumerable<IColors> colors)
        {
            // Initialize with injected colors
            TheColors = new List<IColors>(colors);
        }

        public IColors this[int index]
        {
            get
            {
                if (index < 0 || index >= TheColors.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                return TheColors[index];
            }

            set
            {
                if (index < 0 || index >= TheColors.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                TheColors[index] = value;
            }
        }
        public int Counting()
        {
            return TheColors.Count;
        }
    }
}
// Example usage
//var color = new Color(new List<IColors> { new Red(), new White(), new Yellow(), new CustomColor() });
