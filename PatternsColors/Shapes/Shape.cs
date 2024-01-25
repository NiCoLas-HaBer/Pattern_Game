using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternsColors.Shapes;
using PatternsColors.Colors;
using System.Collections;

namespace PatternsColors
{
    public class Shape: IEnumerable
    {
        private List<IShape> TheShapes;

        public Shape(IEnumerable<IShape> item)
        {
            // Initialize with injected shapes
            TheShapes = new List<IShape>(item);
        }

        public IShape this[int index]
        {
            get
            {
                if (index < 0 || index >= TheShapes.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                return TheShapes[index];
            }

            set
            {
                if (index < 0 || index >= TheShapes.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                TheShapes[index] = value;
            }
        }
        public int Counting()
        {
            return TheShapes.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator<IShape>(TheShapes);
        }

    }
}
// Example usage
//var color = new Color(new List<IColors> { new Red(), new White(), new Yellow(), new CustomColor() });

