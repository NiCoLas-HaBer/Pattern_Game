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
            return new MyEnumerator(TheShapes);
        }



        public class MyEnumerator : IEnumerator
        {
            private List<IShape> items;
            private int position = -1;

            public MyEnumerator(List<IShape> items)
            {
                this.items = items;
            }

            public bool MoveNext()
            {
                position++;
                return position < items.Count;
            }

            public void Reset()
            {
                position = -1;
            }

            public object Current
            {
                get
                {
                    if (position >= 0 && position < items.Count)
                        return items[position];
                    else
                        throw new InvalidOperationException();
                }
            }
        }
    }
}
// Example usage
//var color = new Color(new List<IColors> { new Red(), new White(), new Yellow(), new CustomColor() });

