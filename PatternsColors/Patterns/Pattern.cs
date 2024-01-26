using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternsColors.Shapes;
using PatternsColors.Colors;
using System.Collections;
using PatternsColors.Patterns;

namespace PatternsColors
{
    public class Pattern : IEnumerable
    {
        private List<IPattern> ThePatterns;

        public Type GetElementType
        {
            get
            {
                if (ThePatterns.Count > 0)
                {
                    // Assuming that all elements implement IColors
                    Type elementType = ThePatterns[0].GetType();
                    return elementType;
                }
                return null;

            }
        }

        public Pattern(IEnumerable<IPattern> item)
        {
            ThePatterns = new List<IPattern>(item);
        }

        public IPattern this[int index]
        {
            get
            {
                if (index < 0 || index >= ThePatterns.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                return ThePatterns[index];
            }

            set
            {
                if (index < 0 || index >= ThePatterns.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                ThePatterns[index] = value;
            }
        }
        public int Counting()
        {
            return ThePatterns.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator<IPattern>(ThePatterns);
        }

    }
}
// Example usage
//var color = new Color(new List<IColors> { new Red(), new White(), new Yellow(), new CustomColor() });


